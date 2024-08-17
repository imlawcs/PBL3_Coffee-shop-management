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
    public partial class ChinhSuaTrangThaiBan : Form
    {
        private int maBan;
        private int maNV ;
        public ChinhSuaTrangThaiBan(int maNV, int maBan)
        {
            InitializeComponent();
            this.maBan = maBan;
            this.maNV = maNV;
            setThongTin();
            ten.Text = NhanVien_BLL.Instance.getTenNV(maNV);
        }

        private void setThongTin()
        {
            int trangThai = Ban_BLL.Instance.GetTrangThaiBan(maBan);
            if (trangThai == 0)
            {
                trong.Checked = true;
            }
            else if (trangThai == 1)
            {
                ban.Checked = true;
            }
            else
            {
                DaDat.Checked = true;
            }
            ban.Enabled = false;
        }

        private void huyButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void xacNhanButton_Click(object sender, EventArgs e)
        {
           if(trong.Checked)
            {
                Ban_BLL.Instance.EditBan(maBan, "Bàn trống", "");

               // MessageBox.Show("Chỉnh sửa trạng thái bàn thành công");
                ThanhCong f = new ThanhCong("Chỉnh sửa trạng thái bàn thành công");
                f.ShowDialog();
            }
            else if(DaDat.Checked )
            {
                if(Ban_BLL.Instance.GetTrangThaiBan(maBan)==1)
                {
                    //MessageBox.Show("Không thể chuyển trạng thái bàn bận thành bàn đã được đặt trước");
                    ThatBai f3 = new ThatBai("Không thể chuyển trạng thái bàn bận thành bàn đã được đặt trước");
                    f3.ShowDialog();
                    return;
                }
                DatBan datBan = new DatBan(maNV, maBan);
                this.Hide();
                datBan.ShowDialog();
                this.Close();
            }
            Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
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

        private void ChinhSuaTrangThaiBan_Load(object sender, EventArgs e)
        {
            setThongTin();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
