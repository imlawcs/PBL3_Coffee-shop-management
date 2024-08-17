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
using static System.Net.Mime.MediaTypeNames;

namespace PBL3.GUI.Admin
{
    public partial class NhanVien : Form
    {
        private int maNV;

        public NhanVien()
        {
            InitializeComponent();
        }

        private void RefreshData()
        {
            if (NVData.Columns["MaNV"] != null)
                NVData.Columns["MaNV"].HeaderText = "Mã nhân viên";
            if (NVData.Columns["HoTenNV"] != null)
                NVData.Columns["HoTenNV"].HeaderText = "Họ tên nhân viên";
            if (NVData.Columns["ChucVu"] != null)
                NVData.Columns["ChucVu"].HeaderText = "Chức vụ";
            if (NVData.Columns["NgaySinh"] != null)
                NVData.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            if (NVData.Columns["GioiTinh"] != null)
                NVData.Columns["GioiTinh"].HeaderText = "Giới tính";
            if (NVData.Columns["Luong"] != null)
                NVData.Columns["Luong"].HeaderText = "Lương";
        }

        public NhanVien(int maNV)
        {
            this.maNV = maNV;
            InitializeComponent();
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);

            NVData.DataSource = NhanVien_BLL.Instance.GetListNhanVien(0, null);
            RefreshData();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {

            NVData.DataSource = NhanVien_BLL.Instance.GetListNhanVien(0, null);
        }

        private void addNV_Click(object sender, EventArgs e)
        {
            ThemNhanVien f = new ThemNhanVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
            NVData.DataSource = NhanVien_BLL.Instance.GetListNhanVien(0, null);
            RefreshData();
        }

        private void editNV_Click(object sender, EventArgs e)
        {
            int Manv = 0;
            if(NVData.SelectedRows.Count == 0)
            {
                //MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f1 = new ThatBai("Vui lòng chọn nhân viên cần sửa!");
                f1.ShowDialog();
                return;
            }
            if (NVData.SelectedRows.Count == 1)
            {

                Manv = Convert.ToInt32(NVData.SelectedRows[0].Cells["MaNV"].Value.ToString());
            }
            SuaNhanVien f = new SuaNhanVien(Manv);
            this.Hide();
            f.ShowDialog();
            this.Show();
            NVData.DataSource = NhanVien_BLL.Instance.GetListNhanVien(0, null);
            RefreshData();
        }

        private void deleteNV_Click(object sender, EventArgs e)
        {
            if(NVData.SelectedRows.Count == 0)
            {
                //MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f1 = new ThatBai("Vui lòng chọn nhân viên cần xóa!");
                f1.ShowDialog();
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                
                int MaNV = Convert.ToInt32(NVData.SelectedRows[0].Cells["MaNV"].Value.ToString());
                NhanVien_BLL.Instance.DeleteNV(MaNV);
                   
                NVData.DataSource = NhanVien_BLL.Instance.GetListNhanVien(0, null);
                RefreshData();
                
            }
        }

        private void searchNV_Click(object sender, EventArgs e)
        {
            if(nameNVTb.Text == "")
            {
                //MessageBox.Show("Vui lòng nhập tên nhân viên cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f1 = new ThatBai("Vui lòng nhập tên nhân viên cần tìm!");
                f1.ShowDialog();
                return;
            }
            string txt = nameNVTb.Text;
            NVData.DataSource = NhanVien_BLL.Instance.GetListNhanVien(0, txt);
            if(NVData.Rows.Count == 0)
            {
                //MessageBox.Show("Không tìm thấy nhân viên được yêu cầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f1 = new ThatBai("Không tìm thấy nhân viên được yêu cầu!");
                f1.ShowDialog();
            }
            RefreshData();
        }

        private void exitNV_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ManHinhChinh manHinhChinh = new ManHinhChinh(maNV);
            this.Hide();
            manHinhChinh.ShowDialog();
            this.Close();
        }

        private void dsnvbt_Click(object sender, EventArgs e)
        {
            NVData.DataSource = NhanVien_BLL.Instance.GetListNhanVien(0, null);
            RefreshData();
        }

        private void enter(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                searchNV_Click(sender, e);
            }
        }
    }
}
