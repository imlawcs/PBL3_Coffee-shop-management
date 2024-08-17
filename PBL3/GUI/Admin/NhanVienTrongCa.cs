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
using PBL3.BUS;

namespace PBL3.GUI
{
    public partial class NhanVienTrongCa : Form
    {
        private int MaCa;
        private DateTime Day;
        private int maNV;


        public NhanVienTrongCa(int maCa, DateTime day, int maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);
            MaCa = maCa;
            Day = day;
            dayTb.Text = day.Day.ToString();
            year.Text = "Năm " + day.Year.ToString();
            monthTb.Text = "Tháng " + day.Month.ToString();
            dayTb.Enabled = false;
            monthTb.Enabled = false;
            RefreshData();
            CaTruc_BLL.Instance.AddCaTruc(day);
        }

        private void RefreshData()
        {
            NVCadata.DataSource = CaTruc_BLL.Instance.GetListNhanVien(MaCa, Day.ToString("yyyy-MM-dd"));
            if (NVCadata.Columns["MaNV"] != null)
                NVCadata.Columns["MaNV"].HeaderText = "Mã nhân viên";
            if (NVCadata.Columns["HoTenNV"] != null)
                NVCadata.Columns["HoTenNV"].HeaderText = "Họ tên nhân viên";
            if (NVCadata.Columns["ChucVu"] != null)
                NVCadata.Columns["ChucVu"].HeaderText = "Chức vụ";
            if (NVCadata.Columns["NgaySinh"] != null)
                NVCadata.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            if (NVCadata.Columns["GioiTinh"] != null)
                NVCadata.Columns["GioiTinh"].HeaderText = "Giới tính";
            if (NVCadata.Columns["Luong"] != null)
                NVCadata.Columns["Luong"].HeaderText = "Lương";
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            ThemNhanVienVaoCa f = new ThemNhanVienVaoCa(MaCa, Day);
            this.Hide();
            f.ShowDialog();
            this.Show();
            RefreshData();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (NVCadata.SelectedRows.Count == 0)
            {
               // MessageBox.Show("Chọn nhân viên cần xóa");
                ThatBai f1 = new ThatBai("Chọn nhân viên cần xóa");
                f1.ShowDialog();
                return;
            }
            else
            {
                CaTruc_BLL.Instance.DelNhanVienFromCaTruc(Convert.ToInt32(NVCadata.SelectedRows[0].Cells["MaNV"].Value), MaCa, Day.ToString());
                RefreshData();
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ManHinhChinh manHinhChinh = new ManHinhChinh(maNV);
            this.Hide();
            manHinhChinh.ShowDialog();
            this.Close();
        }

        private void exitCa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                DangNhap f = new DangNhap();
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
        }

        private void quayLai_Click(object sender, EventArgs e)
        {
            CaLamViec f = new CaLamViec(maNV);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
    }
}
