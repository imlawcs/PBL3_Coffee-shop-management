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
using System.Xml.Linq;

namespace PBL3.GUI.Admin
{
    public partial class NguyenLieu : Form
    {
        private int maNV;

        public NguyenLieu()
        {
            InitializeComponent();
        }

        public NguyenLieu(int maNV)
        {
            this.maNV = maNV;
            InitializeComponent();
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);
        }

        private void NLExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ManHinhChinh f = new ManHinhChinh(maNV);
                this.Hide();
                f.ShowDialog();
                Close();
            }
        }

        private void RefreshData()
        {
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
            if (NLData.Columns["SLTonKho"]!= null)
            {
                NLData.Columns["SLTonKho"].HeaderText = "Số lượng tồn kho";
            }
        }

        private void addNL_Click(object sender, EventArgs e)
        {
            ThemNguyenLieu f = new ThemNguyenLieu();
            this.Hide();
            f.ShowDialog();
            this.Show();
            NLData.DataSource = NguyenLieu_BLL.Instance.GetListNguyenLieu(0, null);
        }

        private void editNL_Click(object sender, EventArgs e)
        {
            if(NLData.SelectedRows.Count == 0)
            {
                //MessageBox.Show("Vui lòng chọn nguyên liệu cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f1 = new ThatBai("Vui lòng chọn nguyên liệu cần sửa!");
                f1.ShowDialog();
                return;
            }
            int Manl = 0;
            if (NLData.SelectedRows.Count == 1)
            {
                Manl = Convert.ToInt32(NLData.SelectedRows[0].Cells["MaNL"].Value.ToString());
            }
            //SuaNguyenLieu f = new SuaNguyenLieu();
          //  f.GetThongTin(Manl);
            this.Hide();
            //f.ShowDialog();
            this.Show();
            NLData.DataSource = NguyenLieu_BLL.Instance.GetListNguyenLieu(0, null);
            RefreshData();
        }

        private void clearNL_Click(object sender, EventArgs e)
        {
            if (NLData.SelectedRows.Count == 0)
            {
                //MessageBox.Show("Vui lòng chọn 1 nguyên liệu!", "Xác nhận xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ThatBai f1 = new ThatBai("Vui lòng chọn 1 nguyên liệu!");
                f1.ShowDialog();
                return;
            }    
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nguyên liệu này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (NLData.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow i in NLData.SelectedRows)
                    {
                        int Manl = Convert.ToInt32(NLData.SelectedRows[0].Cells["MaNL"].Value.ToString());
                        DTO.NguyenLieu n = NguyenLieu_BLL.Instance.GetNLbymaNL(Manl);
                        if (n.SLTonKho > 0)
                        {
                            //MessageBox.Show("Vẫn còn nguyên liệu " + n.TenNL + "! Không thể xóa.");
                            ThatBai f1 = new ThatBai("Vẫn còn nguyên liệu " + n.TenNL + "! Không thể xóa.");
                            f1.ShowDialog();
                        }    
                        else
                        {
                            NguyenLieu_BLL.Instance.DeleteNguyenLieu(Manl);
                        }    
                        
                    }
                    NLData.DataSource = NguyenLieu_BLL.Instance.GetListNguyenLieu(0, null);
                    RefreshData();
                }
            }
        }

        private void NguyenLieu_Load(object sender, EventArgs e)
        {
            NLData.DataSource = NguyenLieu_BLL.Instance.GetListNguyenLieu(0, null);
            RefreshData();
        }

        private void searchNL_Click(object sender, EventArgs e)
        {
            string txt = nameNLTb.Text;
            if (txt == "")
            {
                //MessageBox.Show("Vui lòng nhập tên nguyên liệu cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThatBai f1 = new ThatBai("Vui lòng nhập tên nguyên liệu cần tìm!");
                f1.ShowDialog();
            }
            NLData.DataSource = NguyenLieu_BLL.Instance.GetListNguyenLieu(0, txt);
            RefreshData();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ManHinhChinh f = new ManHinhChinh(maNV);
            this.Hide();
            f.ShowDialog();
            Close();
        }

        private void enter(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                searchNL_Click(sender, e);
            }
        }

        private void dsNL_Click(object sender, EventArgs e)
        {
            NLData.DataSource = NguyenLieu_BLL.Instance.GetListNguyenLieu(0, null);
            RefreshData();
        }
    }
}
