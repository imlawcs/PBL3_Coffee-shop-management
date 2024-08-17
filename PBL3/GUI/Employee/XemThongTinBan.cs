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

namespace PBL3.GUI.Employee
{
    public partial class XemThongTinBan : Form
    {
        public XemThongTinBan()
        {
            InitializeComponent();
        }

        public XemThongTinBan(int maBan)
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            MaBan.Visible = false;
            TrangThai.Visible = false;
            ViTri.Visible = false;
            NhanVienPhucVu.Visible = false;
            MaBan.Text = Ban_BLL.Instance.GetBan(1).MaBan.ToString();
            TrangThai.Text = Ban_BLL.Instance.GetBan(1).TrangThai;
            ViTri.Text = Ban_BLL.Instance.GetBan(1).ViTri;
            //nhanvien
            MaBan.Visible = true;
            TrangThai.Visible = true;
            ViTri.Visible = true;
            NhanVienPhucVu.Visible = true;
        }

        private void exit_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DangNhap dangNhap = new DangNhap();
                this.Hide();
                dangNhap.ShowDialog();
                this.Close();
            }
        }

        private void menu_Click(object sender, EventArgs e)
        {
            ManHinhChinh_NV manHinhChinh = new ManHinhChinh_NV();
            this.Hide();
            manHinhChinh.ShowDialog();
            this.Close();
        }
    }
}
