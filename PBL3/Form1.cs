using PBL3.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PBL3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int maKM = 0;
            if (maKM != 0)
            {
                dataGridView1.Columns.Add("TenCT", "Tên chương trình");
                dataGridView1.Rows.Add(KhuyenMai_BLL.Instance.GetKMbymaKM(maKM).TenCT);
            }
            else
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
            }
        }
    }
}
