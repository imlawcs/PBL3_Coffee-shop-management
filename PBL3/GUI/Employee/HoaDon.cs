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
    public partial class HoaDon : Form
    {
        private int maNV;

        public HoaDon()
        {
            InitializeComponent();
        }
        private void RefreshData()
        {
            if (hoaDonData.Columns["MaHD"] != null)
            {
                hoaDonData.Columns["MaHD"].HeaderText = "Mã hóa đơn";
            }
            if (hoaDonData.Columns["MaDH"] != null)
            {
                hoaDonData.Columns["MaDH"].HeaderText = "Mã đơn hàng";
            }
            if (hoaDonData.Columns["MaKH"] != null)
            {
                hoaDonData.Columns["MaKH"].HeaderText = "Mã khách hàng";
            }
            if (hoaDonData.Columns["ThoiGian"] != null)
            {
                hoaDonData.Columns["ThoiGian"].HeaderText = "Thời gian";
            }
            if (hoaDonData.Columns["TongTien"] != null)
            {
                hoaDonData.Columns["TongTien"].HeaderText = "Tổng tiền";
            }
        }
        public HoaDon(int maNV)
        {
            this.maNV = maNV;
            InitializeComponent();
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);

            hoaDonData.DataSource = HoaDon_BLL.Instance.GetListObject();
            RefreshData();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {

        }

        private void findButton_Click(object sender, EventArgs e)
        {
            if (timKiemHoaDon.Text == "")
            {
                //MessageBox.Show("Vui lòng nhập mã hóa đơn cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f3 = new ThatBai("Vui lòng nhập mã hóa đơn cần tìm!");
                f3.ShowDialog();
            }
            if(int.TryParse(timKiemHoaDon.Text, out int n) == false)
            {
                //MessageBox.Show("Mã hóa đơn phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f3 = new ThatBai("Mã hóa đơn phải là số!");
                f3.ShowDialog();
            }
            else
            {
                hoaDonData.DataSource = HoaDon_BLL.Instance.GetListHoaDonByID(int.Parse(timKiemHoaDon.Text));
                RefreshData();
                if (hoaDonData.Rows.Count == 0)
                {
                    //MessageBox.Show("Không tìm thấy hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ThatBai f3 = new ThatBai("Không tìm thấy hóa đơn!");
                    f3.ShowDialog();
                }
            }


        }

        private void hoaDonExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DangNhap f = new DangNhap();
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (NhanVien_BLL.Instance.getmaCV(maNV) == 1)
            {
                ManHinhChinh f = new ManHinhChinh(maNV);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                ManHinhChinh_NV f = new ManHinhChinh_NV(maNV);
                this.Hide();
                f.ShowDialog();
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            hoaDonData.DataSource = HoaDon_BLL.Instance.GetListObject();
            RefreshData();
        }

        private void hoaDonData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int maHD = int.Parse(hoaDonData.Rows[row].Cells[0].Value.ToString());

            ChiTietHoaDon f = new ChiTietHoaDon(maHD, maNV);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
    }
}
