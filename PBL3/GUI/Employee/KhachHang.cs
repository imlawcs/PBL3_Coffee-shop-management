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
    public partial class KhachHang : Form
    {
        private int maNV;
        public KhachHang()
        {
            InitializeComponent();
        }

        public KhachHang(int maNV)
        {
            this.maNV = maNV;
            InitializeComponent();
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);
            KHData.DataSource = KhachHang_BLL.Instance.GetListKhachHang();
            RefreshData();
        }

        private void RefreshData()
        {
            if (KHData.Columns["MaKH"] != null)
            {
                KHData.Columns["MaKH"].HeaderText = "Mã khách hàng";
            }
            if (KHData.Columns["TenKH"] != null)
            {
                KHData.Columns["TenKH"].HeaderText = "Họ tên khách hàng";
            }
            if (KHData.Columns["SDT"] != null)
            {
                KHData.Columns["SDT"].HeaderText = "Số điện thoại";
            }
            if (KHData.Columns["MaLKH"] != null)
            {
                KHData.Columns["MaLKH"].HeaderText = "Mã loại khách hàng";
            }
            if (KHData.Columns["LKH"] != null)
            {
                KHData.Columns["LKH"].HeaderText = "Loại khách hàng";
            }

        }

        private void KHExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DangNhap dangNhap = new DangNhap();
                this.Hide();
                dangNhap.ShowDialog();
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

        private void findButton_Click(object sender, EventArgs e)
        {
            string txt = timKiemKH.Text;
            if (txt == "")
            {
                //MessageBox.Show("Vui lòng nhập tên/ số điện thoại khách hàng cần tìm kiếm");
                ThatBai f3 = new ThatBai("Vui lòng nhập tên/ số điện thoại khách hàng cần tìm kiếm");
                f3.ShowDialog();
                return;
            }
            //kiểm tra txt là toàn chữ hay toàn số
            bool isNumber = true;
            foreach (char c in txt)
            {
                if (!Char.IsDigit(c))
                {
                    isNumber = false;
                    break;
                }
            }
            if (isNumber)
            {//tìm theo sđt
                KHData.DataSource = KhachHang_BLL.Instance.GetListKHBySDT(txt);

                RefreshData();
            }
            else
            {
                bool isChar = true;
                foreach (char c in txt)
                {
                    if (!Char.IsLetter(c) && c != ' ')
                    {
                        isChar = false;
                        break;
                    }
                }
                if (!isChar)
                {
                    //MessageBox.Show("Vui lòng nhập đúng định dạng tên/ số điện thoại của khách hàng");
                    ThatBai f3 = new ThatBai("Vui lòng nhập đúng định dạng tên/ số điện thoại của khách hàng");
                    f3.ShowDialog();
                    return;
                }
                //tìm theo tên

                KHData.DataSource = KhachHang_BLL.Instance.GetListKhachHang(0, txt);
            }
            if (KHData.Rows.Count == 0)
            {
                //MessageBox.Show("Không tìm thấy khách hàng được yêu cầu");
                ThatBai f3 = new ThatBai("Không tìm thấy khách hàng được yêu cầu");
                f3.ShowDialog();
                KHData.DataSource = KhachHang_BLL.Instance.GetListKhachHang();
            }
            RefreshData();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ThemKhachHang themKhachHang = new ThemKhachHang();
            this.Hide();
            themKhachHang.ShowDialog();
            this.Show();
            KHData.DataSource = KhachHang_BLL.Instance.GetListKhachHang();
            RefreshData();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if(KHData.SelectedRows.Count == 0)
            {
               // MessageBox.Show("Vui lòng chọn khách hàng cần sửa thông tin");
                ThatBai f3 = new ThatBai("Vui lòng chọn khách hàng cần sửa thông tin");
                f3.ShowDialog();
                return;
            }
            DataGridViewRow row = KHData.SelectedRows[0];
            string maKH = row.Cells["MaKH"].Value.ToString();
            string tenKH = row.Cells["TenKH"].Value.ToString();
            string sdt = row.Cells["SDT"].Value.ToString();
            string maLKH = row.Cells["MaLKH"].Value.ToString();
            SuaKhachHang suaKhachHang = new SuaKhachHang(maKH, tenKH, sdt, maLKH);
            this.Hide();
            suaKhachHang.ShowDialog();
            this.Show();
            KHData.DataSource = KhachHang_BLL.Instance.GetListKhachHang();
            RefreshData();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (KHData.SelectedRows.Count == 0)
            {
                //MessageBox.Show("Vui lòng chọn khách hàng cần xóa thông tin");
                ThatBai f3 = new ThatBai("Vui lòng chọn khách hàng cần xóa thông tin");
                f3.ShowDialog();
                return;
            }
            DataGridViewRow row = KHData.SelectedRows[0];
            string maKH = row.Cells["MaKH"].Value.ToString();
            KhachHang_BLL.Instance.DeleteKH(Convert.ToInt32(maKH));
            KHData.DataSource = KhachHang_BLL.Instance.GetListKhachHang();  
            RefreshData();
        }

        private void dsKH_Click(object sender, EventArgs e)
        {
            KHData.DataSource = KhachHang_BLL.Instance.GetListKhachHang();
            RefreshData();
        }

        private void enter(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                findButton_Click(sender, e);
            }
        }
    }
}
