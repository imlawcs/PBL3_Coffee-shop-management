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
    public partial class ThemNhanVien : Form
    {
        public ThemNhanVien()
        {
            InitializeComponent();
            setCBB1();
            setCBB2();
            chucVu.DataSource=ChucVu_BLL.Instance.GetListChucVu();
            if (chucVu.Columns["MaCV"] != null)
                chucVu.Columns["MaCV"].HeaderText = "Mã chức vụ";
            if (chucVu.Columns["TenCV"] != null)
                chucVu.Columns["TenCV"].HeaderText = "Tên chức vụ";
        }
        public void setCBB1()
        {
            maChucVu.Items.Add("1");
            maChucVu.Items.Add("2");
            maChucVu.Items.Add("3");
            maChucVu.Items.Add("4");
        }
        public void setCBB2()
        {
            gioiTinh.Items.Add("Nam");
            gioiTinh.Items.Add("Nữ");
        }



        private void saveNV_Click(object sender, EventArgs e)
        {
            if (tenNV.Text == "" || sdt.Text == "" || luong.Text == "" || gioiTinh.Text == "" || maChucVu.Text == ""||luong.Text=="")
            {
                //MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ThatBai f3 = new ThatBai("Vui lòng nhập đầy đủ thông tin!");
                f3.ShowDialog();
                return;
            }
            if(ngaySinh.Value>DateTime.Now)
            {
               // MessageBox.Show("Ngày sinh không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ThatBai f3 = new ThatBai("Ngày sinh không hợp lệ!");
                f3.ShowDialog();
                return;
            }
            if(sdt.Text.Length!=10)
            {
               // MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ThatBai f3 = new ThatBai("Số điện thoại không hợp lệ!");
                f3.ShowDialog();
                return;
            }
            NhanVien_BLL.Instance.AddNhanVien(int.Parse(maChucVu.Text), tenNV.Text, ngaySinh.Value, sdt.Text, gioiTinh.Text, int.Parse(luong.Text));
            //MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ThanhCong f = new ThanhCong("Thêm nhân viên thành công!");
            f.ShowDialog();
            Dispose();
        }

        private void huy_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
