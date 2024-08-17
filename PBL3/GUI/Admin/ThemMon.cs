using Guna.UI2.WinForms;
using PBL3.BUS;
using PBL3.DTO;
using PBL3.GUI.Admin;
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

namespace PBL3.GUI
{
    public partial class ThemMon : Form
    {
        private string duongdananh;
        private int maNV;
        private List<string> nhomdouong = new List<string>();
        private List<string> donvitinh = new List<string>();
        public ThemMon()
        {
            InitializeComponent();
            nguyenLieu.DataSource = NguyenLieu_BLL.Instance.GetListNguyenLieu();
            DataTable dt = new DataTable();
            dt.Columns.Add("MaNL");
            dt.Columns.Add("TenNL");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("DonViTinh");
            dinhLuong.DataSource = dt;

        }

        public ThemMon(int maNV)
        {
            this.maNV = maNV;
            InitializeComponent();
            nguyenLieu.DataSource = NguyenLieu_BLL.Instance.GetListNguyenLieu();
            DataTable dt = new DataTable();
            dt.Columns.Add("MaNL");
            dt.Columns.Add("TenNL");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("DonViTinh");
            dinhLuong.DataSource = dt;

            if (nguyenLieu.Columns["MaNL"] != null)
            {
                nguyenLieu.Columns["MaNL"].HeaderText = "Mã nguyên liệu";
            }
            if (nguyenLieu.Columns["TenNL"] != null)
            {
                nguyenLieu.Columns["TenNL"].HeaderText = "Tên nguyên liệu";
            }
            if (nguyenLieu.Columns["SLTonKho"] != null)
            {
                nguyenLieu.Columns["SLTonKho"].HeaderText = "Số lượng tồn kho";
            }
            if (nguyenLieu.Columns["DonViTinh"] != null)
            {
                nguyenLieu.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
            }

            if (dinhLuong.Columns["MaNL"] != null)
            {
                dinhLuong.Columns["MaNL"].HeaderText = "Mã nguyên liệu";
            }
            if (dinhLuong.Columns["TenNL"] != null)
            {
                dinhLuong.Columns["TenNL"].HeaderText = "Tên nguyên liệu";
            }
            if (dinhLuong.Columns["SoLuong"] != null)
            {
                dinhLuong.Columns["SoLuong"].HeaderText = "Số lượng trong sản phẩm";
            }
            if (dinhLuong.Columns["DonViTinh"] != null)
            {
                dinhLuong.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
            }
            maMon.Text = Convert.ToString(SanPham_BLL.Instance.GetnextmaSP());
            Khoitaonhom();
        }
        private void Khoitaonhom()
        {
            nhomdouong.Add("Cà phê");
            nhomdouong.Add("Trà");
            nhomdouong.Add("Sữa chua");
            foreach (string s in nhomdouong)
            {
                Nhomthucdon.Items.Add(s);
            }
            donvitinh.Add("Ly");
            donvitinh.Add("Phần");
            foreach (string s in donvitinh)
            {
                donvi.Items.Add(s);
            }

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //lấy dòng được chọn, thêm vào dinhluong
            int index = e.RowIndex;
            DataGridViewRow selectedRow = nguyenLieu.Rows[index];
            //kiểm tra đã có nguyên liệu này trong bảng định lượng chưa
            string manl = selectedRow.Cells[0].Value.ToString();
            bool daTonTai = false;
            if (dinhLuong.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dinhLuong.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (row.Cells[0].Value.ToString() == manl)
                        {
                            //MessageBox.Show("Nguyên liệu đã tồn tại trong bảng định lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ThatBai f3 = new ThatBai("Nguyên liệu đã tồn tại trong bảng định lượng!");
                            f3.ShowDialog();
                            daTonTai = true;
                            return;
                        }
                    }
                }
            }

            string tennl = selectedRow.Cells[1].Value.ToString();
            string donvi = selectedRow.Cells[3].Value.ToString();
            if (!daTonTai)
            {
                using (var dialog = new NhapSoLuongNguyenLieuDialog(Convert.ToInt32(manl), tennl))
                {
                    var result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        decimal soLuong = dialog.SoLuong;

                        DataTable dt = (DataTable)dinhLuong.DataSource;
                        dt.Rows.Add(manl, tennl, soLuong, donvi);
                        dinhLuong.DataSource = dt;
                    }
                }
            }

        }
        private void saveSP_Click(object sender, EventArgs e)
        {
            string s = giaBan.Text;

            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                {
                    //MessageBox.Show("Giá bán không hợp lệ!");
                    ThatBai f3 = new ThatBai("Giá bán không hợp lệ!");
                    f3.ShowDialog();
                    return;
                }
            }
            string s1 = tenMon.Text;
            if (s1 == "")
            {
                //MessageBox.Show("Tên món không được trống!");
                ThatBai f3 = new ThatBai("Tên món không được trống!");
                f3.ShowDialog();
                return;
            }   
            if (SanPham_BLL.Instance.CheckTrungName(s1))
            {
                //MessageBox.Show("Tên món không được trống!");
                ThatBai f3 = new ThatBai("Tên món không được trống!");
                f3.ShowDialog();
                return;
            }    
            foreach (char c in s1)
            {
                if (char.IsDigit(c))
                {
                    //MessageBox.Show("Tên món sai định dạng. Không được chứa các kí tự số!");
                    ThatBai f3 = new ThatBai("Tên món sai định dạng. Không được chứa các kí tự số!");
                    f3.ShowDialog();
                    return;
                }
            }
            if (string.IsNullOrEmpty(duongdananh))
            {
                //MessageBox.Show("Vui lòng chọn ảnh cho sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ThatBai f3 = new ThatBai("Vui lòng chọn ảnh cho sản phẩm!");
                f3.ShowDialog();
                return;
            }
            if (dinhLuong.Rows.Count == 1)
            {
                //MessageBox.Show("Vui lòng thêm nguyên liệu vào bảng định lượng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ThatBai f3 = new ThatBai("Vui lòng thêm nguyên liệu vào bảng định lượng!");
                f3.ShowDialog();
                return;
            }
            string masp = Convert.ToString(SanPham_BLL.Instance.GetnextmaSP());
            string loai;
            if (doUongRb.Checked)
            {
                loai = "Đồ uống";
            }
            else loai = "Món ăn";
            string nhomtd = Nhomthucdon.SelectedItem as string;
            if (string.IsNullOrEmpty(nhomtd))
            {
                //MessageBox.Show("Vui lòng chọn nhóm thực đơn");
                ThatBai f3 = new ThatBai("Vui lòng chọn nhóm thực đơn");
                f3.ShowDialog();
                return;
            }
            string donvidrink = donvi.SelectedItem as string;
            if (string.IsNullOrEmpty(donvidrink))
            {
               // MessageBox.Show("Vui lòng chọn đơn vị tính");
                ThatBai f3 = new ThatBai("Vui lòng chọn đơn vị tính");
                f3.ShowDialog();
                return;
            }
            SanPham_BLL.Instance.AddSanPham(masp, tenMon.Text, giaBan.Text, loai, nhomtd, donvidrink, duongdananh);
            foreach (DataGridViewRow row in dinhLuong.Rows)
            {
                if (row == null) continue;
                if (row.Cells["MaNL"].Value == null) continue;
                int maNL = Convert.ToInt32(row.Cells["MaNL"].Value);
                decimal soLuong = Convert.ToDecimal(row.Cells["SoLuong"].Value);
                ChiTietSanPham_BLL.Instance.AddChiTietSanPham(Convert.ToInt32(masp), maNL, soLuong);
            }
            //MessageBox.Show("Thêm món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ThanhCong f = new ThanhCong("Thêm món thành công!");
            f.ShowDialog();
            Dispose();
        }

        private void cancelSP_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void themAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif) | *.jpg; *.jpeg; *.png; *.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                duongdananh = openFileDialog.FileName;
                anhDaiDien.ImageLocation = duongdananh;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void xoaAnh_Click(object sender, EventArgs e)
        {
            if (duongdananh == null)
            {
                //MessageBox.Show("Chưa có ảnh để xóa");
                ThatBai f3 = new ThatBai("Chưa có ảnh để xóa");
                f3.ShowDialog();
                return;
            }
            duongdananh = null;
            anhDaiDien.Image = null;
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ThemNguyenLieu f = new ThemNguyenLieu(this.maNV);
            this.Hide();
            f.ShowDialog();
            this.Show();
            nguyenLieu.DataSource = NguyenLieu_BLL.Instance.GetListNguyenLieu();
            if (nguyenLieu.Columns["MaNL"] != null)
            {
                nguyenLieu.Columns["MaNL"].HeaderText = "Mã nguyên liệu";
            }
            if (nguyenLieu.Columns["TenNL"] != null)
            {
                nguyenLieu.Columns["TenNL"].HeaderText = "Tên nguyên liệu";
            }
            if (nguyenLieu.Columns["SLTonKho"] != null)
            {
                nguyenLieu.Columns["SLTonKho"].HeaderText = "Số lượng tồn kho";
            }
            if (nguyenLieu.Columns["DonViTinh"] != null)
            {
                nguyenLieu.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
            }
        }
    }
}
