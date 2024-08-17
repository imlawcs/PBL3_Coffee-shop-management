using PBL3.BUS;
using PBL3.GUI.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.GUI
{
    public partial class ThucDon : Form
    {
        private int maNV;

        public ThucDon()
        {
            InitializeComponent();
        }

        public ThucDon(int maNV)
        {
            this.maNV = maNV;

            InitializeComponent();
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);

            ThucDonData.DataSource = SanPham_BLL.Instance.GetListSanPham(0, null);
            RefreshData();
        }

        private void RefreshData()
        {
            //p.MaSP, p.TenSP, p.LoaiSP, p.NhomSP, p.DonViSP, p.GiaSP
            if (ThucDonData.Columns["MaSP"] != null)
            {
                ThucDonData.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            }
            if (ThucDonData.Columns["TenSP"] != null)
            {
                ThucDonData.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            }
            if (ThucDonData.Columns["LoaiSP"] != null)
            {
                ThucDonData.Columns["LoaiSP"].HeaderText = "Loại sản phẩm";
            }   
            if (ThucDonData.Columns["NhomSP"] != null)
            {
                ThucDonData.Columns["NhomSP"].HeaderText = "Nhóm sản phẩm";
            }
            if (ThucDonData.Columns["DonViSP"] != null)
            {
                ThucDonData.Columns["DonViSP"].HeaderText = "Đơn vị";
            }
            if (ThucDonData.Columns["GiaSP"] != null)
            {
                ThucDonData.Columns["GiaSP"].HeaderText = "Giá";
            }
        }

        private void addSp_Click(object sender, EventArgs e)
        {
            ThemMon f = new ThemMon(maNV);
            this.Hide();
            f.ShowDialog();
            this.Show();
            ThucDonData.DataSource = SanPham_BLL.Instance.GetListObjectSanPham();
        }

        private void ThucDon_Load(object sender, EventArgs e)
        {
            ThucDonData.DataSource = SanPham_BLL.Instance.GetListObjectSanPham();
            
        }

        private void editSP_Click(object sender, EventArgs e)
        {
            int Masp = 0;
            if (ThucDonData.SelectedRows.Count != 1)
            {
                //MessageBox.Show("Hãy chọn 1 sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ThatBai f3 = new ThatBai("Hãy chọn 1 sản phẩm");
                f3.ShowDialog();
                return;
            }
            if (ThucDonData.SelectedRows.Count == 1)
            {
                Masp = Convert.ToInt32(ThucDonData.SelectedRows[0].Cells["MaSP"].Value.ToString());
            }
            SuaMon f = new SuaMon(maNV);
            f.GetThongTin(Masp);
            this.Hide();
            f.ShowDialog();
            this.Show();
            ThucDonData.DataSource = SanPham_BLL.Instance.GetListObjectSanPham();
            RefreshData();
        }

        private void deleteSP_Click(object sender, EventArgs e)
        {
            if (ThucDonData.SelectedRows.Count == 0)
            {
                //MessageBox.Show("Vui lòng chọn sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ThatBai f3 = new ThatBai("Vui lòng chọn sản phẩm");
                f3.ShowDialog();
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (ThucDonData.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow i in ThucDonData.SelectedRows)
                    {
                        int Masp = Convert.ToInt32(ThucDonData.SelectedRows[0].Cells["MaSP"].Value.ToString());
                        ChiTietSanPham_BLL.Instance.DelChiTietSanPhamFromOneSP(Masp);
                        SanPham_BLL.Instance.DeleteSanPham(Masp);
                    }
                    ThucDonData.DataSource = SanPham_BLL.Instance.GetListObjectSanPham();
                    RefreshData();
                }
            }
        }

        private void exitSP_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DangNhap dangNhap = new DangNhap();
                this.Hide();
                dangNhap.ShowDialog();
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
        private void findButton_Click(object sender, EventArgs e)
        {
            string s = findTextbox.Text;
            if (s == "")
            {
                //MessageBox.Show("Tên món không được trống!");
                ThatBai f3 = new ThatBai("Tên món không được trống!");
                f3.ShowDialog();
                return;
            }
            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    //MessageBox.Show("Tên món không hợp lệ");
                    ThatBai f3 = new ThatBai("Tên món không hợp lệ!");
                    f3.ShowDialog();
                    return;
                }
            }
            ThucDonData.DataSource = SanPham_BLL.Instance.GetListSanPham(0, s.Trim().ToLower());
            RefreshData();
        }

        private void dsMon_Click(object sender, EventArgs e)
        {
            ThucDonData.DataSource = SanPham_BLL.Instance.GetListObjectSanPham();
            RefreshData();
        }

        private void enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                findButton_Click(sender, e);
            }
        }
    }
}
