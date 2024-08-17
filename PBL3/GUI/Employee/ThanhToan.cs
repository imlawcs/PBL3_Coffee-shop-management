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
    public partial class Thanh : Form
    {
        private int maNV, maDH, maBan = 0, maKM = 0, maKH = 0, maNVphucvu = 0, maHD;
        private long gtrithanhtoan;
        private DateTime tgianhtai = DateTime.Now;
        private List<SelectedDrink> selectedDrinks;
        public Thanh()
        {
            InitializeComponent();
        }
        public Thanh(int maNV, List<SelectedDrink> selectedDrinks, int maDH)
        {
            InitializeComponent();
            this.maNV = maNV;
            this.maDH = maDH;
            this.selectedDrinks = selectedDrinks;
            //this.maBan = maBan;
            this.maHD = HoaDon_BLL.Instance.GetnextmaHD();
            label12.Text = maDH.ToString();
            LoadCBB();
            //DTO.Ban b = Ban_BLL.Instance.GetBan(maBan);
            label10.Text = "";
            label15.Text = tgianhtai.ToString("dd/MM/yyyy");
            label17.Text = tgianhtai.ToString("HH:mm:ss");
            donHangData.Columns.Add("MaSP", "Mã sản phẩm");
            donHangData.Columns.Add("LoaiSP", "Loại sản phẩm");
            donHangData.Columns.Add("Name", "Tên sản phẩm");
            donHangData.Columns.Add("Quantity", "Số lượng");
            donHangData.Columns.Add("Price", "Đơn giá");
            guna2DataGridView1.Columns.Add("MaKM", "Mã khuyến mãi");
            guna2DataGridView1.Columns.Add("TenCT", "Tên chương trình");
            ShowDB();
            label7.Text = ThanhToan().ToString() + " VNĐ";
            gtrithanhtoan = ThanhToan();
            label9.Text = gtrithanhtoan.ToString() + " VNĐ";
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);
        }
        public Thanh(int maNV, List<SelectedDrink> selectedDrinks, int maDH, int maKH)
        {
            InitializeComponent();
            this.maNV = maNV;
            this.maDH = maDH;
            this.maKH = maKH;

            this.selectedDrinks = selectedDrinks;
            //this.maBan = maBan;
            this.maHD = HoaDon_BLL.Instance.GetnextmaHD();
            label12.Text = maDH.ToString();
            LoadCBB();
            //DTO.Ban b = Ban_BLL.Instance.GetBan(maBan);
            label10.Text = "";
            label15.Text = tgianhtai.ToString("dd/MM/yyyy");
            label17.Text = tgianhtai.ToString("HH:mm:ss");
            donHangData.Columns.Add("MaSP", "Mã sản phẩm");
            donHangData.Columns.Add("LoaiSP", "Loại sản phẩm");
            donHangData.Columns.Add("Name", "Tên sản phẩm");
            donHangData.Columns.Add("Quantity", "Số lượng");
            donHangData.Columns.Add("Price", "Đơn giá");
            ShowDB();
            label7.Text = ThanhToan().ToString() + " VNĐ";
            gtrithanhtoan = ThanhToan();
            label9.Text = gtrithanhtoan.ToString() + " VNĐ";
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);
            if (this.maKH != 0)
            {
                DTO.KhachHang k2 = KhachHang_BLL.Instance.GetKHbyMaKH(this.maKH);
                if (k2 == null)
                {
                   // MessageBox.Show("Error");
                    ThatBai f3 = new ThatBai("Lỗi");
                    f3.ShowDialog();
                }
                this.maKH = k2.MaKH;
                tenKH.Text = k2.TenKH;
                loaiKH.Text = KhachHang_BLL.Instance.GetLKH(k2).TenLKH;
                sdt.Text = k2.SDT;
                guna2DataGridView1.Columns.Add("MaKM", "Mã khuyến mãi");
                guna2DataGridView1.Columns.Add("TenCT", "Tên chương trình");

                foreach (DTO.KhuyenMai i in KhuyenMai_BLL.Instance.GetKMchoKH(k2, this.gtrithanhtoan))
                {
                    guna2DataGridView1.Rows.Add(i.MaKM, i.TenCT);
                }
            }
        }
        private void ChecksdtKH(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //this.maBan = 0;
                label10.Text = "";
                tenKH.Text = "";
                loaiKH.Text = "";
                guna2Button1.Visible = true;
                guna2Button1.Enabled = true;
                string s = sdt.Text;
                foreach (char c in s)
                {
                    if (!char.IsDigit(c))
                    {
                        //MessageBox.Show("Sai định dạng. Số điện thoại chỉ chứa các kí tự số!");
                        ThatBai f3 = new ThatBai("Sai định dạng. Số điện thoại chỉ chứa các kí tự số!");
                        f3.ShowDialog();
                        return;
                    }
                }
                if (s.Length != 10)
                {
                   //MessageBox.Show("Số điện thoại phải chứa 10 chữ số!");
                    ThatBai f3 = new ThatBai("Số điện thoại phải chứa 10 chữ số!");
                    f3.ShowDialog();
                    return;
                }
                DTO.KhachHang k = KhachHang_BLL.Instance.GetKHbySDT(s);
                if (k == null)
                {
                    //MessageBox.Show("Không có khách hàng nào được tìm thấy. Tạo khách hàng mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ThatBai f3 = new ThatBai("Không có khách hàng nào được tìm thấy. Tạo khách hàng mới");
                    f3.ShowDialog();
                    ThemKhachHang f = new ThemKhachHang(s);
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                    DTO.KhachHang k1 = KhachHang_BLL.Instance.GetKHbySDT(sdt.Text);
                    if (k1 == null)
                    {
                        sdt.Text = "";
                        tenKH.Text = "";
                        loaiKH.Text = "";
                        return;
                    }

                    this.maKH = k1.MaKH;
                    tenKH.Text = k1.TenKH;
                    loaiKH.Text = KhachHang_BLL.Instance.GetLKH(k1).TenLKH;
                    guna2DataGridView1.Rows.Clear();
                    foreach (DTO.KhuyenMai i in KhuyenMai_BLL.Instance.GetKMchoKH(k1, this.gtrithanhtoan))
                    {
                        guna2DataGridView1.Rows.Add(i.MaKM, i.TenCT);
                    }
                    //MessageBox.Show("Hãy chọn bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThatBai f4 = new ThatBai("Hãy chọn bàn");
                    f4.ShowDialog();
                    return;
                    /*ChonBan f1 = new ChonBan(maNV, selectedDrinks, maDH, this.maKH);
                    f1.Show();
                    this.Close();*/
                }
                else
                {
                    //MessageBox.Show("Đã có khách hàng này trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThanhCong f5 = new ThanhCong("Đã có khách hàng này trong hệ thống");
                    f5.ShowDialog();
                    this.maKH = k.MaKH;
                    tenKH.Text = k.TenKH;
                    loaiKH.Text = KhachHang_BLL.Instance.GetLKH(k).TenLKH;
                    guna2DataGridView1.Rows.Clear();
                    foreach (DTO.KhuyenMai i in KhuyenMai_BLL.Instance.GetKMchoKH(k, this.gtrithanhtoan))
                    {
                        guna2DataGridView1.Rows.Add(i.MaKM, i.TenCT);
                    }
                    DTO.Ban b = Ban_BLL.Instance.GetbanBySDT(sdt.Text);
                    if (b == null)
                    {
                        //MessageBox.Show("Khách hàng chưa đặt trước bàn. Hãy chọn bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ThatBai f4 = new ThatBai("Khách hàng chưa đặt trước bàn. Hãy chọn bàn");
                        f4.ShowDialog();
                        return;
                        /*ChonBan f1 = new ChonBan(maNV, selectedDrinks, maDH, this.maKH);
                        f1.Show();
                        this.Close();*/
                    }
                    else
                    {
                        if (b.TrangThai == "Bàn bận" && b.SDT != null)
                        {
                           // MessageBox.Show("Khách hàng này đã đặt món và đang sử dụng bàn tại quán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ThanhCong f6 = new ThanhCong("Khách hàng này đã đặt món và đang sử dụng bàn tại quán");
                            f6.ShowDialog();

                            //guna2Button1.Visible = false;
                            //guna2Button1.Enabled = false;
                            return;
                        }
                        //MessageBox.Show("Khách hàng này đã đặt trước bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ThanhCong f7 = new ThanhCong("Khách hàng này đã đặt trước bàn!");
                        f7.ShowDialog();
                        this.maBan = b.MaBan;
                        label10.Text = this.maBan.ToString() + " / " + b.ViTri;
                        guna2Button1.Visible = false;
                        guna2Button1.Enabled = false;
                    }

                }
                e.SuppressKeyPress = true;
            }
        }

        private void Chonban_Click(object sender, EventArgs e)
        {
            if (tenKH.Text == "")
            {
                //MessageBox.Show("Chưa có thông tin khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f4 = new ThatBai("Chưa có thông tin khách hàng");
                f4.ShowDialog();
                return;
            }
            /*DTO.Ban b1 = Ban_BLL.Instance.GetbanBySDT(sdt.Text);
            if (b1 != null)
            { 
                if (b1.TrangThai == "Bàn bận" && b1.SDT != null)
                {
                    MessageBox.Show("Khách hàng này đã đặt món và đang sử dụng bàn tại quán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
            }*/
            ChonBan f1 = new ChonBan(maNV, selectedDrinks, maDH, this.maKH, this.maBan);
            this.Hide();
            f1.ShowDialog();
            DTO.KhachHang k = KhachHang_BLL.Instance.GetKHbyMaKH(this.maKH);
            DTO.Ban b = Ban_BLL.Instance.GetbanBySDT(k.SDT);
            if (b != null)
            {
                this.maBan = b.MaBan;
                label10.Text = this.maBan.ToString() + " / " + b.ViTri;
            }
            this.Show();
        }

        private void apDungButton_Click(object sender, EventArgs e)
        {

            if (guna2DataGridView1.RowCount == 1)
            {
                //MessageBox.Show("Không có khuyến mãi nào cho khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ThatBai f4 = new ThatBai("Không có khuyến mãi nào cho khách hàng");
                f4.ShowDialog();
                return;
            }
            if (guna2DataGridView1.SelectedRows.Count == 1)
            {
                if (guna2DataGridView1.SelectedRows[0].Cells["MaKM"].Value == null)
                {
                    //MessageBox.Show("Hãy chọn khuyến mãi phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ThatBai f4 = new ThatBai("Hãy chọn khuyến mãi phù hợp");
                    f4.ShowDialog();
                    return;
                }
                this.maKM = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["MaKM"].Value);
                //MessageBox.Show("Đã áp dụng khuyến mãi này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ThanhCong f7 = new ThanhCong("Đã áp dụng khuyến mãi này");
                f7.ShowDialog();
                this.gtrithanhtoan = (long)(this.gtrithanhtoan * (1 - KhuyenMai_BLL.Instance.GetKMbymaKM(this.maKM).GiaTriKM));
                label9.Text = gtrithanhtoan.ToString() + " VNĐ";
            }
            else
            {
                //MessageBox.Show("Vui lòng chọn 1 khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f4 = new ThatBai("Vui lòng chọn 1 khuyến mãi");
                f4.ShowDialog();
                return;
            }
        }

        private void ChonNVPhucVu(object sender, EventArgs e)
        {
            if (dsNV.SelectedItem != null)
            {
                ComboboxItem selected = (ComboboxItem)dsNV.SelectedItem;
                this.maNVphucvu = selected.Value;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //ChonBan f = new ChonBan(maNV, selectedDrinks, maDH, maBan);
            DonHang_BLL.Instance.DelDonHang(maDH);
            if (maBan != 0)
            {
                DTO.Ban b = Ban_BLL.Instance.GetBan(maBan);
                if (b.TrangThai != "Bàn đã được đặt trước")
                {
                    Ban_BLL.Instance.EditBan(maBan, "Bàn trống");
                    //DTO.KhachHang k = KhachHang_BLL.Instance.GetKHbyMaKH(this.maKH);
                    Ban_BLL.Instance.Changesdt(maBan, "");
                }

            }
            if (this.maKH == 0)
            {
                ThemMon f = new ThemMon(maNV, selectedDrinks);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                ThemMon f = new ThemMon(maNV, selectedDrinks, this.maKH);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.maBan == 0)
            {
                //MessageBox.Show("Chưa có thông tin bàn. Hãy chọn bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f4 = new ThatBai("Chưa có thông tin bàn. Hãy chọn bàn");
                f4.ShowDialog();
                /*ChonBan f1 = new ChonBan(maNV, selectedDrinks, maDH, this.maKH);
                f1.Show();
                this.Close();*/
                return;
            }
            if (tenKH.Text == "")
            {
                //MessageBox.Show("Chưa có thông tin khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f4 = new ThatBai("Chưa có thông tin khách hàng");
                f4.ShowDialog();
            }
            else
            {
                if (this.maNVphucvu == 0)
                {
                    //MessageBox.Show("Vui lòng chọn nhân viên phục vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ThatBai f4 = new ThatBai("Vui lòng chọn nhân viên phục vụ");
                    f4.ShowDialog();
                }
                else
                {
                    Ban_BLL.Instance.Changesdt(maBan, sdt.Text);
                    Ban_BLL.Instance.EditBan(maBan, "Bàn bận");
                    KhachHang_BLL.Instance.ChangemaLKH(maKH);
                    DTO.KhachHang kh = KhachHang_BLL.Instance.GetKHbyMaKH(maKH);                
                    HoaDon_BLL.Instance.AddHoaDon(maHD, maDH, maKH, tgianhtai, gtrithanhtoan);
                    foreach (SelectedDrink i in selectedDrinks)
                    {
                        ChiTietHoaDon_BLL.Instance.Add_1_ChiTietHoaDon(maHD, maBan, maNVphucvu, i.MaSP, maKM, i.SoLuong);
                        SanPham_BLL.Instance.TruNLtheoSP(i.MaSP, i.SoLuong);
                    }
                    ChiTietHoaDonSauThanhToan f = new ChiTietHoaDonSauThanhToan(maNV, maHD, selectedDrinks, maDH, maBan, maKH, maKM, maNVphucvu, tgianhtai, gtrithanhtoan);
                    this.Hide();
                    f.ShowDialog();
                    
                    this.Close();
                }
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (maBan != 0)
            {
                DTO.Ban b = Ban_BLL.Instance.GetBan(maBan);
                if (b.TrangThai != "Bàn đã được đặt trước")
                {
                    Ban_BLL.Instance.EditBan(maBan, "Bàn trống");
                    //DTO.KhachHang k = KhachHang_BLL.Instance.GetKHbyMaKH(this.maKH);
                    Ban_BLL.Instance.Changesdt(maBan, "");
                }

            }
            ManHinhChinh_NV manHinhChinh = new ManHinhChinh_NV(maNV);
            this.Hide();
            manHinhChinh.ShowDialog();
            this.Close();
        }

        /*public Thanh(int maNV, List<SelectedDrink> selectedDrinks, int maDH, int maKH)
{
   InitializeComponent();
   this.maNV = maNV;
   this.maDH = maDH;
   this.maKH = maKH;
   if (this.maKH != 0)
   {
       DTO.KhachHang k2 = KhachHang_BLL.Instance.GetKHbyMaKH(this.maKH);
       if (k2 == null)
       {
           MessageBox.Show("Error");
       }
       this.maKH = k2.MaKH;
       tenKH.Text = k2.TenKH;
       loaiKH.Text = KhachHang_BLL.Instance.GetLKH(k2).TenLKH;
       sdt.Text = k2.SDT;
       guna2DataGridView1.Columns.Add("MaKM", "Mã khuyến mãi");
       guna2DataGridView1.Columns.Add("TenCT", "Tên chương trình");
       foreach (DTO.KhuyenMai i in KhuyenMai_BLL.Instance.GetKMchoKH(k2, this.gtrithanhtoan))
       {
           guna2DataGridView1.Rows.Add(i.MaKM, i.TenCT);
       }
   }
   this.selectedDrinks = selectedDrinks;
   //this.maBan = maBan;
   this.maHD = HoaDon_BLL.Instance.GetnextmaHD();
   label12.Text = maDH.ToString();
   LoadCBB();
   //DTO.Ban b = Ban_BLL.Instance.GetBan(maBan);
   label10.Text = "";
   label15.Text = tgianhtai.ToString("dd/MM/yyyy");
   label17.Text = tgianhtai.ToString("HH:mm:ss");
   donHangData.Columns.Add("Name", "Tên sản phẩm");
   donHangData.Columns.Add("Quantity", "Số lượng");
   donHangData.Columns.Add("Price", "Đơn giá");        
   ShowDB();
   label7.Text = ThanhToan().ToString() + " VNĐ";
   gtrithanhtoan = ThanhToan();
   label9.Text = gtrithanhtoan.ToString() + " VNĐ";
   ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);
}
public Thanh(int maNV, List<SelectedDrink> selectedDrinks, int maDH, int maBan, int maKH)
{
   InitializeComponent();
   this.maNV = maNV;
   this.maDH = maDH;
   this.maKH = maKH;
   if (this.maKH != 0)
   {
       DTO.KhachHang k2 = KhachHang_BLL.Instance.GetKHbyMaKH(this.maKH);
       if (k2 == null)
       {
           MessageBox.Show("Error");
       }
       this.maKH = k2.MaKH;
       tenKH.Text = k2.TenKH;
       sdt.Text = k2.SDT;
       loaiKH.Text = KhachHang_BLL.Instance.GetLKH(k2).TenLKH;
       guna2DataGridView1.Columns.Add("MaKM", "Mã khuyến mãi");
       guna2DataGridView1.Columns.Add("TenCT", "Tên chương trình");
       foreach (DTO.KhuyenMai i in KhuyenMai_BLL.Instance.GetKMchoKH(k2, this.gtrithanhtoan))
       {
           guna2DataGridView1.Rows.Add(i.MaKM, i.TenCT);
       }
   }    
   this.selectedDrinks = selectedDrinks;
   this.maBan = maBan;
   this.maHD = HoaDon_BLL.Instance.GetnextmaHD();
   label12.Text = maDH.ToString();
   LoadCBB();
   DTO.Ban b = Ban_BLL.Instance.GetBan(maBan);
   label10.Text = maBan.ToString() + " / " + b.ViTri;
   label15.Text = tgianhtai.ToString("dd/MM/yyyy");
   label17.Text =  tgianhtai.ToString("HH:mm:ss");
   donHangData.Columns.Add("Name", "Tên sản phẩm");
   donHangData.Columns.Add("Quantity", "Số lượng");
   donHangData.Columns.Add("Price", "Đơn giá");            
   ShowDB();
   label7.Text = ThanhToan().ToString() + " VNĐ";
   gtrithanhtoan = ThanhToan();
   label9.Text = gtrithanhtoan.ToString() + " VNĐ";
   ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);
}*/
        public void ShowDB()
        {
            foreach (var item in selectedDrinks)
            {
                donHangData.Rows.Add(item.MaSP, item.LoaiSP, item.TenMon, item.SoLuong, item.GiaSP.ToString() + " VNĐ");
            }
        }
        public void LoadCBB()
        {
            int maCT = 0;
            if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour < 12)
                maCT = 1;
            else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 17)
                maCT = 2;
            else if (DateTime.Now.Hour >= 17 && DateTime.Now.Hour < 22)
                maCT = 3;

            List<DTO.NhanVien> danhSachNhanVien = CaTruc_BLL.Instance.GetListNhanVienPhucVu(maCT, DateTime.Now);

            if (danhSachNhanVien.Count == 0)
            {
                //MessageBox.Show("Không có nhân viên phục vụ cho ca này.");
                ThatBai f4 = new ThatBai("Không có nhân viên phục vụ cho ca này");
                f4.ShowDialog();
            }
            else
            {
                foreach (DTO.NhanVien i in danhSachNhanVien)
                {
                    ComboboxItem item = new ComboboxItem
                    {
                        Text = i.HoTenNV,
                        Value = i.MaNV
                    };
                    dsNV.Items.Add(item);
                }
            }
        }
        public long ThanhToan()
        {
            long t = 0;
            foreach (var item in selectedDrinks)
            {
                t += item.GiaSP * item.SoLuong;
            }
            return t;
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void thanhToanExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thoát", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (maBan != 0)
                {
                    DTO.Ban b = Ban_BLL.Instance.GetBan(maBan);
                    if (b.TrangThai != "Bàn đã được đặt trước")
                    {
                        Ban_BLL.Instance.EditBan(maBan, "Bàn trống");
                        //DTO.KhachHang k = KhachHang_BLL.Instance.GetKHbyMaKH(this.maKH);
                        Ban_BLL.Instance.Changesdt(maBan, "");
                    }

                }
                DangNhap dangNhap = new DangNhap();
                this.Hide();
                dangNhap.ShowDialog();
                this.Close();
            }
        }

    }
}
