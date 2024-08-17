using PBL3.BUS;
using PBL3.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.GUI.Employee
{
    public partial class ChiTietHoaDonSauThanhToan : Form
    {
        private int maNV, maDH, maBan, maKH, maKM, maNVphucvu, maHD;

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int maCV = NhanVien_BLL.Instance.getmaCV(maNV);
            if (maCV == 1)
            {
                ManHinhChinh manHinhChinh = new ManHinhChinh(maNV);
                this.Hide();
                manHinhChinh.ShowDialog();
                this.Close();
            }
            else
            {
                ManHinhChinh_NV manHinhChinh = new ManHinhChinh_NV(maNV);
                this.Hide();
                manHinhChinh.ShowDialog();
                this.Close();
            }
        }

        private void hoaDonExit_Click_1(object sender, EventArgs e)
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

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            pictureBox3_Click(sender, e);
        }     
        

        private List<SelectedDrink> selectedDrinks;

        public ChiTietHoaDonSauThanhToan(int maNV, int maHD, List<SelectedDrink> selectedDrinks, int maDH, int maBan, int maKH, int maKM, int maNVphucvu, DateTime tgianthanhtoan, long Tongthanhtoan)
        {
            InitializeComponent();
            this.maNV = maNV;
            this.maDH = maDH;
            this.selectedDrinks = selectedDrinks;
            this.maBan = maBan;
            this.maKH = maKH;
            this.maKM = maKM;
            this.maNVphucvu = maNVphucvu;
            this.maHD = maHD;
            label12.Text = this.maHD.ToString();
            label1.Text = maDH.ToString();
            label4.Text = KhachHang_BLL.Instance.GetKHbyMaKH(maKH).TenKH;
            label11.Text = tgianthanhtoan.ToString("dd/MM/yyyy HH:mm:ss");
            DTO.Ban b = Ban_BLL.Instance.GetBan(maBan);
            label15.Text = maBan.ToString();
            label17.Text = b.ViTri;
            label7.Text = Tongthanhtoan.ToString();
            label9.Text = NhanVien_BLL.Instance.GetNVbymaNV(maNVphucvu).HoTenNV;
            hoaDonData.Columns.Add("MaSP", "Mã sản phẩm");
            hoaDonData.Columns.Add("LoaiSP", "Loại sản phẩm");
            hoaDonData.Columns.Add("Name", "Tên sản phẩm");
            hoaDonData.Columns.Add("Quantity", "Số lượng");
            hoaDonData.Columns.Add("Price", "Đơn giá");
            ShowDB();
            
            if (maKM != 0)
            {
                dataKM.Columns.Add("TenCT", "Tên chương trình");
                dataKM.Rows.Add(KhuyenMai_BLL.Instance.GetKMbymaKM(maKM).TenCT);
            }
            else
            {
                dataKM.Columns.Clear();
                dataKM.Rows.Clear();
            } 
                

        }
        public void ShowDB()
        {
            foreach (var item in selectedDrinks)
            {
                hoaDonData.Rows.Add(item.MaSP, item.LoaiSP, item.TenMon, item.SoLuong, item.GiaSP.ToString() + " VNĐ");
            }
        }
    }
}
