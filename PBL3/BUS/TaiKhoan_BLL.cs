using PBL3.BUS;
using PBL3.DTO;
using PBL3.GUI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PBL3.BUS
{
    internal class TaiKhoan_BLL
    {
        private static TaiKhoan_BLL _Instance;
        public static TaiKhoan_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new TaiKhoan_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private TaiKhoan_BLL() { }
        public List<Object> GetListTaiKhoan(int ID, string name)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();

            if (name == null)
            {
                var l1 = db.TaiKhoans.Select(p => new { p.MaNV, p.NhanVien.HoTenNV, p.TenDangNhap, p.MatKhau });
                return l1.ToList<Object>();
            }
            else
            {
                var l2 = db.TaiKhoans.Where(p => p.NhanVien.HoTenNV.Contains(name)).Select(p => new { p.MaNV, p.NhanVien.HoTenNV, p.TenDangNhap, p.MatKhau });
                return l2.ToList<Object>();
            }

        }
        public void AddTaiKhoan(string manv, string tendangnhap, string mk)
        {
            TaiKhoan s = new TaiKhoan
            {
                MaNV = Convert.ToInt32(manv),
                TenDangNhap = tendangnhap,
                MatKhau = mk
            };
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            db.TaiKhoans.Add(s);
            db.SaveChanges();
        }
        public void EditTaiKhoan(string manv, string tendangnhap, string mk)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            TaiKhoan sedit = db.TaiKhoans.Find(Convert.ToInt32(manv));
            sedit.TenDangNhap = tendangnhap;
            sedit.MatKhau = mk;
            db.SaveChanges();
        }

        public void EditTaiKhoanNV(string maNV, string mkCu, string tenDangNhap, string mk, string mkMoi)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            TaiKhoan sedit = db.TaiKhoans.Find(Convert.ToInt32(maNV));
            if (sedit.MatKhau == mkCu)
            {
                if (mk == mkMoi)
                {
                    sedit.TenDangNhap = tenDangNhap;
                    sedit.MatKhau = mk;
                    db.SaveChanges();
                }
                else
                {
                    //MessageBox.Show("Mật khẩu mới không trùng khớp. Vui lòng nhập lại.");
                    ThatBai f3 = new ThatBai("Mật khẩu mới không trùng khớp. Vui lòng nhập lại");
                    f3.ShowDialog();
                }
            }
            else
            {
                //MessageBox.Show("Mật khẩu cũ không đúng. Vui lòng nhập lại.");
                ThatBai f3 = new ThatBai("Mật khẩu cũ không đúng. Vui lòng nhập lại");
                f3.ShowDialog();
            }
        }
        public void DeleteTaiKhoan(int id)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            TaiKhoan nvDelete = db.TaiKhoans.Find(id);
            db.TaiKhoans.Remove(nvDelete);
            db.SaveChanges();
        }
        public void LayThongTinTaiKhoan(int s, ref string manv, ref string tendangnhap, ref string mk)
        {
            manv = s.ToString();
            using (QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities())
            {
                foreach (TaiKhoan i in db.TaiKhoans)
                {
                    if (i.MaNV.ToString() == manv)
                    {
                        tendangnhap = i.TenDangNhap;
                        mk = i.MatKhau;
                    }
                }
            }
        }
        public int GetMaNV(string tenDangNhap, string MatKhau)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            var account = db.TaiKhoans.FirstOrDefault(a => a.TenDangNhap == tenDangNhap && a.MatKhau == MatKhau);
            if (account != null)
            {
                return account.MaNV;
            }
            return 0;
        }

        internal string getTenTK(int maNV1)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            var account = db.TaiKhoans.FirstOrDefault(a => a.MaNV == maNV1);
            if (account != null)
            {
                return account.TenDangNhap;
            }
            return "";
        }

        internal string getPass(int maNV1)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            var account = db.TaiKhoans.FirstOrDefault(a => a.MaNV == maNV1);
            if (account != null)
            {
                return account.MatKhau;
            }
            return "";
        }

        public int Check(string s)
        {
            int d = 0;
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            {
                foreach (TaiKhoan i in db.TaiKhoans)
                {
                    if (i.MaNV.ToString() == s)
                        d += 1;
                    break;
                }
            }
            return d;
        }
        public int Login(string username, string password, bool chucvu1, bool chucvu2)
        {
            if (!chucvu1 && !chucvu2)
            {
                return 2;
            }
            else
            {
                QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
                var account = db.TaiKhoans.FirstOrDefault(a => a.TenDangNhap == username && a.MatKhau == password);

                if (account != null)
                {
                    var employee = db.NhanViens.FirstOrDefault(e => e.MaNV == account.MaNV);
                    if (employee != null)
                    {
                        int ma = 0;
                        if (chucvu1) ma = 1;
                        else ma = 2;
                        if (employee.MaCV == ma)
                        {
                            return 1;
                        }
                        else
                        {
                            return 3;

                        }
                    }
                }
                return 4;
            }
        }

        internal bool CheckTaiKhoan(string tenTK, string maCV)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            List<TaiKhoan> list = db.TaiKhoans.ToList();
            foreach (TaiKhoan i in list)
            {
                
                int MaCV = NhanVien_BLL.Instance.getmaCV(TaiKhoan_BLL.Instance.GetMaNV(i.TenDangNhap, i.MatKhau));
                if (i.TenDangNhap == tenTK && MaCV.ToString() == maCV)
                {
                    //đã tồn tại
                    return true;
                }
            }
            return false;
        }
    }
}
