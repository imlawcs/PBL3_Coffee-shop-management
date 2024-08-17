using PBL3.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.GUI.Employee
{
    public partial class ManHinhChinh_NV : Form
    {
        private int maNV;

        public ManHinhChinh_NV()
        {
            InitializeComponent();
        }

        public ManHinhChinh_NV(int maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);
        }

  

        private void banButton_Click(object sender, EventArgs e)
        {
            Ban f = new Ban(maNV);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void TKeButton_Click(object sender, EventArgs e)
        {
            ThongKe_NV f = new ThongKe_NV(maNV);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

       

        private void HDButton_Click(object sender, EventArgs e)
        {
            HoaDon f = new HoaDon(maNV);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void DHButton_Click(object sender, EventArgs e)
        {
            DonHang donHang = new DonHang(maNV);
            this.Hide();
            donHang.ShowDialog();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                DangNhap f = new DangNhap();
                this.Hide();
                f.ShowDialog();
                this.Close();
            }

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            ThongTinNhanVien thongTinNhanVien = new ThongTinNhanVien(maNV);
            this.Hide();
            thongTinNhanVien.ShowDialog();
            this.Close();
        }

        private void KHbt_Click(object sender, EventArgs e)
        {
            KhachHang khachHang = new KhachHang(maNV);
            this.Hide();
            khachHang.ShowDialog();
            this.Close();
        }

        private void hoaDonExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DangNhap dangNhap = new DangNhap();
                this.Hide();
                dangNhap.ShowDialog();
                this.Close();
            }
        }

        private void datMon_Click(object sender, EventArgs e)
        {
            if (Ban_BLL.Instance.GetListBanFree().Count == 0)
            {
                //MessageBox.Show("Hiện tại quán không có bàn trống");
                ThatBai f3 = new ThatBai("Hiện tại quán không có bàn trống");
                f3.ShowDialog();
                return;
            }
            DatMon f = new DatMon(maNV);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
    }
}
