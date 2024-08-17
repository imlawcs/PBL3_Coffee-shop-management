using PBL3.BUS;
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

namespace PBL3.GUI.Employee
{
    public partial class CapNhatMatKhau : Form
    {
        private int maNV1;

        public CapNhatMatKhau()
        {
            InitializeComponent();
        }

        public CapNhatMatKhau(int maNV1)
        {
            this.maNV1 = maNV1;
            InitializeComponent();
            tenTK.Text = TaiKhoan_BLL.Instance.getTenTK(maNV1);
        }

       
        

        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            int maCV = NhanVien_BLL.Instance.getmaCV(maNV1);
            if (maCV == 1)
            {
                ManHinhChinh manHinhChinh = new ManHinhChinh(maNV1);
                this.Hide();
                manHinhChinh.ShowDialog();
                this.Close();

            }
            else
            {
                ManHinhChinh_NV manHinhChinh = new ManHinhChinh_NV(maNV1);
                this.Hide();
                manHinhChinh.ShowDialog();
                this.Close();
            }
        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            if (matKhauMoi.Text.Equals("") || matKhauCu.Text.Equals("") || nhapLaiMK.Text.Equals(""))
            {
                //MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                ThatBai f3 = new ThatBai("Vui lòng nhập đầy đủ thông tin");
                f3.ShowDialog();
                return;
            }
            TaiKhoan_BLL.Instance.EditTaiKhoanNV(maNV1.ToString(), matKhauCu.Text, tenTK.Text, matKhauMoi.Text, nhapLaiMK.Text);
            ManHinhChinh_NV manHinhChinh = new ManHinhChinh_NV(maNV1);
            this.Hide();
            manHinhChinh.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cancelButton_Click_1(sender, e);
        }
    }
}
