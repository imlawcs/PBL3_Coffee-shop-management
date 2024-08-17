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
    public partial class DatMon : Form
    {
        private int maNV, maCheck, maKH = 0;
        private List<SelectedDrink> s = new List<SelectedDrink>();
        private List<SelectedDrink> s123 = new List<SelectedDrink>();
      
        public DatMon(int maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);
            LoadFoodItems();
            guna2DataGridView1.Columns.Add("MaSP", "Mã sản phẩm");
            guna2DataGridView1.Columns.Add("LoaiSP", "Loại sản phẩm");
            guna2DataGridView1.Columns.Add("Name", "Tên sản phẩm");
            guna2DataGridView1.Columns.Add("Quantity", "Số lượng");
        }
        public DatMon(int maNV, List<SelectedDrink> selectedDrinks, int maCheck)
        {
            this.maNV = maNV;
            this.maCheck = maCheck;
            InitializeComponent();
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);
            this.s = selectedDrinks;
            foreach (SelectedDrink drink in s)
            {
                s123.Add(new SelectedDrink(drink)); // Thêm một bản sao của mỗi đối tượng SelectedDrink vào s123
            }
            LoadFoodItems();
            guna2DataGridView1.Columns.Add("MaSP", "Mã sản phẩm");
            guna2DataGridView1.Columns.Add("LoaiSP", "Loại sản phẩm");
            guna2DataGridView1.Columns.Add("Name", "Tên sản phẩm");
            guna2DataGridView1.Columns.Add("Quantity", "Số lượng");
            foreach (var item in s)
            {
                guna2DataGridView1.Rows.Add(item.MaSP, item.LoaiSP, item.TenMon, item.SoLuong);
            }
        }
        public DatMon(int maNV, List<SelectedDrink> selectedDrinks, int maCheck, int maKH)
        {
            this.maNV = maNV;
            this.maCheck = maCheck;
            this.maKH = maKH;
            InitializeComponent();
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);
            this.s = selectedDrinks;
            foreach (SelectedDrink drink in s)
            {
                s123.Add(new SelectedDrink(drink)); // Thêm một bản sao của mỗi đối tượng SelectedDrink vào s123
            }
            LoadFoodItems();
            guna2DataGridView1.Columns.Add("MaSP", "Mã sản phẩm");
            guna2DataGridView1.Columns.Add("LoaiSP", "Loại sản phẩm");
            guna2DataGridView1.Columns.Add("Name", "Tên sản phẩm");
            guna2DataGridView1.Columns.Add("Quantity", "Số lượng");
            foreach (var item in s)
            {
                guna2DataGridView1.Rows.Add(item.MaSP, item.LoaiSP, item.TenMon, item.SoLuong);
            }
        }
        private void LoadFoodItems()
        {
            int columnCount = 3;
            int rowCount = (int)Math.Ceiling((double)(SanPham_BLL.Instance.SLsp()) / columnCount);

            flowLayoutPanel1.Controls.Clear(); // Xóa các điều khiển hiện có

            for (int i = 0; i < rowCount; i++)
            {
                FlowLayoutPanel rowPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    WrapContents = false
                };

                for (int j = 0; j < columnCount; j++)
                {
                    int index = i * columnCount + j;
                    if (index >= (SanPham_BLL.Instance.SLsp()))
                        break;

                    SanPham foodItem = SanPham_BLL.Instance.GetAllListSanPham()[index];
                    Panel panel = CreateFoodItemPanel(foodItem);
                    rowPanel.Controls.Add(panel);
                }

                flowLayoutPanel1.Controls.Add(rowPanel);
            }
        }
        private Panel CreateFoodItemPanel(SanPham foodItem)
        {
            int imageSize = 200; // Kích thước ảnh cố định
            int panelWidth = imageSize + 20; // Kích thước panel = kích thước ảnh + khoảng cách lề

            Panel panel = new Panel
            {
                Size = new Size(panelWidth, 250), // Kích thước panel lớn hơn để chứa các điều khiển con
                Margin = new Padding(10)
            };

            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(imageSize, imageSize), // Kích thước ảnh cố định
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Top // Ảnh sẽ nằm trên cùng của panel
            };
            Image originalImage = Image.FromFile(foodItem.DuongDanAnh);
            pictureBox.Image = ScaleImage(originalImage, imageSize, imageSize);
            pictureBox.Click += (sender, e) =>
            {
                SelectedDrink selectedItem = Bonus_BLL.Instance.SearchSelectedDrink(s, foodItem.MaSP);
                if (selectedItem != null)
                {
                    //MessageBox.Show("Sản phẩm đã tồn tại trong đơn hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ThatBai f3 = new ThatBai("Sản phẩm đã tồn tại trong đơn hàng");
                    f3.ShowDialog();
                }
                else
                {
                    s.Add(new SelectedDrink { MaSP = foodItem.MaSP, TenMon = foodItem.TenSP, LoaiSP = foodItem.LoaiSP,  SoLuong = 1, GiaSP = (long)foodItem.GiaSP });
                }

                UpdateDataGridView();
            };

            Label nameLabel = new Label
            {
                Text = foodItem.TenSP,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                AutoSize = false, // Tắt AutoSize để có thể chỉnh kích thước Label
                Size = new Size(panel.Width, 40), // Kích thước Label
                Padding = new Padding(0, 5, 0, 0) // Padding để tạo khoảng cách với ảnh
            };

            Label priceLabel = new Label
            {
                Text = foodItem.GiaSP.ToString() + " VND",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom, // Hiển thị giá tiền ở dưới
                AutoSize = false, // Tắt AutoSize để có thể chỉnh kích thước Label
                Size = new Size(panel.Width, 20), // Kích thước Label
                Padding = new Padding(0, 0, 0, 5) // Padding để tạo khoảng cách với tên món
            };

            panel.Controls.Add(nameLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(pictureBox);

            return panel;
        }
        private Image ScaleImage(Image image, int width, int height)
        {
            Bitmap scaledImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(scaledImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, width, height);
            }
            return scaledImage;
        }
        private void UpdateDataGridView()
        {
            guna2DataGridView1.Rows.Clear();
            foreach (var item in s)
            {
                guna2DataGridView1.Rows.Add(item.MaSP, item.LoaiSP, item.TenMon, item.SoLuong);
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.RowCount == 0)
            {
               // MessageBox.Show("Đơn hàng chưa có sản phầm nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ThatBai f3 = new ThatBai("Đơn hàng chưa có sản phầm nào");
                f3.ShowDialog();
            }
            else
            {
                if (this.maKH == 0)
                {
                    ThemMon f = new ThemMon(maNV, s);
                    this.Hide();
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    ThemMon f = new ThemMon(maNV, s, maKH);
                    this.Hide();
                    f.ShowDialog();
                    this.Close();
                }
                
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (this.maCheck == 1)
            {
                if (this.maKH == 0)
                {
                    ThemMon f = new ThemMon(maNV, s123);
                    this.Hide();
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    ThemMon f = new ThemMon(maNV, s123, maKH);
                    this.Hide();
                    f.ShowDialog();
                    this.Close();
                }
                
            }
            else
            {
                ManHinhChinh_NV manHinhChinh = new ManHinhChinh_NV(maNV);
                this.Hide();
                manHinhChinh.ShowDialog();
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ManHinhChinh_NV manHinhChinh = new ManHinhChinh_NV(maNV);
            this.Hide();
            manHinhChinh.ShowDialog();
            this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string searchText = guna2TextBox1.Text.Trim().ToLower();
            if (searchText == "")
            {
                //MessageBox.Show("Tên món không được trống!");
                ThatBai f3 = new ThatBai("Tên món không được trống!");
                f3.ShowDialog();
                return;
            }
            foreach (char c in searchText)
            {
                if (char.IsDigit(c))
                {
                    //MessageBox.Show("Tên món không hợp lệ");
                    ThatBai f3 = new ThatBai("Tên món không hợp lệ");
                    f3.ShowDialog();
                    return;
                }
            }

            List<SanPham> filteredFoodItems = SanPham_BLL.Instance.GetListSanPham(searchText);
            flowLayoutPanel1.Controls.Clear();
            foreach (SanPham foodItem in filteredFoodItems)
            {
                Panel panel = CreateFoodItemPanel(foodItem);
                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        private void enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                guna2Button3_Click(sender, e);
            }
        }

        private void guna2DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView1.Columns["Quantity"].Index)
            {
                int maMon = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["MaSP"].Value.ToString());
                int soLuong;
                if (int.TryParse(guna2DataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString(), out soLuong))
                {
                    if (soLuong == 0)
                    {
                        var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này khỏi đơn hàng?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.OK)
                        {
                            //s.RemoveAll(item => item.MaSP == maMon);
                            Bonus_BLL.Instance.RemoveAllSP(s, maMon);
                            UpdateDataGridView();
                            return;
                        }
                        else
                        {
                            UpdateDataGridView();
                            return;
                        }
                    }
                    if (soLuong < 0)
                    {
                        //MessageBox.Show("Số lượng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ThatBai f3 = new ThatBai("Số lượng không hợp lệ");
                        f3.ShowDialog();
                        UpdateDataGridView();
                        return;
                    }
                    SelectedDrink selectedItem = Bonus_BLL.Instance.SearchSelectedDrink(s, maMon);
                    if (selectedItem != null)
                    {
                        selectedItem.SoLuong = soLuong;
                    }

                }
                else
                {
                    //MessageBox.Show("Số lượng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ThatBai f3 = new ThatBai("Số lượng không hợp lệ");
                    f3.ShowDialog();
                    UpdateDataGridView();
                }
                
            }
        }

        private void guna2DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name != "Quantity")
            {
                //MessageBox.Show("Không thể sửa thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f3 = new ThatBai("Không thể sửa thông tin!");
                f3.ShowDialog();
                e.Cancel = true; // Hủy sự kiện chỉnh sửa nếu không phải cột "Số lượng"
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            List<SanPham> filteredFoodItems = SanPham_BLL.Instance.GetAllListSanPham();
            flowLayoutPanel1.Controls.Clear();
            foreach (SanPham foodItem in filteredFoodItems)
            {
                Panel panel = CreateFoodItemPanel(foodItem);
                flowLayoutPanel1.Controls.Add(panel);
            }
        }
        

        private void TDExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DangNhap dangNhap = new DangNhap();
                this.Hide();
                dangNhap.ShowDialog();
                this.Close();
            }
        }
    }
}
