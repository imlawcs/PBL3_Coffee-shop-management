using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3.DTO;

namespace PBL3.BUS
{
    internal class CaTruc_BLL
    {
        private static CaTruc_BLL _Instance;
        public static CaTruc_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CaTruc_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private CaTruc_BLL() { }
        public List<CaTruc> GetListCaTruc()
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            return quanCaPheEntities.CaTrucs.ToList();
        }

        public int GetCaTrucCoNV(int maNV, string Day)
        {
            List<CaTruc> list = GetListCaTruc();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].NgayTruc.ToString("yyyy-MM-dd") == Day)
                {
                    for (int j = 0; j < list[i].NhanViens.Count; j++)
                    {
                        if (list[i].NhanViens.ElementAt(j).MaNV == maNV)
                        {
                            return list[i].MaCT;
                        }
                    }
                }
            }
            return -1;
        }
        public List<Object> GetListNhanVien(int idCT, string day)
        {
            //lấy ra nhân viên trong ca trực 
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<CaTruc> list = quanCaPheEntities.CaTrucs.ToList();
            List<Object> res= new List<Object>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaCT == idCT && list[i].NgayTruc.ToString("yyyy-MM-dd") == day)
                {
                    List<NhanVien> listNV = list[i].NhanViens.ToList();
                    foreach (NhanVien j in listNV)
                    {
                        res.Add(new
                        {
                            MaNV = j.MaNV,
                            HoTenNV = j.HoTenNV,
                            ChucVu = j.ChucVu.TenCV,
                            NgaySinh = j.NgaySinh,
                            Luong = j.Luong,
                            GioiTinh = (j.GioiTinh == true) ? "Nữ" : "Nam"
                        });
                    }
                }
            }
            return res;

        }

        public List<NhanVien> GetListNhanVienPhucVu(int idCT, DateTime day)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            DateTime t = day.Date;
            CaTruc i = db.CaTrucs.Where(p => p.MaCT == idCT && DbFunctions.TruncateTime(p.NgayTruc) == t).FirstOrDefault();
            return i.NhanViens.Where(p => p.MaCV == 4).ToList();

        }
        public CaTruc newCaTruc1(DateTime day)
        {
            CaTruc ca1 = new CaTruc();
            ca1.MaCT = 1;
            ca1.NgayTruc = day;
            ca1.ThoiGianBD = new TimeSpan(7, 0, 0);
            ca1.ThoiGianKT = new TimeSpan(12, 0, 0);
            return ca1;
        }
        public CaTruc newCaTruc2(DateTime day)
        {
            CaTruc ca2 = new CaTruc();
            ca2.MaCT = 2;
            ca2.NgayTruc = day;
            ca2.ThoiGianBD = new TimeSpan(12, 0, 0);
            ca2.ThoiGianKT = new TimeSpan(17, 0, 0);
            return ca2;
        }
        public CaTruc newCaTruc3(DateTime day)
        {
            CaTruc ca3 = new CaTruc();
            ca3.MaCT = 3;
            ca3.NgayTruc = day;
            ca3.ThoiGianBD = new TimeSpan(17, 0, 0);
            ca3.ThoiGianKT = new TimeSpan(22, 0, 0);
            return ca3;
        }
        public void AddCaTruc()
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            //kiểm tra có ca trực tháng nay chưa

            List<CaTruc> list = quanCaPheEntities.CaTrucs.ToList();
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].NgayTruc.Month == DateTime.Now.Month && list[i].NgayTruc.Year == DateTime.Now.Year)
                {
                    return;
                }
            }
            //số ngày trong tháng
            int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            for(int i = 1; i <= days; i++)
            {
                quanCaPheEntities.CaTrucs.Add(newCaTruc1(new DateTime(DateTime.Now.Year, DateTime.Now.Month, i)));
                quanCaPheEntities.CaTrucs.Add(newCaTruc2(new DateTime(DateTime.Now.Year, DateTime.Now.Month, i)));
                quanCaPheEntities.CaTrucs.Add(newCaTruc3(new DateTime(DateTime.Now.Year, DateTime.Now.Month, i)));

                quanCaPheEntities.SaveChanges();
            }

        }

        public void AddCaTruc(DateTime day)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            DateTime date = new DateTime(day.Year, day.Month, day.Day);
            int days= DateTime.DaysInMonth(date.Year, date.Month);
            for(int i=0;i<db.CaTrucs.Count();i++)
            {
                if (db.CaTrucs.ToList()[i].NgayTruc.Month == date.Month && db.CaTrucs.ToList()[i].NgayTruc.Year == date.Year)
                {
                    return;
                }
            }
            for (int i = 1; i <= days; i++)
            {
                db.CaTrucs.Add(newCaTruc1(new DateTime(date.Year, date.Month, i)));
                db.CaTrucs.Add(newCaTruc2(new DateTime(date.Year, date.Month, i)));
                db.CaTrucs.Add(newCaTruc3(new DateTime(date.Year, date.Month, i)));
                db.SaveChanges();
            }
        }

        public long TinhDoanhThuCa(string Day, int MaCa)
        {
            QuanCaPhePBL3Entities quanCaPhePBL3Entities = new QuanCaPhePBL3Entities();
            List<HoaDon> hoaDons = quanCaPhePBL3Entities.HoaDons.ToList();
            //giờ bắt đầu
            TimeSpan timeStart = new TimeSpan();
            //giờ kết thúc
            TimeSpan timeEnd = new TimeSpan();
            if (MaCa == 1)
            {
                timeStart = new TimeSpan(7, 0, 0);
                timeEnd = new TimeSpan(12, 0, 0);
            }
            else if (MaCa == 2)
            {
                timeStart = new TimeSpan(12, 0, 0);
                timeEnd = new TimeSpan(17, 0, 0);
            }
            else
            {
                timeStart = new TimeSpan(17, 0, 0);
                timeEnd = new TimeSpan(22, 0, 0);
            }
            string month = Day.Substring(5, 2);
            string day = Day.Substring(8, 2);
            string year = Day.Substring(0, 4);
            //datetime bắt đầu tính cả giờ phút giây
            DateTime start = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day), timeStart.Hours, timeStart.Minutes, timeStart.Seconds);
            //datetime kết thúc tính cả giờ phút giây
            DateTime end = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day), timeEnd.Hours, timeEnd.Minutes, timeEnd.Seconds);
            long dtCa = 0;
            foreach(HoaDon hoaDon in hoaDons)
            {
                if (hoaDon.ThoiGian.Value.ToString("yyyy-MM-dd") == Day)
                {
                    if (hoaDon.ThoiGian.Value >= start && hoaDon.ThoiGian.Value <= end)
                    {
                        dtCa += hoaDon.TongTien.Value;
                    }
                }
            }
            DoanhThu_BLL.Instance.AddDoanhThu(MaCa, Day, dtCa);
            return dtCa;
        }
        public void AddNhanVienToCaTruc(int idNV, int id, string day)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<CaTruc> list = quanCaPheEntities.CaTrucs.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaCT == id && list[i].NgayTruc.ToString() == day)
                {
                    list[i].NhanViens.Add(quanCaPheEntities.NhanViens.Find(idNV));

                    quanCaPheEntities.SaveChanges();
                    return;
                }
            }
        }

        public void DelNhanVienFromCaTruc(int idNV, int id, string day)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<CaTruc> list = quanCaPheEntities.CaTrucs.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaCT == id && list[i].NgayTruc.ToString() == day)
                {
                    list[i].NhanViens.Remove(quanCaPheEntities.NhanViens.Find(idNV));
                    quanCaPheEntities.SaveChanges();
                    return;
                }
            }
        }

        public void DeleteCaTruc(int id, string day)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<CaTruc> list = quanCaPheEntities.CaTrucs.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaCT == id && list[i].NgayTruc.ToString() == day)
                {
                    //xóa dòng doanh thu ca trong bảng doanh thu
                    List<DoanhThu> listDT = quanCaPheEntities.DoanhThus.ToList();
                    for (int j = 0; j < listDT.Count; j++)
                    {
                        if (listDT[j].MaCT == id && listDT[j].NgayTruc.ToString() == day)
                        {
                            quanCaPheEntities.DoanhThus.Remove(listDT[j]);
                            quanCaPheEntities.SaveChanges();
                            break;
                        }
                    }
                    //xóa danh sách nhân viên làm việc trong ca ra khỏi ca
                    list[i].NhanViens.Clear();
                    quanCaPheEntities.CaTrucs.Remove(list[i]);
                    quanCaPheEntities.SaveChanges();
                    return;
                }
            }
        }
    }
}
