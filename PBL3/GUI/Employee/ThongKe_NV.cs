using PBL3.BUS;
using PBL3.DTO;
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
    public partial class ThongKe_NV : Form
    {
        private int maNV;

        public ThongKe_NV()
        {
            InitializeComponent();
        }

        public ThongKe_NV(int maNV)
        {
            InitializeComponent();
            this.maNV = maNV;

            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);
            setCB();
        }

        private void setCB()
        {
            calamvieccb.Items.Add("Ca 1");
            calamvieccb.Items.Add("Ca 2");
            calamvieccb.Items.Add("Ca 3");

        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ManHinhChinh_NV manHinhChinh = new ManHinhChinh_NV(maNV);
            this.Hide();
            manHinhChinh.ShowDialog();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                DangNhap f = new DangNhap();
                this.Hide();
                f.ShowDialog();
                this.Close();
            }

        }

        private void Tim_Click(object sender, EventArgs e)
        {
            
            if(calamvieccb.SelectedItem == null)
            {
                //MessageBox.Show("Vui lòng chọn ca làm việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f3 = new ThatBai("Vui lòng chọn ca làm việc");
                f3.ShowDialog();
                return;
            }
            if(ngayTK.Value == null)
            {
                //MessageBox.Show("Vui lòng chọn ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f3 = new ThatBai("Vui lòng chọn ngày");
                f3.ShowDialog();
                return;
            }
            if(ngayTK.Value>DateTime.Now)
            {
                //MessageBox.Show("Ngày không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f3 = new ThatBai("Ngày không hợp lệ");
                f3.ShowDialog();
                return;
            }
            TkeData.DataSource =DoanhThu_BLL.Instance.GetDoanhThuCaNV(maNV, calamvieccb.SelectedItem.ToString(), ngayTK.Value);
            if(TkeData.Rows.Count==0)
            {
                //MessageBox.Show("Nhân viên không tham gia ca trực này, không thể xem doanh thu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f3 = new ThatBai("Nhân viên không tham gia ca trực này, không thể xem doanh thu");
                f3.ShowDialog();
            }
            else
            {  
                if (TkeData.Columns["MaHD"] != null) TkeData.Columns["MaHD"].HeaderText="Mã hóa đơn";
                if (TkeData.Columns["MaDH"] != null) TkeData.Columns["MaDH"].HeaderText = "Mã đơn hàng";
                if (TkeData.Columns["MaKH"] != null) TkeData.Columns["MaKH"].HeaderText = "Mã khách hàng";
                if (TkeData.Columns["ThoiGian"] != null) TkeData.Columns["ThoiGian"].HeaderText = "Thời gian";
                if (TkeData.Columns["TongTien"] != null) TkeData.Columns["TongTien"].HeaderText = "Tổng tiền";
                if (TkeData.Columns["TenKH"] != null) TkeData.Columns["TenKH"].HeaderText = "Tên khách hàng";
                int MaCa = calamvieccb.SelectedItem.ToString() == "Ca 1" ? 1 : calamvieccb.SelectedItem.ToString() == "Ca 2" ? 2 : 3;
                DTca.Text = DoanhThu_BLL.Instance.GetTongDoanhThuCa(MaCa, ngayTK.Value).ToString()+" đồng";
            }
        }

      
    }
}
