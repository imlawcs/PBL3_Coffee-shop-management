using PBL3.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.GUI.Employee
{
    public partial class DatBan : Form
    {
        private int maNV;

        public DatBan()
        {
            InitializeComponent();
            if (Ban_BLL.Instance.GetListBanFree().Count == 0)
            {
                //MessageBox.Show("Không có bàn trống");
                ThatBai f3 = new ThatBai("Không có bàn trống");
                f3.ShowDialog();
                this.Close();
            }

            RefreshData();

        }

        public DatBan(int maNV, int maBan)
        {
            InitializeComponent();
            
            this.maNV = maNV;

            datBanData.DataSource = Ban_BLL.Instance.GetBanByID(maBan);
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);

            if (datBanData.Columns["MaBan"] != null)
                datBanData.Columns["MaBan"].HeaderText = "Mã Bàn";
            if (datBanData.Columns["TrangThai"] != null)
                datBanData.Columns["TrangThai"].HeaderText = "Trạng Thái";
            if (datBanData.Columns["ViTri"] != null)
                datBanData.Columns["ViTri"].HeaderText = "Vị Trí";
        }


        public DatBan(int maNV)
        {
            if (Ban_BLL.Instance.GetListBanFree().Count == 0)
            {
                //MessageBox.Show("Không có bàn trống");
                ThatBai f3 = new ThatBai("Không có bàn trống");
                f3.ShowDialog();
                this.Close();
            }

            InitializeComponent();
            this.maNV = maNV;
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);
            RefreshData();
        }

        private void RefreshData()
        {
            datBanData.DataSource = Ban_BLL.Instance.GetListBanFree();
            if (datBanData.Columns["MaBan"] != null)
            datBanData.Columns["MaBan"].HeaderText = "Mã Bàn";
            if (datBanData.Columns["TrangThai"] != null)
            datBanData.Columns["TrangThai"].HeaderText = "Trạng Thái";
            if (datBanData.Columns["ViTri"] != null)
            datBanData.Columns["ViTri"].HeaderText = "Vị Trí";
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!sdt.Text.All(char.IsDigit))
            {
                //MessageBox.Show("Số điện thoại phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f3 = new ThatBai("Số điện thoại phải là số");
                f3.ShowDialog();
                return;
            }
            if (sdt.Text.Length != 10)
            {
                //MessageBox.Show("Số điện thoại phải có 10 chữ số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f3 = new ThatBai("Số điện thoại phải có 10 chữ số");
                f3.ShowDialog();
                return;
            }
            if (datBanData.SelectedRows.Count == 0)
            {
               // MessageBox.Show("Vui lòng chọn bàn");
                ThatBai f3 = new ThatBai("Vui lòng chọn bàn");
                f3.ShowDialog();
            }
            else
            {
                int MaBan = Convert.ToInt32(datBanData.SelectedRows[0].Cells["MaBan"].Value);
                string TrangThai = "Bàn đã được đặt trước";
                string SDT = sdt.Text;
                Ban_BLL.Instance.EditBan(MaBan, TrangThai,SDT);
                //MessageBox.Show("Đặt bàn thành công");
                ThanhCong f = new ThanhCong("Đặt bàn thành công");
                f.ShowDialog();
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                DangNhap f = new DangNhap();
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
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
