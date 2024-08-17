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
using static System.Net.Mime.MediaTypeNames;

namespace PBL3.GUI
{
    public partial class ThemMaKM : Form
    {
        public ThemMaKM()
        {
            InitializeComponent();
            maKM.Text=KhuyenMai_BLL.Instance.getMaKM().ToString();
        }

        
        private void saveKM_Click(object sender, EventArgs e)
        {
            if(startDay.Value > endDay.Value)
            {
               // MessageBox.Show("Thời gian bắt đầu không thể sau thời gian kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ThatBai f3 = new ThatBai("Thời gian bắt đầu không thể sau thời gian kết thúc!");
                f3.ShowDialog();
                return;
            }
            if (tenKM.Text == "" || giaTri.Text == "")
            {
                //MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ThatBai f3 = new ThatBai("Vui lòng nhập đầy đủ thông tin!");
                f3.ShowDialog();
                return;
            }
            if(KHTT.Checked==false && KH.Checked==false && KHM.Checked==false)
            {
                //MessageBox.Show("Vui lòng chọn đối tượng áp dụng khuyến mãi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ThatBai f3 = new ThatBai("Vui lòng chọn đối tượng áp dụng khuyến mãi!");
                f3.ShowDialog();
                return;
            }
            int n;
            if (!int.TryParse(min.Text, out n))
            {
                //MessageBox.Show("Giá trị đơn hàng tối thiểu phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ThatBai f3 = new ThatBai("Giá trị đơn hàng tối thiểu phải là số!");
                f3.ShowDialog();
                return;
            }
            if (Convert.ToInt32(min.Text) < 0)
            {
                //MessageBox.Show("Giá trị đơn hàng tối thiểu không thể nhỏ hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ThatBai f3 = new ThatBai("Giá trị đơn hàng tối thiểu không thể nhỏ hơn 0!");
                f3.ShowDialog();
                return;
            }

            //kiểm tra giá trị nhập vào giaTri có phải số thập phân không


            decimal n1;
           
            if (!decimal.TryParse(giaTri.Text, out n1))
            {
                //MessageBox.Show("Giá trị khuyến mãi phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ThatBai f3 = new ThatBai("Giá trị khuyến mãi phải là số!");
                f3.ShowDialog();
                return;
            }
            if(Convert.ToDecimal(giaTri.Text) <= 0 || Convert.ToDecimal(giaTri.Text)>=1)
            {
                //MessageBox.Show("Giá trị khuyến mãi không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ThatBai f3 = new ThatBai("Giá trị khuyến mãi không hợp lệ!");
                f3.ShowDialog();
                return;
            }
            KhuyenMai_BLL.Instance.AddKhuyenMai(tenKM.Text, moTa.Text, startDay.Value, endDay.Value, Convert.ToDecimal(giaTri.Text), Convert.ToInt32(min.Text), KHTT.Checked, KH.Checked, KHM.Checked);
            //MessageBox.Show("Thêm khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ThanhCong f = new ThanhCong("Thêm khuyến mãi thành công!");
            f.ShowDialog();
            Dispose();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

    }
}
