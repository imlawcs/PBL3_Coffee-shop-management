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
    public partial class SuaNhanVien : Form
    {
        public SuaNhanVien(int maNV)
        {
            InitializeComponent();
            setCBB1();
            setCBB2();
            DTO.NhanVien nv = NhanVien_BLL.Instance.GetNhanVien(maNV);
            this.maNV.Text = maNV.ToString();
            this.tenNV.Text = nv.HoTenNV;
            this.ngaySinh.Value = (DateTime)nv.NgaySinh;
            this.soDienThoai.Text = nv.SDT;
            this.luong.Text = nv.Luong.ToString();
            this.maCV.SelectedItem = nv.MaCV.ToString();
            this.gender.SelectedItem = (nv.GioiTinh==true)?"Nữ":"Nam";
            note.DataSource = ChucVu_BLL.Instance.GetListChucVu();
            note.Columns["MaCV"].HeaderText = "Mã chức vụ";
            note.Columns["TenCV"].HeaderText = "Tên chức vụ";
        }
        public void setCBB1()
        {
            maCV.Items.Add("1");
            maCV.Items.Add("2");
            maCV.Items.Add("3");
            maCV.Items.Add("4");
        }
        public void setCBB2()
        {
            gender.Items.Add("Nam");
            gender.Items.Add("Nữ");
        }

        private void saveNV_Click(object sender, EventArgs e)
        {
            NhanVien_BLL.Instance.EditNhanVien(maNV.Text, tenNV.Text, ngaySinh.Value, soDienThoai.Text, luong.Text, maCV.SelectedItem.ToString(), gender.SelectedItem.ToString());
            //MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ThanhCong f = new ThanhCong("Cập nhật nhân viên thành công!");
            f.ShowDialog();
            Dispose();
        }

        private void cancelNV_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void suaNVExit_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
