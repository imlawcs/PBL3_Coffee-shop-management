using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Remoting.Contexts;
using PBL3.BUS;
using Guna.UI2.WinForms;
using PBL3.DTO;
using PBL3.GUI.Admin;

namespace PBL3.GUI
{
    public partial class SuaMon : Form
    {
        private string duongdananh;
        private int maNV;
        private List<string> nhomdouong1 = new List<string>();
        private List<string> donvitinh1 = new List<string>();
        public SuaMon(int maNV)
        {
            InitializeComponent();
            nguyenLieu.DataSource = NguyenLieu_BLL.Instance.GetListNguyenLieu();
            this.maNV = maNV;
            Khoitaonhom();
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
        private void Khoitaonhom()
        {
            nhomdouong1.Add("Cà phê");
            nhomdouong1.Add("Trà");
            nhomdouong1.Add("Sữa chua");
            foreach (string s in nhomdouong1)
            {
                nhomthucdon.Items.Add(s);
            }
            donvitinh1.Add("Ly");
            donvitinh1.Add("Phần");
            foreach (string s in donvitinh1)
            {
                donvitinh.Items.Add(s);
            }

        }
        public void GetThongTin(int s)
        {
            string masp = maMon.Text;
            string tensp = tenMon.Text;
            string giasp = giaBan.Text;
            string loai = "";
            string nhom = "";
            string donvi = "";
            string duongdan = "";
            SanPham_BLL.Instance.LayThongTinSanPham(s, ref masp, ref tensp, ref giasp, ref loai, ref nhom, ref donvi, ref duongdan);
            maMon.Text = masp;
            tenMon.Text = tensp;
            giaBan.Text = giasp;
            if (nhomthucdon.Items.Contains(nhom))
            {
                nhomthucdon.SelectedItem = nhom;
            }
            else
            {
               // MessageBox.Show("Nhóm thực đơn chưa có trong danh sách");
                ThatBai f1 = new ThatBai("Nhóm thực đơn chưa có trong danh sách");
                f1.ShowDialog();
            }
            if (donvitinh.Items.Contains(donvi))
            {
                donvitinh.SelectedItem = donvi;
            }
            else
            {
                //MessageBox.Show("Đơn vị tính chưa có trong danh sách");
                ThatBai f1 = new ThatBai("Đơn vị tính chưa có trong danh sách");
                f1.ShowDialog();
            }
            if (loai == "Đồ uống")
                doUongRb.Checked = true;
            else monAnRb.Checked = true;
            anhDaiDien.ImageLocation = duongdan;
            this.duongdananh = duongdan;
            DataTable dt = new DataTable();
            dt.Columns.Add("MaNL");
            dt.Columns.Add("TenNL");
            dt.Columns.Add("SLNguyenLieu");
            dt.Columns.Add("DonViTinh");
            foreach (ChiTietSanPham t in ChiTietSanPham_BLL.Instance.GetListChiTietSanPhamByMaSP(Convert.ToInt32(masp)))
            {
                DTO.NguyenLieu p = NguyenLieu_BLL.Instance.GetNguyenLieu(t.MaNL);
                dt.Rows.Add(t.MaNL, p.TenNL, t.SLNguyenLieu, p.DonViTinh);
            }
            nguyenLieuData.DataSource = dt;
            if (nguyenLieuData.Columns["MaNL"] != null)
            {
                nguyenLieuData.Columns["MaNL"].HeaderText = "Mã nguyên liệu";
            }
            if (nguyenLieuData.Columns["TenNL"] != null)
            {
                nguyenLieuData.Columns["TenNL"].HeaderText = "Tên nguyên liệu";
            }
            if (nguyenLieuData.Columns["SLNguyenLieu"] != null)
            {
                nguyenLieuData.Columns["SLNguyenLieu"].HeaderText = "Số lượng trong sản phẩm";
            }
            if (nguyenLieuData.Columns["DonViTinh"] != null)
            {
                nguyenLieuData.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
            }

            /*nguyenLieuData.Columns.Add("MaNL", "Mã nguyên liệu");
            nguyenLieuData.Columns.Add("TenNL", "Tên nguyên liệu");
            nguyenLieuData.Columns.Add("SoLuong", "Số lượng trong sản phẩm");
            nguyenLieuData.Columns.Add("DonViTinh", "Đơn vị tính");

           foreach (ChiTietSanPham t in ChiTietSanPham_BLL.Instance.GetListChiTietSanPhamByMaSP(Convert.ToInt32(masp)))
           {
               DTO.NguyenLieu p = NguyenLieu_BLL.Instance.GetNguyenLieu(t.MaNL);
               nguyenLieuData.Rows.Add(t.MaNL, p.TenNL, t.SLNguyenLieu, p.DonViTinh);
           }*/

            /*nguyenLieuData.DataSource = ChiTietSanPham_BLL.Instance.GetDSChiTietSanPhamByMaSP(Convert.ToInt32(masp));
            if (nguyenLieuData.Columns["MaNL"] != null)
            {
                nguyenLieuData.Columns["MaNL"].HeaderText = "Mã nguyên liệu";
            }
            if (nguyenLieuData.Columns["TenNL"] != null)
            {
                nguyenLieuData.Columns["TenNL"].HeaderText = "Tên nguyên liệu";
            }
            if (nguyenLieuData.Columns["SLNguyenLieu"] != null)
            {
                nguyenLieuData.Columns["SLNguyenLieu"].HeaderText = "Số lượng trong sản phẩm";
            }
            if (nguyenLieuData.Columns["DonViTinh"] != null)
            {
                nguyenLieuData.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
            }*/
        }
        private void saveSP_Click(object sender, EventArgs e)
        {
            string s = giaBan.Text;
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                {
                    //MessageBox.Show("Giá bán sai định dạng. Chỉ chứa các kí tự số!");
                    ThatBai f1 = new ThatBai("Giá bán sai định dạng. Chỉ chứa các kí tự số!");
                    f1.ShowDialog();
                    return;
                }
            }
            string s1 = tenMon.Text;
            foreach (char c in s1)
            {
                if (char.IsDigit(c))
                {
                    //MessageBox.Show("Tên món sai định dạng. Không được chứa các kí tự số!");
                    ThatBai f1 = new ThatBai("Tên món sai định dạng. Không được chứa các kí tự số!");
                    f1.ShowDialog();
                    return;
                }
            }
            if (string.IsNullOrEmpty(duongdananh))
            {
                //MessageBox.Show("Vui lòng chọn ảnh cho sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ThatBai f1 = new ThatBai("Vui lòng chọn ảnh cho sản phẩm!");
                f1.ShowDialog();
                return;
            }
            string loai;
            if (doUongRb.Checked)
            {
                loai = "Đồ uống";
            }
            else loai = "Món ăn";
            string nhomtd = nhomthucdon.SelectedItem as string;
            if (string.IsNullOrEmpty(nhomtd))
            {
                //MessageBox.Show("Vui lòng chọn nhóm thực đơn");
                ThatBai f1 = new ThatBai("Vui lòng chọn nhóm thực đơn");
                f1.ShowDialog();
                return;
            }
            string donvidrink = donvitinh.SelectedItem as string;
            if (string.IsNullOrEmpty(donvidrink))
            {
                //MessageBox.Show("Vui lòng chọn đơn vị tính");
                ThatBai f1 = new ThatBai("Vui lòng chọn đơn vị tính");
                f1.ShowDialog();
                return;
            }
            SanPham_BLL.Instance.EditSanPham(maMon.Text, tenMon.Text, giaBan.Text, loai, nhomtd, donvidrink, duongdananh);
            ChiTietSanPham_BLL.Instance.DelChiTietSanPhamFromOneSP(Convert.ToInt32(maMon.Text));
            foreach (DataGridViewRow row in nguyenLieuData.Rows)
            {
                if (row == null) continue;
                if (row.Cells["MaNL"].Value == null) continue;
                int maNL = Convert.ToInt32(row.Cells["MaNL"].Value);
                decimal soLuong = Convert.ToDecimal(row.Cells["SLNguyenLieu"].Value);
                ChiTietSanPham_BLL.Instance.AddChiTietSanPham(Convert.ToInt32(maMon.Text), maNL, soLuong);
            }
            //MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ThanhCong f = new ThanhCong("Cập nhật sản phẩm thành công!");
            f.ShowDialog();
            Dispose();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void suaMonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nguyenLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //lấy dòng được chọn, thêm vào dinhluong
            int index = e.RowIndex;
            DataGridViewRow selectedRow = nguyenLieu.Rows[index];
            //kiểm tra đã có nguyên liệu này trong bảng định lượng chưa
            string manl = selectedRow.Cells[0].Value.ToString();
            bool daTonTai = false;
            if (nguyenLieuData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in nguyenLieuData.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (row.Cells[0].Value.ToString() == manl)
                        {
                            //MessageBox.Show("Nguyên liệu đã tồn tại trong bảng định lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ThatBai f1 = new ThatBai("Nguyên liệu đã tồn tại trong bảng định lượng!");
                            f1.ShowDialog();
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

                        DataTable dt = (DataTable)nguyenLieuData.DataSource;
                        dt.Rows.Add(manl, tennl, soLuong, donvi);
                        nguyenLieuData.DataSource = dt;
                    }
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ThemNguyenLieu f = new ThemNguyenLieu(this.maNV);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (nguyenLieuData.SelectedRows.Count == 0)
            {
                //MessageBox.Show("Vui lòng chọn nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ThatBai f1 = new ThatBai("Vui lòng chọn nguyên liệu");
                f1.ShowDialog();
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nguyên liệu này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (nguyenLieuData.SelectedRows.Count > 0)
                {
                    DataTable dt = (DataTable)nguyenLieuData.DataSource;
                    foreach (DataGridViewRow i in nguyenLieuData.SelectedRows)
                    {
                        if (i.Cells[0].Value == null)
                            return;
                        int maNL = Convert.ToInt32(i.Cells["MaNL"].Value);
                        DataRow[] rowsToDelete = Bonus_BLL.Instance.GetRowsNL(dt, maNL);
                        foreach (DataRow rowToDelete in rowsToDelete)
                        {
                            dt.Rows.Remove(rowToDelete);
                        }
                        /*foreach (DataRow j in dt.Rows)
                        {
                            if (Convert.ToInt32(j["MaNL"].ToString()) == Convert.ToInt32(i.Cells[0].Value.ToString()))
                            {
                                dt.Rows.Remove(j);
                            }    
                        }*/
                        nguyenLieuData.DataSource = dt;
                    }
                    //nguyenLieuData.DataSource = SanPham_BLL.Instance.GetListObjectSanPham();
                }

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (nguyenLieuData.SelectedRows.Count != 1)
            {
                //MessageBox.Show("Hãy chọn 1 nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ThatBai f1 = new ThatBai("Hãy chọn 1 nguyên liệu");
                f1.ShowDialog();
                return;
            }
            if (nguyenLieuData.SelectedRows.Count == 1)
            {
                if (nguyenLieuData.SelectedRows[0].Cells[0].Value == null)
                    return;
                DataGridViewRow selectedRow = nguyenLieuData.SelectedRows[0];
                int manl = Convert.ToInt32(nguyenLieuData.SelectedRows[0].Cells["MaNL"].Value.ToString());
                string tennl = nguyenLieuData.SelectedRows[0].Cells["TenNL"].Value.ToString();
                string donvi = nguyenLieuData.SelectedRows[0].Cells["DonViTinh"].Value.ToString();
                using (var dialog = new NhapSoLuongNguyenLieuDialog(manl, tennl))
                {
                    var result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        decimal soLuong = dialog.SoLuong;
                        DataTable dt = (DataTable)nguyenLieuData.DataSource;
                        foreach (DataGridViewRow i in nguyenLieuData.SelectedRows)
                        {
                            int maNL = Convert.ToInt32(i.Cells["MaNL"].Value);
                            DataRow[] rowsToDelete = Bonus_BLL.Instance.GetRowsNL(dt, maNL);
                            foreach (DataRow rowToDelete in rowsToDelete)
                            {
                                dt.Rows.Remove(rowToDelete);
                            }
                        }
                        dt.Rows.Add(manl, tennl, soLuong, donvi);
                        nguyenLieuData.DataSource = dt;

                    }
                }
            }
        }

        private void xoaAnh_Click(object sender, EventArgs e)
        {
            if (duongdananh == null)
            {
                //MessageBox.Show("Chưa có ảnh để xóa");
                ThatBai f1 = new ThatBai("Chưa có ảnh để xóa");
                f1.ShowDialog();
                return;
            }
            duongdananh = null;
            anhDaiDien.Image = null;
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
    }    
}