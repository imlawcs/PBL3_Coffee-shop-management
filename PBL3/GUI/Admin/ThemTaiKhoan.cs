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

namespace PBL3.GUI.Admin
{
    public partial class ThemTaiKhoan : Form
    {
        private int maNV1;

        public ThemTaiKhoan()
        {
            InitializeComponent();
        }

        public ThemTaiKhoan(int maNV1)
        {
            this.maNV1 = maNV1;
            InitializeComponent();
            adtndata.DataSource=NhanVien_BLL.Instance.getListQLTN();
            RefreshData();
            setCb();
        }

        private void setCb()
        {
            foreach (DataGridViewRow row in adtndata.Rows)
            {
                mnvcb.Items.Add(row.Cells["MaNV"].Value.ToString());
            }
        }

        private void RefreshData()
        {
            if (adtndata.Columns["MaNV"] != null)
            {
                adtndata.Columns["MaNV"].HeaderText = "Mã nhân viên";
            }
            if (adtndata.Columns["HoTenNV"] != null)
            {
                adtndata.Columns["HoTenNV"].HeaderText = "Tên nhân viên";
            }
            if (adtndata.Columns["ChucVu"] != null)
            {
                adtndata.Columns["ChucVu"].HeaderText = "Chức vụ";
            }
           
        }

        private void saveTK_Click(object sender, EventArgs e)
        {
            if (mnvcb.Text == "" || tenTK.Text == "" || matKhau.Text == "")
            {
                //MessageBox.Show("Vui lòng nhập đủ thông tin");
                ThatBai f3 = new ThatBai("Vui lòng nhập đủ thông tin");
                f3.ShowDialog();
                return;
            }
            if (TaiKhoan_BLL.Instance.CheckTaiKhoan(tenTK.Text, NhanVien_BLL.Instance.getmaCV(Convert.ToInt32(mnvcb.Text)).ToString()))
            {
               // MessageBox.Show("Tên tài khoản đã tồn tại");
                ThatBai f3 = new ThatBai("Tên tài khoản đã tồn tại");
                f3.ShowDialog();
                return;
            }
            else
            {
                TaiKhoan_BLL.Instance.AddTaiKhoan(mnvcb.Text, tenTK.Text, matKhau.Text);
                //MessageBox.Show("Thêm tài khoản thành công");
                ThanhCong f = new ThanhCong("Thêm tài khoản thành công");
                f.ShowDialog();
                Dispose();
            }
        }

        private void huyTK_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
