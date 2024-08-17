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
        private void KhachHang_Load(object sender, EventArgs e)
        {
            KHData.DataSource = KhachHang_BLL.Instance.GetListKhachHang(0, null);
        }

        private void searchKH_Click(object sender, EventArgs e)
        {
            string txt = findTextbox.Text;
            if (txt == "")
            {
                //MessageBox.Show("Vui lòng nhập tên/ số điện thoại khách hàng cần tìm kiếm");
                ThatBai f = new ThatBai("Vui lòng nhập tên/ số điện thoại khách hàng cần tìm kiếm");
                f.ShowDialog();
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
                KHData.DataSource=KhachHang_BLL.Instance.GetListKHBySDT(txt);

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
                    ThatBai f = new ThatBai("Vui lòng nhập đúng định dạng tên/ số điện thoại của khách hàng");
                    f.ShowDialog();
                    return;
                }
                //tìm theo tên

                KHData.DataSource = KhachHang_BLL.Instance.GetListKhachHang(0, txt);
            }
            if(KHData.Rows.Count==0)
            {
                //MessageBox.Show("Không tìm thấy khách hàng được yêu cầu");
                ThatBai f = new ThatBai("Không tìm thấy khách hàng được yêu cầu");
                f.ShowDialog();
            }   
            RefreshData();
        }

        private void exitKH_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ManHinhChinh manHinhChinh = new ManHinhChinh(maNV);
            this.Hide();
            manHinhChinh.ShowDialog();
            this.Close();
        }

        private void dsKH_Click(object sender, EventArgs e)
        {
            KHData.DataSource = KhachHang_BLL.Instance.GetListKhachHang(0, null);
            RefreshData();
        }

        private void enter(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                searchKH_Click(sender, e);
            }
        }
    }
}
