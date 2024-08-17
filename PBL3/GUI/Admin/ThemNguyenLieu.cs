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

namespace PBL3.GUI.Admin
{
    public partial class ThemNguyenLieu : Form
    {
        private int maNV;

        public ThemNguyenLieu()
        {
            InitializeComponent();
            RefreshData();
            dvtcb.Items.Add("Kg");
            dvtcb.Items.Add("Lít");
            dvtcb.Items.Add("Hộp");
            maNL.Enabled = false;
            tenNL.Enabled = false;
            soLuongNhap.Enabled = false;
            giaNhap.Enabled = false;
            ngayNhap.Enabled = false;
            ngayHetHan.Enabled = false;
            dvtcb.Enabled = false;
        }

        public ThemNguyenLieu(int maNV)
        {
            InitializeComponent();
            RefreshData();
            dvtcb.Items.Add("Kg");
            dvtcb.Items.Add("Lít");
            dvtcb.Items.Add("Hộp");
            maNL.Enabled = false;
            tenNL.Enabled = false;
            soLuongNhap.Enabled = false;
            giaNhap.Enabled = false;
            ngayNhap.Enabled = false;
            ngayHetHan.Enabled = false;
            dvtcb.Enabled = false;
            themNLMoi_Click(null, null);
        }
        private void RefreshData()
        {
            NLData.DataSource = NguyenLieu_BLL.Instance.GetListNguyenLieu();
            if (NLData.Columns["MaNL"] != null)
            {
                NLData.Columns["MaNL"].HeaderText = "Mã nguyên liệu";
            }
            if (NLData.Columns["TenNL"] != null)
            {
                NLData.Columns["TenNL"].HeaderText = "Tên nguyên liệu";
            }
            if (NLData.Columns["DonViTinh"] != null)
            {
                NLData.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
            }
            if (NLData.Columns["SLTonKho"] != null)
            {
                NLData.Columns["SLTonKho"].HeaderText = "Số lượng tồn kho";
            }
        }
        private void saveNL_Click(object sender, EventArgs e)
        {
            if(maNL.Text == "" || tenNL.Text == "" ||soLuongNhap.Text == "" || giaNhap.Text=="")
            {
                //MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                ThatBai f3 = new ThatBai("Vui lòng nhập đầy đủ thông tin!");
                f3.ShowDialog();
                return;
            }
            if(ngayNhap.Value > ngayHetHan.Value)
            {
               // MessageBox.Show("Ngày nhập không thể sau ngày hết hạn");
                ThatBai f3 = new ThatBai("Ngày nhập không thể sau ngày hết hạn");
                f3.ShowDialog();
                return;
            }
            if(Convert.ToInt32(soLuongNhap.Text) <= 0 || Convert.ToInt32(giaNhap.Text) <= 0)
            {
                //MessageBox.Show("Số lượng nhập và giá nhập phải lớn hơn 0");
                ThatBai f3 = new ThatBai("Số lượng nhập và giá nhập phải lớn hơn 0");
                f3.ShowDialog();
                return;
            }
            if(dvtcb.Text == "")
            {
               // MessageBox.Show("Vui lòng chọn đơn vị tính");
                ThatBai f3 = new ThatBai("Vui lòng chọn đơn vị tính");
                f3.ShowDialog();
                return;
            }
            if(ChiTietNguyenLieu_BLL.Instance.ValidAdd(Convert.ToInt32(maNL.Text), ngayNhap.Value.ToString("yyyy-MM-dd")) == false)
            {
               // MessageBox.Show("Nguyên liệu đã được nhập vào thời gian này");
                ThatBai f3 = new ThatBai("Nguyên liệu đã được nhập vào thời gian này");
                f3.ShowDialog();
                return;
            }
            if(tenNL.Enabled == true)
            {
                //tạo 1 nguyên liệu mới
                NguyenLieu_BLL.Instance.AddNguyenLieu(tenNL.Text, Convert.ToInt32(soLuongNhap.Text), dvtcb.Text, ngayNhap.Value, ngayHetHan.Value, Convert.ToInt32(giaNhap.Text));
                NLData.DataSource = NguyenLieu_BLL.Instance.GetListNguyenLieu();
            }
            else
            {
                ChiTietNguyenLieu_BLL.Instance.AddChiTietNguyenLieu(Convert.ToInt32(maNL.Text), ngayNhap.Value, Convert.ToInt32(soLuongNhap.Text), ngayHetHan.Value, Convert.ToInt32(giaNhap.Text));
            }
            RefreshData();
            //MessageBox.Show("Thêm nguyên liệu thành công");
            ThanhCong f = new ThanhCong("Thêm nguyên liệu thành công!");
            f.ShowDialog();
            this.Close();
        }

        private void cancelNL_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void NLData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maNL.Text = NLData.CurrentRow.Cells[0].Value.ToString();
            tenNL.Text = NLData.CurrentRow.Cells[1].Value.ToString();
            soLuongNhap.Enabled = true;
            giaNhap.Enabled = true;
            ngayNhap.Enabled = true;
            ngayHetHan.Enabled = true;
            dvtcb.Text = NLData.CurrentRow.Cells[3].Value.ToString();
            btTNLM.Enabled=false;
        }

        private void themNLMoi_Click(object sender, EventArgs e)
        {
            maNL.Enabled = true;
            tenNL.Enabled = true;
            soLuongNhap.Enabled = true;
            giaNhap.Enabled = true;
            ngayNhap.Enabled = true;
            ngayHetHan.Enabled = true;
            dvtcb.Enabled = true;
            NLData.Enabled = false;
            maNL.Text = NguyenLieu_BLL.Instance.GetIDNguyenLieu().ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
