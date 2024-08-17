using PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.BUS
{
    internal class KhachHang_BLL
    {
        private static KhachHang_BLL _Instance;
        public static KhachHang_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new KhachHang_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private KhachHang_BLL() { }
        public List<Object> GetListKhachHang(int ID, string name)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();

            if (name == null)
            {
                var l1 = db.KhachHangs.Where(p => p.TonTai == true).Select(p => new { p.MaKH, p.MaLKH, p.TenKH, p.SDT, p.LoaiKhachHang.TenLKH });
                return l1.ToList<Object>();
            }

            else
            {
                var l1 = db.KhachHangs.Where(p => p.TonTai == true).Where(p => p.TenKH.Contains(name)).Select(p => new { p.MaKH, p.MaLKH, p.TenKH, p.SDT, p.LoaiKhachHang.TenLKH });
                return l1.ToList<Object>();
            }
        }
        public List<Object> GetListKHBySDT(string sdt)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            List <object> l = new List<object>();
            foreach (KhachHang i in db.KhachHangs)
            {
                if (i.SDT == sdt && i.TonTai==true)
                {
                    l.Add(new
                    {
                        MaKH = i.MaKH,
                        TenKH = i.TenKH,
                        SDT = i.SDT,
                        MaLKH = i.MaLKH,
                        LKH = i.LoaiKhachHang.TenLKH
                    });
                }
            }
            return l;
        }
        public KhachHang GetKHbySDT(string sdt)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            KhachHang k = db.KhachHangs.Where(p => p.TonTai == true).Where(p => p.SDT == sdt).FirstOrDefault();
            return k;
        }
        public KhachHang GetKHbyMaKH(int maKH)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            return db.KhachHangs.Find(maKH);
        }
        public void ChangemaLKH(int maKH)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            KhachHang sedit = db.KhachHangs.Find(maKH);
            if (sedit.MaLKH == 2)
            {
                sedit.MaLKH = 3;
            }
            db.SaveChanges();
        }
        public LoaiKhachHang GetLKH(KhachHang k)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            return k.LoaiKhachHang;
        }
        public List<Object> GetListKhachHang()
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            List<Object> list = new List<Object>();
            foreach (KhachHang i in db.KhachHangs.Where(p => p.TonTai == true))
            {
                list.Add(new
                {
                    MaKH = i.MaKH,
                    TenKH = i.TenKH,
                    SDT = i.SDT,
                    MaLKH = i.MaLKH,
                    LKH =i.LoaiKhachHang.TenLKH
                });
            }
            return list;
        }
        public Boolean CheckTrungsdt(string s)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            foreach (DTO.KhachHang i in db.KhachHangs.Where(p => p.TonTai == true).ToList())
            {
                if (i.SDT == s) return true;
            }
            return false;
        }
        public Boolean CheckTrungsdtUpdate(string sdtcu, string sdtmoi)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            DTO.KhachHang kh = GetKHbySDT(sdtcu);
            if (kh != null)
            {
                foreach (DTO.KhachHang i in db.KhachHangs.Where(p => p.TonTai == true).ToList())
                {
                    if (i.SDT == sdtmoi && i.SDT != kh.SDT) return true;
                }
            }               
            return false;
        }
        public void AddKhachHang(string maso, string hoten, string sdt, string maloaikh)
        {
            KhachHang s = new KhachHang
            {
                MaKH = Convert.ToInt32(maso),
                TenKH = hoten,
                SDT = sdt,
                MaLKH = Convert.ToInt32(maloaikh),
            };
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            db.KhachHangs.Add(s);
            db.SaveChanges();
        }
        //thêm khách hàng mới
        public void AddKhachHang(string hoten, string sdt)
        {

            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            int maKH = db.KhachHangs.Count() + 1;
            KhachHang s = new KhachHang
            {
                MaKH = maKH,
                TenKH = hoten,
                SDT = sdt,
                MaLKH = 2,
            };
            db.KhachHangs.Add(s);
            db.SaveChanges();
        }
        public void EditKhachHang(string maso, string hoten, string sdt, string maloaikh)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            KhachHang sedit = db.KhachHangs.Find(Convert.ToInt32(maso));
            sedit.TenKH = hoten;
            sedit.SDT = sdt;
            sedit.MaLKH = Convert.ToInt32(maloaikh);
            db.SaveChanges();
        }
        public void DeleteKH(int id)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            KhachHang KHDelete = db.KhachHangs.Find(id);
            KHDelete.TonTai = false;
            db.SaveChanges();
        }
        public void LayThongTinNV(int s, string makh, string hoten, string sdt, string maloaikh)
        {
            makh = s.ToString();
            using (QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities())
            {
                foreach (KhachHang i in db.KhachHangs)
                {
                    if (i.MaKH.ToString() == makh)
                    {
                        hoten = i.TenKH;
                        sdt = i.SDT;
                        maloaikh = i.MaLKH.ToString();
                    }
                }
            }
        }
        public int Check(string s)
        {
            int d = 0;
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            {
                foreach (KhachHang i in db.KhachHangs)
                {
                    if (i.MaKH.ToString() == s)
                        d += 1;
                    break;
                }
            }
            return d;
        }

        public string getTenKH(int maKH)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            return db.KhachHangs.Find(maKH).TenKH;
        }

        public void UpdateListKHTT()
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            List<KhachHang> listKH = db.KhachHangs.ToList();
            foreach(KhachHang kh in listKH)
            {
                UpdateLKHTT(kh.MaKH);
            }
        }
        public string getSDTKH(int maKH)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            return db.KhachHangs.Find(maKH).SDT;

        }

        private void UpdateLKHTT(int maKH)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            DateTime firstDay = new DateTime(DateTime.Now.Year, 1, 1);
            List<HoaDon> listHD = db.HoaDons.Where(p => p.MaKH == maKH && p.ThoiGian.Value<=DateTime.Now && p.ThoiGian.Value>=firstDay).ToList();
            if(listHD.Count >= 10)
            {
                KhachHang kh = db.KhachHangs.Find(maKH);
                kh.MaLKH = 1;
                db.SaveChanges();
            }

        }
    }
}
