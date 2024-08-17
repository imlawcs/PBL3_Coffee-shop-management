using PBL3.BUS;
using PBL3.DTO;
using PBL3.GUI.Admin;
using PBL3.GUI.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.GUI
{
    public partial class ManHinhChinh : Form
    {
        private int maNV;

        public ManHinhChinh()
        {
            InitializeComponent();
        }

        public ManHinhChinh(int maNV)
        {
            this.maNV = maNV;
            InitializeComponent();
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);
        }

        private void TKeButton_Click(object sender, EventArgs e)
        {
            ThongKe f = new ThongKe(maNV);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void CLVButton_Click(object sender, EventArgs e)
        {
            CaLamViec f = new CaLamViec(maNV);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }



        private void TKButton_Click(object sender, EventArgs e)
        {
            Admin.TaiKhoan f = new Admin.TaiKhoan(maNV);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void NVButton_Click(object sender, EventArgs e)
        {
            Admin.NhanVien f = new Admin.NhanVien(maNV);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void KHButton_Click(object sender, EventArgs e)
        {
            Admin.KhachHang f = new Admin.KhachHang(maNV);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void KMButton_Click(object sender, EventArgs e)
        {
            GUI.KhuyenMai f = new GUI.KhuyenMai(maNV);
            this.Hide();
            f.ShowDialog(); Close();
        }

        private void HDButton_Click(object sender, EventArgs e)
        {
            Employee.HoaDon f = new Employee.HoaDon(maNV);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void TDButton_Click(object sender, EventArgs e)
        {
            GUI.ThucDon f = new GUI.ThucDon(maNV);
            this.Hide();
            f.ShowDialog();
            Close();
        }

        private void NLButton_Click(object sender, EventArgs e)
        {
            Admin.NguyenLieu f = new Admin.NguyenLieu(maNV);
            this.Hide();
            f.ShowDialog(); Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DangNhap f = new DangNhap();
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            ThongTinNhanVien f = new ThongTinNhanVien(maNV);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
    }
}
