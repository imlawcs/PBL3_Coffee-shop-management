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
    public partial class ChiTietHoaDon : Form
    {
        private int maNV;


        public ChiTietHoaDon(int maHD, int maNV)
        {
            this.maNV = maNV;

            InitializeComponent();
            this.maHD.Text = maHD.ToString();
            tongTien.Text = HoaDon_BLL.Instance.GetHoaDonById(maHD).TongTien.ToString() + " đồng";
            TG.Text = ((DateTime)HoaDon_BLL.Instance.GetHoaDonById(maHD).ThoiGian).ToString("HH:mm:ss dd-MM-yyyy");
            maDH.Text = HoaDon_BLL.Instance.GetHoaDonById(maHD).MaDH.ToString();
            tenKH.Text = HoaDon_BLL.Instance.GetHoaDonById(maHD).KhachHang.TenKH;
            maBan.Text = ChiTietHoaDon_BLL.Instance.GetListChiTietHoaDonByMaHD(maHD)[0].MaBan.ToString();
            tenNV.Text = ChiTietHoaDon_BLL.Instance.GetListChiTietHoaDonByMaHD(maHD)[0].NhanVien.HoTenNV;
            vitri.Text = ChiTietHoaDon_BLL.Instance.GetListChiTietHoaDonByMaHD(maHD)[0].Ban.ViTri;
            hoaDonData.DataSource = ChiTietHoaDon_BLL.Instance.GetListObjectCTHDByMaHD(maHD);
            hoaDonData.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            hoaDonData.Columns["SoLuongSP"].HeaderText = "Số lượng sản phẩm";

            hoaDonData.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            hoaDonData.Columns["GiaSP"].HeaderText = "Giá sản phẩm";
            hoaDonData.Columns["LoaiSP"].HeaderText = "Loại sản phẩm";
            hoaDonData.Columns["NhomSP"].HeaderText = "Nhóm sản phẩm";
            if (ChiTietHoaDon_BLL.Instance.GetListChiTietHoaDonByMaHD(maHD)[0].MaKM != null)
            {
                DTO.KhuyenMai km = KhuyenMai_BLL.Instance.GetKhuyenMai((int)ChiTietHoaDon_BLL.Instance.GetListChiTietHoaDonByMaHD(maHD)[0].MaKM);

                if (km != null)
                {
                    tenKM.Text = km.TenCT;
                    decimal gtkm = (decimal)km.GiaTriKM;
                    if (km.GiaTriDHToiThieu != null)
                    {
                        moTa.Text = "Giảm " + gtkm * 100 + "%  cho đơn hàng có giá trị trên " + km.GiaTriDHToiThieu + " đồng";
                    }
                    else
                    {
                        moTa.Text = "Giảm " + gtkm * 100 + "% cho đơn hàng";
                    }
                }
                else { kmpanel.Visible = false; }
                
            }
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int maCV = NhanVien_BLL.Instance.getmaCV(maNV);
            if (maCV == 1)
            {
                ManHinhChinh manHinhChinh = new ManHinhChinh(maNV);
                this.Hide();
                manHinhChinh.ShowDialog();
                this.Close();
            }
            else if (maCV == 2)
            {
                ManHinhChinh_NV manHinhChinh_NV = new ManHinhChinh_NV(maNV);
                this.Hide();
                manHinhChinh_NV.ShowDialog();
                this.Close();
            }
        }

        private void hoaDonExit_Click(object sender, EventArgs e)
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

        private void quaylai_Click(object sender, EventArgs e)
        {
            HoaDon hoaDon = new HoaDon(maNV);
            this.Hide();
            hoaDon.ShowDialog();
            this.Close();

        }
    }
}
