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
    public partial class ThongTinNhanVien : Form
    {
        private int maNV1;

        public ThongTinNhanVien()
        {
            InitializeComponent();
        }

        public ThongTinNhanVien(int maNV1)
        {
            this.maNV1 = maNV1;
            InitializeComponent();
            string maNVTemp = "";
            string tenNVTemp = "";
            DateTime ngaySinhTemp = DateTime.Now;
            string macvTemp = "";
            string sdtTemp = "";
            string luongTemp = "";
            string gioiTinhTemp = "";
            NhanVien_BLL.Instance.LayThongTinNV(maNV1, ref maNVTemp, ref tenNVTemp, ref ngaySinhTemp, ref sdtTemp, ref luongTemp, ref macvTemp, ref gioiTinhTemp);
            maNV.Text = maNVTemp;
            tenNV.Text = tenNVTemp;
            ngaySinh.Text = ngaySinhTemp.ToString("dd-MM-yyyy");
            chucVu.Text = ChucVu_BLL.Instance.getTenChucVu(Convert.ToInt32(macvTemp));
            sdt.Text = sdtTemp;
            luong.Text = luongTemp;
            gioiTinh.Text = gioiTinhTemp;

        }

        private void ThongTinNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void updatePass_Click_1(object sender, EventArgs e)
        {
            CapNhatMatKhau capNhatMatKhau = new CapNhatMatKhau(maNV1);
            this.Hide();
            capNhatMatKhau.ShowDialog();
            this.Close();
        }

        private void backButton_Click_1(object sender, EventArgs e)
        {
            int maCV = NhanVien_BLL.Instance.getmaCV(maNV1);
            if (maCV == 1)
            {
                ManHinhChinh manHinhChinh = new ManHinhChinh(maNV1);
                this.Hide();
                manHinhChinh.ShowDialog();
                this.Close();
            }
            else {
                ManHinhChinh_NV manHinhChinh = new ManHinhChinh_NV(maNV1);
                this.Hide();
                manHinhChinh.ShowDialog();
                this.Close();
            } 
        }

        private void exit_Click(object sender, EventArgs e)
        {
            backButton_Click_1(sender, e);
        }
    }
}
