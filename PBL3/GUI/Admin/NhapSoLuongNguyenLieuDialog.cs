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
    public partial class NhapSoLuongNguyenLieuDialog : Form
    {
        public decimal SoLuong { get; private set; }
        private int manl;
        public NhapSoLuongNguyenLieuDialog(int manl, string tenNL)
        {
            InitializeComponent();
            label1.Text = "Nhập số lượng nguyên liệu cho " + tenNL;
            this.manl = manl;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(textBox1.Text, out decimal soLuong) || Convert.ToDecimal(textBox1.Text) < 0)
            {
                //MessageBox.Show("Vui lòng nhập số lượng hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f1 = new ThatBai("Vui lòng nhập số lượng hợp lệ!");
                f1.ShowDialog();
                return;
            }

            SoLuong = soLuong;
            if (SoLuong > NguyenLieu_BLL.Instance.GetNLbymaNL(manl).SLTonKho)
            {
                //MessageBox.Show("Số lượng nhập vượt quá số lượng tồn kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f1 = new ThatBai("Số lượng nhập vượt quá số lượng tồn kho!");
                f1.ShowDialog();
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
