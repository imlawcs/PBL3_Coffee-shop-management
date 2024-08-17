namespace PBL3.GUI
{
    partial class ThemNhanVienVaoCa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.data = new System.Windows.Forms.Label();
            this.NVData = new Guna.UI2.WinForms.Guna2DataGridView();
            this.maNVCb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cancelButton = new Guna.UI2.WinForms.Guna2Button();
            this.saveButton = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.themNVvaoCaExit = new System.Windows.Forms.PictureBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NVData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.themNVvaoCaExit)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.guna2Panel1.BorderRadius = 3123;
            this.guna2Panel1.Controls.Add(this.data);
            this.guna2Panel1.Controls.Add(this.NVData);
            this.guna2Panel1.Controls.Add(this.maNVCb);
            this.guna2Panel1.Controls.Add(this.label6);
            this.guna2Panel1.Controls.Add(this.cancelButton);
            this.guna2Panel1.Controls.Add(this.saveButton);
<<<<<<< HEAD
            this.guna2Panel1.Location = new System.Drawing.Point(66, 67);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1260, 697);
=======
            this.guna2Panel1.Location = new System.Drawing.Point(99, 102);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1890, 1072);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.guna2Panel1.TabIndex = 4;
            // 
            // data
            // 
            this.data.AutoSize = true;
            this.data.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.data.Location = new System.Drawing.Point(431, 38);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(156, 21);
=======
            this.data.Location = new System.Drawing.Point(647, 59);
            this.data.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(241, 32);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.data.TabIndex = 30;
            this.data.Text = "Danh sách nhân viên";
            // 
            // NVData
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.NVData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NVData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.NVData.ColumnHeadersHeight = 20;
            this.NVData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.NVData.DefaultCellStyle = dataGridViewCellStyle3;
            this.NVData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
<<<<<<< HEAD
            this.NVData.Location = new System.Drawing.Point(435, 75);
            this.NVData.Name = "NVData";
            this.NVData.RowHeadersVisible = false;
            this.NVData.RowHeadersWidth = 62;
            this.NVData.Size = new System.Drawing.Size(763, 488);
=======
            this.NVData.Location = new System.Drawing.Point(652, 115);
            this.NVData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NVData.Name = "NVData";
            this.NVData.RowHeadersVisible = false;
            this.NVData.RowHeadersWidth = 62;
            this.NVData.Size = new System.Drawing.Size(1144, 751);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.NVData.TabIndex = 29;
            this.NVData.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.NVData.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.NVData.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.NVData.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.NVData.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.NVData.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.NVData.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.NVData.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.NVData.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.NVData.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NVData.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.NVData.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.NVData.ThemeStyle.HeaderStyle.Height = 20;
            this.NVData.ThemeStyle.ReadOnly = false;
            this.NVData.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.NVData.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.NVData.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NVData.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.NVData.ThemeStyle.RowsStyle.Height = 22;
            this.NVData.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.NVData.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // maNVCb
            // 
            this.maNVCb.BackColor = System.Drawing.Color.Transparent;
            this.maNVCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.maNVCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maNVCb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.maNVCb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.maNVCb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.maNVCb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.maNVCb.ItemHeight = 30;
<<<<<<< HEAD
            this.maNVCb.Location = new System.Drawing.Point(189, 75);
            this.maNVCb.Name = "maNVCb";
            this.maNVCb.Size = new System.Drawing.Size(140, 36);
=======
            this.maNVCb.Location = new System.Drawing.Point(284, 115);
            this.maNVCb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maNVCb.Name = "maNVCb";
            this.maNVCb.Size = new System.Drawing.Size(208, 36);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.maNVCb.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.label6.Location = new System.Drawing.Point(46, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 21);
=======
            this.label6.Location = new System.Drawing.Point(69, 119);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 32);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.label6.TabIndex = 27;
            this.label6.Text = "Mã nhân viên (*)";
            // 
            // cancelButton
            // 
            this.cancelButton.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.cancelButton.BorderRadius = 10;
            this.cancelButton.BorderThickness = 2;
            this.cancelButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.cancelButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.cancelButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.cancelButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.cancelButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.cancelButton.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.Black;
<<<<<<< HEAD
            this.cancelButton.Location = new System.Drawing.Point(191, 155);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(161, 48);
=======
            this.cancelButton.Location = new System.Drawing.Point(287, 239);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(242, 74);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.cancelButton.TabIndex = 23;
            this.cancelButton.Text = "Hủy";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.saveButton.BorderRadius = 10;
            this.saveButton.BorderThickness = 2;
            this.saveButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.saveButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.saveButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.saveButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.saveButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.saveButton.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.saveButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.Black;
<<<<<<< HEAD
            this.saveButton.Location = new System.Drawing.Point(25, 155);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(160, 48);
=======
            this.saveButton.Location = new System.Drawing.Point(37, 239);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(240, 74);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.saveButton.TabIndex = 22;
            this.saveButton.Text = "Lưu";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(156)))), ((int)(((byte)(156)))));
            this.label2.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
<<<<<<< HEAD
            this.label2.Location = new System.Drawing.Point(61, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 28);
=======
            this.label2.Location = new System.Drawing.Point(91, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(537, 42);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.label2.TabIndex = 5;
            this.label2.Text = "Thêm nhân viên vào ca làm việc";
            // 
            // themNVvaoCaExit
            // 
<<<<<<< HEAD
            this.pictureBox1.Image = global::PBL3.Properties.Resources.akar_icons_circle_x_fill;
            this.pictureBox1.Location = new System.Drawing.Point(1329, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ThemNhanVienVaoCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(156)))), ((int)(((byte)(156)))));
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
=======
            this.themNVvaoCaExit.Image = global::PBL3.Properties.Resources.akar_icons_circle_x_fill;
            this.themNVvaoCaExit.Location = new System.Drawing.Point(1832, 19);
            this.themNVvaoCaExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.themNVvaoCaExit.Name = "themNVvaoCaExit";
            this.themNVvaoCaExit.Size = new System.Drawing.Size(63, 61);
            this.themNVvaoCaExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.themNVvaoCaExit.TabIndex = 6;
            this.themNVvaoCaExit.TabStop = false;
            this.themNVvaoCaExit.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ThemNhanVienVaoCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(156)))), ((int)(((byte)(156)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.themNVvaoCaExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.Name = "ThemNhanVienVaoCa";
            this.Text = "ThemNhanVienVaoCa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NVData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.themNVvaoCaExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button cancelButton;
        private Guna.UI2.WinForms.Guna2Button saveButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox themNVvaoCaExit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label data;
        private Guna.UI2.WinForms.Guna2DataGridView NVData;
        private Guna.UI2.WinForms.Guna2ComboBox maNVCb;
    }
}