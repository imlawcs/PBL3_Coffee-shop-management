using PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.BUS
{
    internal class SanPham_BLL
    {
        private static SanPham_BLL _Instance;
        public static SanPham_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SanPham_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private SanPham_BLL() { }
        public List<Object> GetListSanPham(int ID, string name)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            if (name == null)
            {
                var l = db.SanPhams.Where(p=>p.TonTai==true).Select(p => new { p.MaSP, p.TenSP, p.LoaiSP, p.NhomSP, p.DonViSP, p.GiaSP });
                return l.ToList<Object>();
            }
            else
            {
                var l1 = db.SanPhams.Where(p => p.TonTai == true).Where(p => p.TenSP.ToLower().Contains(name)).Select(p => new { p.MaSP, p.TenSP, p.LoaiSP, p.NhomSP, p.DonViSP, p.GiaSP });
                return l1.ToList<Object>();
            }
        }
        public List<Object> GetListObjectSanPham()
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            var l = db.SanPhams.Where(p => p.TonTai == true).Select(p => new { p.MaSP, p.TenSP, p.LoaiSP, p.NhomSP, p.DonViSP, p.GiaSP });
            return l.ToList<Object>();

        }
        public List<SanPham> GetListSanPham(string name)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            var l = db.SanPhams.Where(p => p.TonTai == true).Where(sp => sp.TenSP.ToLower().Contains(name)).ToList();
            return l;

        }
        public List<SanPham> GetAllListSanPham()
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            var l = db.SanPhams.Where(p => p.TonTai == true).Select(p => p).ToList();
            return l;
        }

        public Boolean CheckTrungName(string s)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            foreach(SanPham i in db.SanPhams.ToList())
            {
                if (i.TenSP == s) return true;
            }    
            return false;
        }
        public int GetnextmaSP()
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            var s = db.SanPhams.OrderByDescending(p => p.MaSP).FirstOrDefault();
            return s.MaSP + 1;
        }
        public int SLsp()
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            return db.SanPhams.Count();
        }
        public void TruNLtheoSP(int maSP, int SLsp)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            foreach (ChiTietSanPham i in ChiTietSanPham_BLL.Instance.GetListChiTietSanPhamByMaSP(maSP))
            {
                int maNL = i.MaNL;
                decimal sl = (decimal)i.SLNguyenLieu;
                NguyenLieu_BLL.Instance.TruNL(maNL, SLsp, sl);
            }
            db.SaveChanges();
        }
        public string getTenSP(int id)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            SanPham sp = db.SanPhams.Find(id);
            return sp.TenSP;
        }
        public void AddSanPham(string masp, string tensp, string giasp, string loai, string nhom, string donvi, string duongdan)
        {
            SanPham s = new SanPham
            {
                MaSP = Convert.ToInt32(masp),
                TenSP = tensp,
                GiaSP = Convert.ToInt32(giasp),
                LoaiSP = loai,
                NhomSP = nhom,
                DonViSP = donvi,
                DuongDanAnh = duongdan
            };
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            db.SanPhams.Add(s);
            db.SaveChanges();
        }
        public void EditSanPham(string masp, string tensp, string giasp, string loai, string nhom, string donvi, string duongdan)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            SanPham sedit = db.SanPhams.Find(Convert.ToInt32(masp));
            sedit.TenSP = tensp;
            sedit.GiaSP = Convert.ToInt32(giasp);
            sedit.LoaiSP = loai;
            sedit.NhomSP = nhom;
            sedit.DonViSP = donvi;
            sedit.DuongDanAnh = duongdan;
            db.SaveChanges();
        }
        //xóa mềm
        public void DeleteSanPham(int id)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            SanPham nlDelete = db.SanPhams.Find(id);
            nlDelete.TonTai= false;
            db.SaveChanges();
        }
        public void LayThongTinSanPham(int s, ref string masp, ref string tensp, ref string giasp, ref string loai, ref string nhom, ref string donvi, ref string duongdan)
        {
            masp = s.ToString();
            using (QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities())
            {
                foreach (SanPham i in db.SanPhams)
                {
                    if (i.MaSP.ToString() == masp)
                    {
                        tensp = i.TenSP;
                        giasp = i.GiaSP.ToString();
                        loai = i.LoaiSP;
                        nhom = i.NhomSP;
                        donvi = i.DonViSP.ToString();
                        duongdan = i.DuongDanAnh;
                    }
                }
            }
        }
        public int Check(string s)
        {
            int d = 0;
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            {
                foreach (SanPham i in db.SanPhams)
                {
                    if (i.MaSP.ToString() == s)
                        d += 1;
                    break;
                }
            }
            return d;
        }

        internal object getGiaSP(int maSP)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            SanPham sp = db.SanPhams.Find(maSP);
            return sp.GiaSP;
        }
    }
}
