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

namespace PBL3.GUI.Admin
{
    public partial class TaiKhoan : Form
    {
        private int maNV;

        public TaiKhoan()
        {
            InitializeComponent();
        }

        public TaiKhoan(int maNV)
        {
            this.maNV = maNV; InitializeComponent();
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);
            TKData.DataSource = TaiKhoan_BLL.Instance.GetListTaiKhoan(0, null);
            RefreshData();
        }
        private void RefreshData()
        {
            if (TKData.Columns["MaNV"] != null)
            {
                TKData.Columns["MaNV"].HeaderText = "Mã nhân viên";
            }   
            if (TKData.Columns["HoTenNV"] != null)
            {
                TKData.Columns["HoTenNV"].HeaderText = "Tên nhân viên";
            }
            if (TKData.Columns["TenDangNhap"] != null)
            {
                TKData.Columns["TenDangNhap"].HeaderText = "Tên tài khoản";
            }
            if (TKData.Columns["MatKhau"] != null)
            {
                TKData.Columns["MatKhau"].HeaderText = "Mật khẩu";
            }
        }


        private void addTK_Click(object sender, EventArgs e)
        {
            ThemTaiKhoan f = new ThemTaiKhoan(maNV);
            this.Hide();
            f.ShowDialog();
            this.Show();
            TKData.DataSource = TaiKhoan_BLL.Instance.GetListTaiKhoan(0, null);
        }

        private void editTK_Click(object sender, EventArgs e)
        {
            int Manv = 0;
            if(TKData.SelectedRows.Count == 0)
            {
                //MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f1 = new ThatBai("Vui lòng chọn nhân viên cần cập nhật thông tin");
                f1.ShowDialog();
                return;
            }
            Manv = Convert.ToInt32(TKData.SelectedRows[0].Cells["MaNV"].Value.ToString());
            SuaTaiKhoan f = new SuaTaiKhoan(Manv);
            this.Hide();
            f.ShowDialog();
            this.Show();
            TKData.DataSource = TaiKhoan_BLL.Instance.GetListTaiKhoan(0, null);
        }

        private void deleteTK_Click(object sender, EventArgs e)
        {
            if(TKData.SelectedRows.Count == 0)
            {
               // MessageBox.Show("Vui lòng chọn tài khoản cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f1 = new ThatBai("Vui lòng chọn tài khoản cần xóa");
                f1.ShowDialog();
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int MaNV = Convert.ToInt32(TKData.SelectedRows[0].Cells["MaNV"].Value.ToString());
                TaiKhoan_BLL.Instance.DeleteTaiKhoan(MaNV);  
                TKData.DataSource = TaiKhoan_BLL.Instance.GetListTaiKhoan(0, null);
                RefreshData();
            }

        }

       
        private void TKExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DangNhap dangNhap = new DangNhap();
                this.Hide();
                dangNhap.ShowDialog();
                this.Close();
            }
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            ManHinhChinh manHinhChinh = new ManHinhChinh(maNV);
            this.Hide();
            manHinhChinh.ShowDialog();
            this.Close();
        }
    }
}
