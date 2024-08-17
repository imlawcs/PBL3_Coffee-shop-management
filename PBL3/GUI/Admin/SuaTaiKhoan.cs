using Guna.UI2.WinForms;
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
    public partial class SuaTaiKhoan : Form
    {
        private int maNV1;

        public SuaTaiKhoan()
        {
            InitializeComponent();
        }

        public SuaTaiKhoan(int maNV1)
        {
            this.maNV1 = maNV1;
            InitializeComponent();
            maNV.Text= maNV1.ToString();
            tenTK.Text = TaiKhoan_BLL.Instance.getTenTK(maNV1);
            password.Text = TaiKhoan_BLL.Instance.getPass(maNV1);
        }



        private void SaveTK_Click(object sender, EventArgs e)
        {
            if(tenTK.Text == "" || password.Text == "")
            {
               // MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f1 = new ThatBai("Vui lòng nhập đầy đủ thông tin!");
                f1.ShowDialog();
                return;
            }
            TaiKhoan_BLL.Instance.EditTaiKhoan(maNV.Text, tenTK.Text, password.Text);
            //MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ThanhCong f = new ThanhCong("Cập nhật tài khoản thành công!");
            f.ShowDialog();
            Dispose();
        }

        private void cancelTK_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void suaTKExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
