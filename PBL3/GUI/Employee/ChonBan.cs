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
    public partial class ChonBan : Form
    {
        private int maNV, maDH, maKH, maBan;
        private List<SelectedDrink> selectedDrinks;
        public ChonBan(int maNV, List<SelectedDrink> selectedDrinks, int maDH)
        {
            this.maNV = maNV;
            this.maDH = maDH;
            InitializeComponent();
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);

            this.selectedDrinks = selectedDrinks;
            guna2DataGridView2.Columns.Add("MaSP", "Mã sản phẩm");
            guna2DataGridView2.Columns.Add("LoaiSP", "Loại sản phẩm");
            guna2DataGridView2.Columns.Add("Name", "Tên sản phẩm");
            guna2DataGridView2.Columns.Add("Quantity", "Số lượng");
            ShowDB();
            if (Ban_BLL.Instance.GetListBanFree().Count == 0)
            {
                //MessageBox.Show("Không có bàn trống");
                ThatBai f3 = new ThatBai("Không có bàn trống");
                f3.ShowDialog();
                //this.Close();
            }

            RefreshData();
        }
        public ChonBan(int maNV, List<SelectedDrink> selectedDrinks, int maDH, int maKH, int maBan)
        {
            this.maNV = maNV;
            this.maDH = maDH;
            this.maKH = maKH;
            this.maBan = maBan;
            //Ban_BLL.Instance.EditBan(maBan, "Bàn trống");
            InitializeComponent();
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);

            this.selectedDrinks = selectedDrinks;
            guna2DataGridView2.Columns.Add("MaSP", "Mã sản phẩm");
            guna2DataGridView2.Columns.Add("LoaiSP", "Loại sản phẩm");
            guna2DataGridView2.Columns.Add("Name", "Tên sản phẩm");
            guna2DataGridView2.Columns.Add("Quantity", "Số lượng");
            ShowDB();
            if (Ban_BLL.Instance.GetListBanFree().Count == 0)
            {
                //MessageBox.Show("Không có bàn trống");
                ThatBai f3 = new ThatBai("Không có bàn trống");
                f3.ShowDialog();
                //this.Close();
            }
            if (maBan != 0)
            {
                Ban_BLL.Instance.EditBan(maBan, "Bàn trống");
                DTO.KhachHang k = KhachHang_BLL.Instance.GetKHbyMaKH(this.maKH);
                Ban_BLL.Instance.Changesdt(maBan, "");
            }

            RefreshData();
        }
        public void ShowDB()
        {
            foreach (var item in selectedDrinks)
            {
                guna2DataGridView2.Rows.Add(item.MaSP, item.LoaiSP, item.TenMon, item.SoLuong);
            }
        }
        private void RefreshData()
        {
            dataGridView1.DataSource = Ban_BLL.Instance.GetListBanFree();
            dataGridView1.Columns["MaBan"].HeaderText = "Mã Bàn";
            dataGridView1.Columns["TrangThai"].HeaderText = "Trạng Thái";
            dataGridView1.Columns["ViTri"].HeaderText = "Vị Trí";
        }

        private void ChonBan_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //Xóa nx ĐH mới tạo
            //DonHang_BLL.Instance.DelDonHang(maDH);

            //ThemMon f = new ThemMon(maNV, selectedDrinks);
            //Thanh f = new Thanh(maNV, selectedDrinks, maDH, maKH);
            //f.Show();
            if (maBan != 0)
            {
                string TrangThai = "Bàn bận";
                Ban_BLL.Instance.EditBan(maBan, TrangThai);
                DTO.KhachHang k = KhachHang_BLL.Instance.GetKHbyMaKH(this.maKH);
                Ban_BLL.Instance.Changesdt(maBan, k.SDT);
            }
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ManHinhChinh_NV manHinhChinh = new ManHinhChinh_NV(maNV);
            this.Hide();
            manHinhChinh.ShowDialog();
            this.Close();
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
               // MessageBox.Show("Vui lòng chọn bàn");
                ThatBai f3 = new ThatBai("Vui lòng chọn bàn");
                f3.ShowDialog();
            }
            else
            {
                int MaBan = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MaBan"].Value);
                string TrangThai = "Bàn bận";
                Ban_BLL.Instance.EditBan(MaBan, TrangThai, KhachHang_BLL.Instance.getSDTKH(maKH));

                //MessageBox.Show("Đặt bàn thành công");
                ThanhCong f = new ThanhCong("Đặt bàn thành công");
                f.ShowDialog();
                this.Close();
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
    }
}
