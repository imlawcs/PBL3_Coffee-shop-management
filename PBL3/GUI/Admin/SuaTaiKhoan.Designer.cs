namespace PBL3.GUI.Admin
{
    partial class SuaTaiKhoan
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
            this.suaTKExit = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.password = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.maNV = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cancelButton = new Guna.UI2.WinForms.Guna2Button();
            this.saveButton = new Guna.UI2.WinForms.Guna2Button();
            this.tenTK = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.suaTKExit)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // suaTKExit
            // 
            this.suaTKExit.Image = global::PBL3.Properties.Resources.akar_icons_circle_x_fill;
<<<<<<< HEAD
            this.suaTKExit.Location = new System.Drawing.Point(1321, 12);
            this.suaTKExit.Name = "suaTKExit";
            this.suaTKExit.Size = new System.Drawing.Size(42, 40);
=======
            this.suaTKExit.Location = new System.Drawing.Point(1836, 19);
            this.suaTKExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.suaTKExit.Name = "suaTKExit";
            this.suaTKExit.Size = new System.Drawing.Size(63, 61);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.suaTKExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.suaTKExit.TabIndex = 17;
            this.suaTKExit.TabStop = false;
            this.suaTKExit.Click += new System.EventHandler(this.suaTKExit_Click);
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
            this.label2.Size = new System.Drawing.Size(321, 28);
=======
            this.label2.Location = new System.Drawing.Point(91, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(481, 42);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.label2.TabIndex = 16;
            this.label2.Text = "Cập nhật thông tin tài khoản";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.guna2Panel1.BorderRadius = 3123;
            this.guna2Panel1.Controls.Add(this.password);
            this.guna2Panel1.Controls.Add(this.label6);
            this.guna2Panel1.Controls.Add(this.label11);
            this.guna2Panel1.Controls.Add(this.maNV);
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Controls.Add(this.label10);
            this.guna2Panel1.Controls.Add(this.cancelButton);
            this.guna2Panel1.Controls.Add(this.saveButton);
            this.guna2Panel1.Controls.Add(this.tenTK);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.label3);
<<<<<<< HEAD
            this.guna2Panel1.Location = new System.Drawing.Point(66, 67);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1260, 697);
=======
            this.guna2Panel1.Location = new System.Drawing.Point(99, 102);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1800, 950);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.guna2Panel1.TabIndex = 15;
            // 
            // password
            // 
            this.password.BorderRadius = 10;
            this.password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.password.DefaultText = "";
            this.password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.password.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.password.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
<<<<<<< HEAD
            this.password.Location = new System.Drawing.Point(486, 363);
            this.password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
=======
            this.password.Location = new System.Drawing.Point(729, 559);
            this.password.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.PlaceholderText = "";
            this.password.SelectedText = "";
<<<<<<< HEAD
            this.password.Size = new System.Drawing.Size(434, 51);
=======
            this.password.Size = new System.Drawing.Size(651, 79);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.password.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.label6.Location = new System.Drawing.Point(328, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 21);
=======
            this.label6.Location = new System.Drawing.Point(492, 581);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 32);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.label6.TabIndex = 38;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.label11.Location = new System.Drawing.Point(352, 378);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 21);
=======
            this.label11.Location = new System.Drawing.Point(528, 581);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 32);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.label11.TabIndex = 37;
            this.label11.Text = "Mật khẩu (*)";
            // 
            // maNV
            // 
            this.maNV.BorderRadius = 10;
            this.maNV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.maNV.DefaultText = "";
            this.maNV.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.maNV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.maNV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.maNV.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.maNV.FillColor = System.Drawing.Color.LightGray;
            this.maNV.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.maNV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.maNV.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
<<<<<<< HEAD
            this.maNV.Location = new System.Drawing.Point(486, 217);
            this.maNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
=======
            this.maNV.Location = new System.Drawing.Point(729, 334);
            this.maNV.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.maNV.Name = "maNV";
            this.maNV.PasswordChar = '\0';
            this.maNV.PlaceholderText = "";
            this.maNV.ReadOnly = true;
            this.maNV.SelectedText = "";
<<<<<<< HEAD
            this.maNV.Size = new System.Drawing.Size(434, 51);
=======
            this.maNV.Size = new System.Drawing.Size(651, 79);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.maNV.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.label5.Location = new System.Drawing.Point(328, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 21);
=======
            this.label5.Location = new System.Drawing.Point(492, 358);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 32);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.label5.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.label10.Location = new System.Drawing.Point(326, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 21);
=======
            this.label10.Location = new System.Drawing.Point(489, 358);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(196, 32);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.label10.TabIndex = 34;
            this.label10.Text = "Mã nhân viên (*)";
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
            this.cancelButton.Location = new System.Drawing.Point(1006, 646);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(161, 48);
=======
            this.cancelButton.Location = new System.Drawing.Point(1517, 817);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(242, 74);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.cancelButton.TabIndex = 23;
            this.cancelButton.Text = "Hủy";
            this.cancelButton.Click += new System.EventHandler(this.cancelTK_Click);
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
            this.saveButton.Location = new System.Drawing.Point(840, 646);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(160, 48);
=======
            this.saveButton.Location = new System.Drawing.Point(1268, 817);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(240, 74);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.saveButton.TabIndex = 22;
            this.saveButton.Text = "Lưu";
            this.saveButton.Click += new System.EventHandler(this.SaveTK_Click);
            // 
            // tenTK
            // 
            this.tenTK.BorderRadius = 10;
            this.tenTK.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tenTK.DefaultText = "";
            this.tenTK.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tenTK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tenTK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tenTK.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tenTK.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tenTK.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tenTK.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
<<<<<<< HEAD
            this.tenTK.Location = new System.Drawing.Point(486, 292);
            this.tenTK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
=======
            this.tenTK.Location = new System.Drawing.Point(729, 449);
            this.tenTK.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.tenTK.Name = "tenTK";
            this.tenTK.PasswordChar = '\0';
            this.tenTK.PlaceholderText = "";
            this.tenTK.SelectedText = "";
<<<<<<< HEAD
            this.tenTK.Size = new System.Drawing.Size(434, 51);
=======
            this.tenTK.Size = new System.Drawing.Size(651, 79);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.tenTK.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.label4.Location = new System.Drawing.Point(328, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 21);
=======
            this.label4.Location = new System.Drawing.Point(492, 472);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 32);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.label4.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.label3.Location = new System.Drawing.Point(326, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 21);
=======
            this.label3.Location = new System.Drawing.Point(489, 472);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 32);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên tài khoản (*)";
            // 
            // SuaTaiKhoan
            // 
<<<<<<< HEAD
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(156)))), ((int)(((byte)(156)))));
            this.ClientSize = new System.Drawing.Size(1386, 788);
=======
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(156)))), ((int)(((byte)(156)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.Controls.Add(this.suaTKExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
<<<<<<< HEAD
=======
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.Name = "SuaTaiKhoan";
            this.Text = "SuaTaiKhoan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.suaTKExit)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox suaTKExit;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox password;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2Button cancelButton;
        private Guna.UI2.WinForms.Guna2Button saveButton;
        private Guna.UI2.WinForms.Guna2TextBox tenTK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox maNV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
    }
}