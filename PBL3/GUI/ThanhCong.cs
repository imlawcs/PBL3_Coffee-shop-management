using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.GUI
{
    public partial class ThanhCong : Form
    {
        public ThanhCong(string s)
        {
            InitializeComponent();
            label1.Text = s;
            label1.AutoSize = true;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            UpdateLabelPosition();
        }
        private void UpdateLabelPosition()
        {
            int x = (guna2Panel1.ClientSize.Width - label1.Width) / 2;
            int y = (guna2Panel1.ClientSize.Height - label1.Height) / 2;
            label1.Location = new Point(x, y);
        }

        private void ThanhCong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }
    }
}
