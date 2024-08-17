using Guna.UI2.WinForms;
using PBL3.BUS;
using PBL3.DTO;
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
    public partial class ThemMon : Form
    {
        private int maNV, maKH = 0;
        private List<SelectedDrink> selectedDrinks = new List<SelectedDrink>();
        public ThemMon(int maNV, List<SelectedDrink> selectedDrinks)
        {
            this.maNV = maNV;
            InitializeComponent();
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);

            this.selectedDrinks = selectedDrinks;
            themMonData.Columns.Add("MaSP", "Mã sản phẩm");
            themMonData.Columns.Add("LoaiSP", "Loại sản phẩm");
            themMonData.Columns.Add("Name", "Tên sản phẩm");
            themMonData.Columns.Add("Quantity", "Số lượng");
            ShowDB();
        }
        public ThemMon(int maNV, List<SelectedDrink> selectedDrinks, int maKH)
        {
            this.maNV = maNV;
            this.maKH = maKH;
            InitializeComponent();
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);

            this.selectedDrinks = selectedDrinks;
            themMonData.Columns.Add("MaSP", "Mã sản phẩm");
            themMonData.Columns.Add("LoaiSP", "Loại sản phẩm");
            themMonData.Columns.Add("Name", "Tên sản phẩm");
            themMonData.Columns.Add("Quantity", "Số lượng");
            ShowDB();
        }
        public void ShowDB()
        {
            foreach (var item in selectedDrinks)
            {
                themMonData.Rows.Add(item.MaSP, item.LoaiSP, item.TenMon, item.SoLuong);
            }
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DangNhap dangNhap = new DangNhap();
                this.Hide();
                dangNhap.ShowDialog();
                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.maKH == 0)
            {
                DatMon f = new DatMon(maNV, selectedDrinks, 1);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                DatMon f = new DatMon(maNV, selectedDrinks, 1, this.maKH);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            
        }

        private void xacNhanButton_Click(object sender, EventArgs e)
        {
            int maDH = DonHang_BLL.Instance.GetmaDHTieptheo();
            foreach (SelectedDrink i in selectedDrinks)
            {
                DonHang_BLL.Instance.AddDonHang(maDH, i.MaSP, i.SoLuong);
            }
            if (this.maKH == 0)
            {
                Thanh f = new Thanh(maNV, selectedDrinks, maDH);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                Thanh f = new Thanh(maNV, selectedDrinks, maDH, maKH);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DatMon f = new DatMon(maNV);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ManHinhChinh_NV manHinhChinh = new ManHinhChinh_NV(maNV);
            this.Hide();
            manHinhChinh.ShowDialog();
            this.Close();
        }
    }
}
