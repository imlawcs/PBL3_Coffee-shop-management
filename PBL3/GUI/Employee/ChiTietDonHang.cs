using PBL3.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.GUI.Employee
{
    public partial class ChiTietDonHang : Form
    {
        private int maNV;
        private int maDH;

        public ChiTietDonHang()
        {
            InitializeComponent();
        }

        public ChiTietDonHang(int maNV, int maDH)
        {
            this.maNV = maNV;
            this.maDH = maDH;

            InitializeComponent();
            MaDonHang.Text = maDH.ToString();
            donHangData.DataSource = DonHang_BLL.Instance.GetListDonHangByID(maDH);
            donHangData.Columns["MaSP"].HeaderText="Mã sản phẩm";
            donHangData.Columns["SoLuongSP"].HeaderText = "Số lượng sản phẩm";
            donHangData.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            donHangData.Columns["GiaSP"].HeaderText = "Giá sản phẩm";
            tongTien.Text = getTongTien().ToString() + " đồng";
        }

        private int getTongTien()
        {
            int tongTien = 0;
            for (int i = 0; i < donHangData.Rows.Count; i++)
            {
                tongTien += Convert.ToInt32(donHangData.Rows[i].Cells["SoLuongSP"].Value) * Convert.ToInt32(donHangData.Rows[i].Cells["GiaSP"].Value);
            }
            return tongTien;
        }

        private void donHangExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                DangNhap f = new DangNhap();
                this.Hide();
                f.ShowDialog();
                this.Close();
            }    
        }


        private void quayLai_Click(object sender, EventArgs e)
        {
            DonHang donHang = new DonHang(maNV);
            this.Hide();
            donHang.ShowDialog();
            this.Close();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ManHinhChinh_NV manHinh = new ManHinhChinh_NV(maNV);
            this.Hide();
            manHinh.ShowDialog();
            this.Close();
        }
    }
}
