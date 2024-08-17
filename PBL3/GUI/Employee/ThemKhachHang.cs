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
    public partial class ThemKhachHang : Form
    {
        public ThemKhachHang()
        {
            InitializeComponent();
        }
        public ThemKhachHang(string s)
        {

            InitializeComponent();
            sdt.Text = s;

        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tenKH.Text) || string.IsNullOrWhiteSpace(sdt.Text) )
            {
                //MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f3 = new ThatBai("Vui lòng nhập đầy đủ thông tin");
                f3.ShowDialog();
            }
            //kiểm tra sđt toàn số không
            if(!sdt.Text.All(char.IsDigit))
            {
                //MessageBox.Show("Số điện thoại phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f3 = new ThatBai("Số điện thoại phải là số");
                f3.ShowDialog();
                return;
            }
            if(sdt.Text.Length != 10)
            {
               // MessageBox.Show("Số điện thoại phải có 10 chữ số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f3 = new ThatBai("Số điện thoại phải có 10 chữ số");
                f3.ShowDialog();
                return;
            }
            if (KhachHang_BLL.Instance.CheckTrungsdt(sdt.Text))
            {
                //MessageBox.Show("Số điện thoại này đã trùng với khách hàng đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f3 = new ThatBai("Số điện thoại này đã trùng với khách hàng đã có");
                f3.ShowDialog();
                return;
            }
            KhachHang_BLL.Instance.AddKhachHang(tenKH.Text, sdt.Text);
           // MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ThanhCong f = new ThanhCong("Thêm khách hàng thành công!");
            f.ShowDialog();
            this.Close();
        }
    }
}
