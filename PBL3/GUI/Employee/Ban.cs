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
    public partial class Ban : Form
    {
        private int maNV;

        public Ban()
        {
            InitializeComponent();
            RefreshData();
        }

        public Ban(int maNV)
        {
            this.maNV = maNV;
            InitializeComponent();
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);

            RefreshData();
        }

        private void RefreshData()
        {
            banData.DataSource = BUS.Ban_BLL.Instance.GetListBan();
            banData.Columns["MaBan"].HeaderText = "Mã bàn";
            banData.Columns["TrangThai"].HeaderText = "Trạng thái";
            banData.Columns["ViTri"].HeaderText = "Vị trí";
            banData.Columns["SDT"].HeaderText = "Số điện thoại của khách đã đặt";

        }
        private void findButton_Click(object sender, EventArgs e)
        {
            if (search.Text == "")
            {
                //MessageBox.Show("Vui lòng nhập thông tin bàn cần tìm kiếm");
                ThatBai f3 = new ThatBai("Vui lòng nhập thông tin bàn cần tìm kiếm");
                f3.ShowDialog();
            }
            else
            {
                if (BUS.Ban_BLL.Instance.GetBanByID(Convert.ToInt32(search.Text)).Count == 0)
                {
                    //MessageBox.Show("Không tìm thấy bàn");
                    ThatBai f3 = new ThatBai("Không tìm thấy bàn");
                    f3.ShowDialog();
                }
                else
                {
                    banData.DataSource = BUS.Ban_BLL.Instance.GetBanByID(Convert.ToInt32(search.Text));
                    if (banData.Columns["MaBan"] != null)
                        banData.Columns["MaBan"].HeaderText = "Mã bàn";
                    if (banData.Columns["TrangThai"] != null)
                        banData.Columns["TrangThai"].HeaderText = "Trạng thái";
                    if (banData.Columns["ViTri"] != null)
                        banData.Columns["ViTri"].HeaderText = "Vị trí";
                    if (banData.Columns["SDT"]!=null)
                    banData.Columns["SDT"].HeaderText = "Số điện thoại của khách đã đặt";
                }
            }
        }

        private void datBan_Click(object sender, EventArgs e)
        {
            if (Ban_BLL.Instance.GetListBanFree().Count == 0)
            {
                //MessageBox.Show("Không có bàn trống");
                ThatBai f3 = new ThatBai("Không có bàn trống");
                f3.ShowDialog();
                return; 
            }
            DatBan f = new DatBan(maNV);
            this.Hide();
            f.ShowDialog();
            this.Show();
            RefreshData();
        }

        private void banExit_Click(object sender, EventArgs e)
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

        private void chinhSuaTTBan_Click(object sender, EventArgs e)
        {
            if(banData.SelectedRows.Count == 0)
            {
                //MessageBox.Show("Vui lòng chọn bàn cần chỉnh sửa trạng thái");
                ThatBai f3 = new ThatBai("Vui lòng chọn bàn cần chỉnh sửa trạng thái");
                f3.ShowDialog();
                return;
            }
            int maBan = Convert.ToInt32(banData.SelectedRows[0].Cells["MaBan"].Value);
            ChinhSuaTrangThaiBan chinhSuaTrangThaiBan = new ChinhSuaTrangThaiBan(maNV,maBan);
            this.Hide();
            chinhSuaTrangThaiBan.ShowDialog();
            this.Show();
            RefreshData();
        }

        private void enter(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                findButton_Click(sender, e);
            }
        }

        private void dsBan_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

    }
}
