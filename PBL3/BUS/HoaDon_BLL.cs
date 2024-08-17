using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3.DTO;

namespace PBL3.BUS
{
    internal class HoaDon_BLL
    {
        private static HoaDon_BLL _Instance;
        public static HoaDon_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new HoaDon_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        public int GetnextmaHD()
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            var t = db.HoaDons.OrderByDescending(p => p.MaHD).FirstOrDefault();
            return t.MaHD + 1;
        }

        public void AddHoaDon(int MaHD, int MaDH, int MaKH, DateTime ThoiGian, long TongTien)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            HoaDon hd = new HoaDon();
            hd.MaHD = MaHD;
            hd.MaDH = MaDH;
            hd.MaKH = MaKH;
            hd.ThoiGian = ThoiGian;
            hd.TongTien = TongTien;
            db.HoaDons.Add(hd);
            db.SaveChanges();
        }

        public HoaDon GetHoaDonById(int maHD)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            return db.HoaDons.Find(maHD);
        }
        public List<Object> GetListObject()
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            List<HoaDon> listHD = db.HoaDons.ToList();
            List<Object> res = new List<Object>();
            foreach (HoaDon hd in listHD)
            {
                res.Add(new { hd.MaHD, hd.MaDH, hd.MaKH, hd.ThoiGian, hd.TongTien });
            }
            return res;
        }
        
        public List<Object> GetListHoaDonByID(int MaHD)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            List<HoaDon> listHD = db.HoaDons.ToList();
            List<Object> res = new List<Object>();
            foreach (HoaDon hd in listHD)
            {
                if (hd.MaHD == MaHD)
                {
                    res.Add(new { hd.MaHD, hd.MaDH, hd.MaKH, hd.ThoiGian, hd.TongTien });
                }
            }
            return res;
        }
        public void DeleteHoaDon(int MaHD)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            HoaDon hd = db.HoaDons.Where(p => p.MaHD == MaHD).SingleOrDefault();
            db.HoaDons.Remove(hd);
            db.SaveChanges();
        }

        public void UpdateHoaDon(int MaHD, int MaDH, int MaKH, DateTime ThoiGian, long TongTien)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            HoaDon hd = db.HoaDons.Where(p => p.MaHD == MaHD).SingleOrDefault();
            hd.MaDH = MaDH;
            hd.MaKH = MaKH;
            hd.ThoiGian = ThoiGian;
            hd.TongTien = TongTien;
            db.SaveChanges();
        }

        public List<HoaDon> GetListHoaDonByDate(DateTime date)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            List<HoaDon> listHD = db.HoaDons.ToList();
            List<HoaDon> res = new List<HoaDon>();
            foreach (HoaDon hd in listHD)
            {
                if (hd.ThoiGian == date)
                {
                    res.Add(hd);
                }
            }
            return res;
        }

        public List<Object> GetListHDByCa(int maCa, DateTime date)
        {
            QuanCaPhePBL3Entities quanCaPhePBL3Entities = new QuanCaPhePBL3Entities();
            List<HoaDon> hoaDons = quanCaPhePBL3Entities.HoaDons.ToList();
            List<Object> res = new List<object>();
            //giờ bắt đầu
            TimeSpan timeStart = new TimeSpan();
            //giờ kết thúc
            TimeSpan timeEnd = new TimeSpan();
            if (maCa == 1)
            {
                timeStart = new TimeSpan(7, 0, 0);
                timeEnd = new TimeSpan(12, 0, 0);
            }
            else if (maCa == 2)
            {
                timeStart = new TimeSpan(12, 0, 0);
                timeEnd = new TimeSpan(17, 0, 0);
            }
            else
            {
                timeStart = new TimeSpan(17, 0, 0);
                timeEnd = new TimeSpan(22, 0, 0);
            }
            string year = date.Year.ToString();
            string month = date.Month.ToString();
            string day = date.Day.ToString();   
            //datetime bắt đầu tính cả giờ phút giây
            DateTime start = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day), timeStart.Hours, timeStart.Minutes, timeStart.Seconds);
            //datetime kết thúc tính cả giờ phút giây
            DateTime end = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day), timeEnd.Hours, timeEnd.Minutes, timeEnd.Seconds);

            foreach (HoaDon hd in hoaDons)
            {
                if (hd.ThoiGian >= start && hd.ThoiGian <= end)
                {
                    res.Add(new { hd.MaHD, hd.MaDH, hd.MaKH,hd.KhachHang.TenKH, hd.ThoiGian, hd.TongTien });
                }
            }
            return res;
        }

    }
}
