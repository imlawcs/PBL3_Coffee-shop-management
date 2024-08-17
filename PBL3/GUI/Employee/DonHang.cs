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
    public partial class DonHang : Form
    {
        private int maNV;

        public DonHang()
        {
            InitializeComponent();
        }

        public DonHang(int maNV)
        {
            this.maNV = maNV; InitializeComponent();

            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);
            donHangData.DataSource=DonHang_BLL.Instance.getListObjectMaDH();
            RefreshData();
        }

        private void RefreshData()
        {

            if (donHangData.Columns["MaDH"] != null)
                donHangData.Columns["MaDH"].HeaderText = "Mã đơn hàng";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ManHinhChinh_NV manHinhChinh = new ManHinhChinh_NV(maNV);
            this.Hide();
            manHinhChinh.ShowDialog();
            this.Close();
        }

        private void donHangExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DangNhap f = new DangNhap();
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            if (timKiemDonHang.Text == "")
            {
                //MessageBox.Show("Vui lòng nhập thông tin đơn hàng cần tìm kiếm");
                ThatBai f3 = new ThatBai("Vui lòng nhập thông tin đơn hàng cần tìm kiếm");
                f3.ShowDialog();
                return;
            }
            if(!int.TryParse(timKiemDonHang.Text, out int n))
            {
                //MessageBox.Show("Vui lòng nhập mã đơn hàng là số");
                ThatBai f3 = new ThatBai("Vui lòng nhập mã đơn hàng là số");
                f3.ShowDialog();
            }
            else
            {
                donHangData.DataSource = DonHang_BLL.Instance.getListObjectMaDH(int.Parse(timKiemDonHang.Text));
                if (donHangData.Rows.Count == 0)
                {
                    //MessageBox.Show("Không tìm thấy đơn hàng");
                    ThatBai f3 = new ThatBai("Không tìm thấy đơn hàng");
                    f3.ShowDialog();
                }
                else
                {
                    RefreshData();
                }
            }
        }

        private void CTDH(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                int maDH = int.Parse(donHangData.Rows[row].Cells["MaDH"].Value.ToString());
                ChiTietDonHang chiTietDonHang = new ChiTietDonHang(maNV, maDH);
                this.Hide();
                chiTietDonHang.ShowDialog();
                this.Close();
            }
        }

        private void enter(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                   findButton_Click(sender, e);
            }    
        }
    }
}
