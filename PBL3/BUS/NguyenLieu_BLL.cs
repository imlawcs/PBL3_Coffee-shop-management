using PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.BUS
{
    internal class NguyenLieu_BLL
    {
        private static NguyenLieu_BLL _Instance;
        public static NguyenLieu_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new NguyenLieu_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private NguyenLieu_BLL() { }

        public List<Object> GetListNguyenLieu(int ID, string name)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();

            if (name == null)
            {
                var l1 = db.NguyenLieux.Select(p => new { p.MaNL, p.TenNL, p.SLTonKho, p.DonViTinh });
                return l1.ToList<Object>();
            }
            else
            {
                var l2 = db.NguyenLieux.Where(p => p.TenNL.Contains(name))
                    .Select(p => new { p.MaNL, p.TenNL,  p.SLTonKho, p.DonViTinh });
                return l2.ToList<Object>();
            }

        }

        public List<Object> GetListNguyenLieu()
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            var l1 = db.NguyenLieux.Select(p => new { p.MaNL, p.TenNL, p.SLTonKho, p.DonViTinh });
            return l1.ToList<Object>();
        }
        public int GetIDNguyenLieu()
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            return db.NguyenLieux.Count() + 1;
        }
        public void TruNL(int manl, int slsp, decimal luongnl)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            DTO.NguyenLieu i = db.NguyenLieux.Find(manl);
            decimal t = (decimal)(i.SLTonKho - (slsp * luongnl));
            i.SLTonKho = t;
            db.SaveChanges();
        }
        public DTO.NguyenLieu GetNLbymaNL(int maNL)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            return db.NguyenLieux.Find(maNL);
        }
        //add nguyên liệu mới
        public void AddNguyenLieu(string tennl, int SLtonkho, string donvi, DateTime ngayNhap, DateTime ngayHetHan, int giaNhap)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            NguyenLieu nl = new NguyenLieu();
            int manl=db.NguyenLieux.Count() + 1;
            nl.MaNL = manl;
            nl.TenNL = tennl;
            nl.SLTonKho = 0;
            nl.DonViTinh = donvi;
            db.NguyenLieux.Add(nl);
            db.SaveChanges();

            ChiTietNguyenLieu_BLL.Instance.AddChiTietNguyenLieu(manl, ngayNhap, SLtonkho, ngayHetHan, giaNhap);

        }
        public void EditNguyenLieu(string manl, string tennl, string SLtonkho, string donvi)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            NguyenLieu sedit = db.NguyenLieux.Find(Convert.ToInt32(manl));
            sedit.TenNL = tennl;
            sedit.SLTonKho = Convert.ToInt32(SLtonkho);

            sedit.DonViTinh = donvi;
            db.SaveChanges();
        }
        public void DeleteNguyenLieu(int id)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            NguyenLieu nlDelete = db.NguyenLieux.Find(id);
            
            ChiTietNguyenLieu_BLL.Instance.DelChiTietNguyenLieu(id);

            db.NguyenLieux.Remove(nlDelete);
            db.SaveChanges();
        }
        public void LayThongTinNguyenLieu(int s, ref string manl, ref string tennl, ref string SLtonkho, ref DateTime ngayhethan, ref string gia, ref string donvi)
        {
            manl = s.ToString();
            using (QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities())
            {
                foreach (NguyenLieu i in db.NguyenLieux)
                {
                    if (i.MaNL.ToString() == manl)
                    {
                        tennl = i.TenNL;
                        SLtonkho = i.SLTonKho.ToString();

                        donvi = i.DonViTinh.ToString();
                    }
                }
            }
        }
        public int Check(string s)
        {
            int d = 0;
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            {
                foreach (NguyenLieu i in db.NguyenLieux)
                {
                    if (i.MaNL.ToString() == s)
                        d += 1;
                    break;
                }
            }
            return d;
        }

        internal DTO.NguyenLieu GetNguyenLieu(int maNL)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            return db.NguyenLieux.Find(maNL);
        }
    }
}
