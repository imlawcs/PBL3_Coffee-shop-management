using PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.BUS
{
    internal class LoaiKhachHang_BLL
    {
        private static LoaiKhachHang_BLL _Instance;
        public static LoaiKhachHang_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LoaiKhachHang_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private LoaiKhachHang_BLL() { }
        public List<LoaiKhachHang> GetListLKH(int ID, string name)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();

            if (name == null)
                return db.LoaiKhachHangs.ToList();
            else return db.LoaiKhachHangs.Where(p => p.TenLKH.Contains(name)).ToList();

        }
        public void AddLKH(string malkh, string tenlkh)
        {
            LoaiKhachHang s = new LoaiKhachHang
            {
                MaLKH = Convert.ToInt32(malkh),
                TenLKH = tenlkh
            };
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            db.LoaiKhachHangs.Add(s);
            db.SaveChanges();
        }
        public void EditLKH(string malkh, string tenlkh)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            LoaiKhachHang sedit = db.LoaiKhachHangs.Find(Convert.ToInt32(malkh));
            sedit.TenLKH = tenlkh;
            db.SaveChanges();
        }
        public void DeleteLKH(int id)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            LoaiKhachHang banDelete = db.LoaiKhachHangs.Find(id);
            db.LoaiKhachHangs.Remove(banDelete);
            db.SaveChanges();
        }
        public void LayThongTinLKH(int s, string malkh, string tenlkh)
        {
            malkh = s.ToString();
            using (QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities())
            {
                foreach (LoaiKhachHang i in db.LoaiKhachHangs)
                {
                    if (i.MaLKH.ToString() == malkh)
                    {
                        tenlkh = i.TenLKH;
                    }
                }
            }
        }
        public int Check(string s)
        {
            int d = 0;
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            {
                foreach (LoaiKhachHang i in db.LoaiKhachHangs)
                {
                    if (i.MaLKH.ToString() == s)
                        d += 1;
                    break;
                }
            }
            return d;
        }
    }
}
