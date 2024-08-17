namespace PBL3.GUI.Admin
{
    partial class TaiKhoan
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
            this.TKData = new System.Windows.Forms.DataGridView();
            this.clearButton = new Guna.UI2.WinForms.Guna2Button();
            this.editButton = new Guna.UI2.WinForms.Guna2Button();
            this.addButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TKExit = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.ten = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TKData)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TKExit)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // TKData
            // 
            this.TKData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TKData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.TKData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
<<<<<<< HEAD
            this.TKData.Location = new System.Drawing.Point(58, 159);
            this.TKData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TKData.Name = "TKData";
            this.TKData.RowHeadersWidth = 51;
            this.TKData.Size = new System.Drawing.Size(1266, 529);
=======
            this.TKData.Location = new System.Drawing.Point(87, 245);
            this.TKData.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.TKData.Name = "TKData";
            this.TKData.RowHeadersWidth = 51;
            this.TKData.Size = new System.Drawing.Size(1800, 800);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.TKData.TabIndex = 11;
            // 
            // clearButton
            // 
            this.clearButton.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.clearButton.BorderRadius = 10;
            this.clearButton.BorderThickness = 2;
            this.clearButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.clearButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.clearButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.clearButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.clearButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.clearButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.Color.Black;
<<<<<<< HEAD
            this.clearButton.Location = new System.Drawing.Point(449, 86);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(170, 40);
=======
            this.clearButton.Location = new System.Drawing.Point(674, 132);
            this.clearButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(255, 61);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.clearButton.TabIndex = 10;
            this.clearButton.Text = "Xóa";
            this.clearButton.Click += new System.EventHandler(this.deleteTK_Click);
            // 
            // editButton
            // 
            this.editButton.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.editButton.BorderRadius = 10;
            this.editButton.BorderThickness = 2;
            this.editButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.editButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.editButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.editButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.editButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.editButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.ForeColor = System.Drawing.Color.Black;
<<<<<<< HEAD
            this.editButton.Location = new System.Drawing.Point(255, 86);
            this.editButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(170, 40);
=======
            this.editButton.Location = new System.Drawing.Point(382, 132);
            this.editButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(255, 61);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.editButton.TabIndex = 9;
            this.editButton.Text = "Cập nhật";
            this.editButton.Click += new System.EventHandler(this.editTK_Click);
            // 
            // addButton
            // 
            this.addButton.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.addButton.BorderRadius = 10;
            this.addButton.BorderThickness = 2;
            this.addButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.addButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.ForeColor = System.Drawing.Color.Black;
<<<<<<< HEAD
            this.addButton.Location = new System.Drawing.Point(58, 86);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(170, 40);
=======
            this.addButton.Location = new System.Drawing.Point(87, 132);
            this.addButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(255, 61);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Thêm";
            this.addButton.Click += new System.EventHandler(this.addTK_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.Controls.Add(this.TKExit);
            this.guna2Panel1.Controls.Add(this.panel1);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
<<<<<<< HEAD
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1386, 54);
=======
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(2079, 82);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.guna2Panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PBL3.Properties.Resources.icons8_home_50;
<<<<<<< HEAD
            this.pictureBox1.Location = new System.Drawing.Point(14, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 28);
=======
            this.pictureBox1.Location = new System.Drawing.Point(21, 21);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 42);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // TKExit
            // 
            this.TKExit.Image = global::PBL3.Properties.Resources.nút_tắt;
<<<<<<< HEAD
            this.TKExit.Location = new System.Drawing.Point(1317, 12);
            this.TKExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TKExit.Name = "TKExit";
            this.TKExit.Size = new System.Drawing.Size(30, 30);
=======
            this.TKExit.Location = new System.Drawing.Point(1842, 22);
            this.TKExit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.TKExit.Name = "TKExit";
            this.TKExit.Size = new System.Drawing.Size(45, 46);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.TKExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TKExit.TabIndex = 2;
            this.TKExit.TabStop = false;
            this.TKExit.Click += new System.EventHandler(this.TKExit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label1);
<<<<<<< HEAD
            this.panel1.Location = new System.Drawing.Point(60, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 54);
=======
            this.panel1.Location = new System.Drawing.Point(90, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 82);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PBL3.Properties.Resources.icons8_account_50_11;
<<<<<<< HEAD
            this.pictureBox2.Location = new System.Drawing.Point(18, 13);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 29);
=======
            this.pictureBox2.Location = new System.Drawing.Point(27, 20);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 45);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.label1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
<<<<<<< HEAD
            this.label1.Location = new System.Drawing.Point(52, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
=======
            this.label1.Location = new System.Drawing.Point(78, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 37);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài khoản";
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::PBL3.Properties.Resources.Vector__2_;
<<<<<<< HEAD
            this.pictureBox10.Location = new System.Drawing.Point(1284, 86);
            this.pictureBox10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(40, 40);
=======
            this.pictureBox10.Location = new System.Drawing.Point(1827, 132);
            this.pictureBox10.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(60, 61);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 17;
            this.pictureBox10.TabStop = false;
            // 
            // ten
            // 
            this.ten.AutoSize = true;
            this.ten.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.ten.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.ForeColor = System.Drawing.Color.Black;
<<<<<<< HEAD
            this.ten.Location = new System.Drawing.Point(991, 101);
            this.ten.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(107, 25);
=======
            this.ten.Location = new System.Drawing.Point(1486, 155);
            this.ten.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(160, 37);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.ten.TabIndex = 48;
            this.ten.Text = "Đơn hàng";
            // 
            // TaiKhoan
            // 
<<<<<<< HEAD
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.ClientSize = new System.Drawing.Size(1386, 788);
=======
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.Controls.Add(this.ten);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.TKData);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
<<<<<<< HEAD
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
=======
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.Name = "TaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TaiKhoan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.TKData)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TKExit)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView TKData;
        private Guna.UI2.WinForms.Guna2Button clearButton;
        private Guna.UI2.WinForms.Guna2Button editButton;
        private Guna.UI2.WinForms.Guna2Button addButton;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.PictureBox TKExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label ten;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}