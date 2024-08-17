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
using System.Xml.Linq;

namespace PBL3.GUI
{
    public partial class KhuyenMai : Form
    {
        private int maNV;

        public KhuyenMai()
        {
            InitializeComponent();
            RefreshData();
        }

        public KhuyenMai(int maNV)
        {
            this.maNV = maNV;
            InitializeComponent();
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);
            RefreshData();
        }

        private void RefreshData()
        {
            KMData.DataSource = KhuyenMai_BLL.Instance.GetAllKM();
            if (KMData.Columns["MaKM"] != null)
                KMData.Columns["MaKM"].HeaderText = "Mã khuyến mãi";
            if (KMData.Columns["TenCT"] != null)
                KMData.Columns["TenCT"].HeaderText = "Tên chương trình";
            if (KMData.Columns["TGBatDau"] != null)
                KMData.Columns["TGBatDau"].HeaderText = "Thời gian bắt đầu";
            if (KMData.Columns["TGKetThuc"] != null)
                KMData.Columns["TGKetThuc"].HeaderText = "Thời gian kết thúc";
            if (KMData.Columns["MoTa"] != null)
                KMData.Columns["MoTa"].HeaderText = "Mô tả";
            if (KMData.Columns["GiaTriKM"] != null)
                KMData.Columns["GiaTriKM"].HeaderText = "Giá trị khuyến mãi";
            if (KMData.Columns["GiaTriDHToiThieu"] != null)
                KMData.Columns["GiaTriDHToiThieu"].HeaderText = "Giá trị đơn hàng tối thiểu";
        }
        private void addKM_Click(object sender, EventArgs e)
        {
            ThemMaKM f = new ThemMaKM();
            this.Hide();
            f.ShowDialog();
            this.Show();
            RefreshData();
        }
        
        private void editKM_Click(object sender, EventArgs e)
        {
            int Makm = 0;
            if(KMData.SelectedRows.Count==0)
            {
                //MessageBox.Show("Vui lòng chọn khuyến mãi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f1 = new ThatBai("Vui lòng chọn khuyến mãi cần sửa");
                f1.ShowDialog();
                return;
            }
            if (KMData.SelectedRows.Count == 1)
            {
                Makm = Convert.ToInt32(KMData.SelectedRows[0].Cells["MaKM"].Value.ToString());
            }
            SuaKhuyenMai f = new SuaKhuyenMai(Makm);
            this.Hide();
            f.ShowDialog();
            this.Show();
            RefreshData();
        }

        //ktra del
        private void deleteKM_Click(object sender, EventArgs e)
        {
            if(KMData.SelectedRows.Count==0)
            {
                //MessageBox.Show("Vui lòng chọn khuyến mãi cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f1 = new ThatBai("Vui lòng chọn khuyến mãi cần xóa");
                f1.ShowDialog();
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khuyến mãi này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
               int MaKM = Convert.ToInt32(KMData.SelectedRows[0].Cells["MaKM"].Value.ToString());
               KhuyenMai_BLL.Instance.DeleteKM(MaKM);
            }
            RefreshData();
        }

        private void exitKM_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                DangNhap dangNhap = new DangNhap();
                this.Hide();
                dangNhap.ShowDialog();
                Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ManHinhChinh manHinhChinh = new ManHinhChinh(maNV);
            this.Hide();
            manHinhChinh.ShowDialog();
            Close();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            if(fromDay.Value>toDay.Value)
            {
                //MessageBox.Show("Thời gian không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f1 = new ThatBai("Thời gian không hợp lệ");
                f1.ShowDialog();
                return;
            }
            KMData.DataSource=KhuyenMai_BLL.Instance.GetListKhuyenMaiTheoTGian(fromDay.Value, toDay.Value);
            if(KMData.Rows.Count==0)
            {
                //MessageBox.Show("Hiện không có khuyến mãi trong khoảng thời gian này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f1 = new ThatBai("Hiện không có khuyến mãi trong khoảng thời gian này");
                f1.ShowDialog();
            }
        }

        private void dsKM_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
