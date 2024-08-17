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
    public partial class SuaKhachHang : Form
    {
        private string MaKH;
        private string TenKH;
        private string Sdt;
        private string MaLKH;
        public SuaKhachHang(string maKH, string tenKH, string sdt, string maLKH)
        {
            this.MaKH = maKH;
            this.TenKH = tenKH;
            this.Sdt = sdt;
            this.MaLKH = maLKH;
            InitializeComponent();
            tenKhachHang.Text = tenKH;
            sdtKH.Text = sdt;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(tenKhachHang.Text == "" || sdtKH.Text == "")
            {
                //MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f3 = new ThatBai("Vui lòng nhập đầy đủ thông tin");
                f3.ShowDialog();
                return;
            }
            if(sdtKH.Text.Length != 10)
            {
                //MessageBox.Show("Số điện thoại phải có 10 chữ số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f3 = new ThatBai("Số điện thoại phải có 10 chữ số");
                f3.ShowDialog();
                return;
            }

            if (KhachHang_BLL.Instance.CheckTrungsdtUpdate(this.Sdt,  sdtKH.Text))
            {
                //MessageBox.Show("Số điện thoại này đã trùng với khách hàng đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f3 = new ThatBai("Số điện thoại này đã trùng với khách hàng đã có");
                f3.ShowDialog();
                return;
            }
            KhachHang_BLL.Instance.EditKhachHang(MaKH, tenKhachHang.Text, sdtKH.Text, MaLKH);
            //MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ThanhCong f = new ThanhCong("Cập nhật thành công!");
            f.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
