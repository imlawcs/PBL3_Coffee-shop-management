namespace PBL3.GUI
{
    partial class DangNhap
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
            this.label1 = new System.Windows.Forms.Label();
            this.rbManager = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new Guna.UI2.WinForms.Guna2TextBox();
            this.username = new Guna.UI2.WinForms.Guna2TextBox();
            this.exitLogin = new Guna.UI2.WinForms.Guna2Button();
            this.rbStaff = new System.Windows.Forms.RadioButton();
            this.close = new Guna.UI2.WinForms.Guna2PictureBox();
            this.open = new Guna.UI2.WinForms.Guna2PictureBox();
            this.loginButton = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.open)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 36F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
<<<<<<< HEAD
            this.label1.Location = new System.Drawing.Point(528, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 57);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đăng nhập";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2Panel1.Controls.Add(this.close);
            this.guna2Panel1.Controls.Add(this.open);
            this.guna2Panel1.Controls.Add(this.loginButton);
            this.guna2Panel1.Controls.Add(this.rbStaff);
            this.guna2Panel1.Controls.Add(this.rbManager);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.password);
            this.guna2Panel1.Controls.Add(this.username);
            this.guna2Panel1.Location = new System.Drawing.Point(473, 276);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(435, 316);
            this.guna2Panel1.TabIndex = 3;
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.White;
            this.close.Image = global::PBL3.Properties.Resources.eye_close_line;
            this.close.Location = new System.Drawing.Point(368, 150);
            this.close.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(20, 16);
            this.close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.close.TabIndex = 6;
            this.close.TabStop = false;
            this.close.MouseLeave += new System.EventHandler(this.mouseLeave);
            this.close.MouseHover += new System.EventHandler(this.mouseHover);
            // 
            // open
            // 
            this.open.BackColor = System.Drawing.Color.White;
            this.open.Image = global::PBL3.Properties.Resources.eye_line;
            this.open.Location = new System.Drawing.Point(368, 149);
            this.open.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(20, 18);
            this.open.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.open.TabIndex = 7;
            this.open.TabStop = false;
            this.open.Visible = false;
            // 
            // loginButton
            // 
            this.loginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginButton.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.loginButton.BorderRadius = 20;
            this.loginButton.BorderThickness = 2;
            this.loginButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.loginButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.loginButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.loginButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.loginButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.loginButton.FocusedColor = System.Drawing.Color.WhiteSmoke;
            this.loginButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.Location = new System.Drawing.Point(129, 234);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(158, 47);
            this.loginButton.TabIndex = 6;
            this.loginButton.Text = "ĐĂNG NHẬP";
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // rbStaff
            // 
            this.rbStaff.AutoSize = true;
            this.rbStaff.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.rbStaff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbStaff.Location = new System.Drawing.Point(232, 193);
            this.rbStaff.Name = "rbStaff";
            this.rbStaff.Size = new System.Drawing.Size(86, 19);
            this.rbStaff.TabIndex = 5;
            this.rbStaff.TabStop = true;
            this.rbStaff.Text = "Nhân viên";
            this.rbStaff.UseVisualStyleBackColor = true;
            // 
=======
            this.label1.Location = new System.Drawing.Point(731, 206);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 84);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đăng nhập";
            // 
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            // rbManager
            // 
            this.rbManager.AutoSize = true;
            this.rbManager.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.rbManager.ImeMode = System.Windows.Forms.ImeMode.NoControl;
<<<<<<< HEAD
            this.rbManager.Location = new System.Drawing.Point(116, 193);
            this.rbManager.Name = "rbManager";
            this.rbManager.Size = new System.Drawing.Size(71, 19);
=======
            this.rbManager.Location = new System.Drawing.Point(771, 681);
            this.rbManager.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbManager.Name = "rbManager";
            this.rbManager.Size = new System.Drawing.Size(104, 27);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.rbManager.TabIndex = 4;
            this.rbManager.TabStop = true;
            this.rbManager.Text = "Quản lý";
            this.rbManager.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
<<<<<<< HEAD
            this.label3.Location = new System.Drawing.Point(29, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 19);
=======
            this.label3.Location = new System.Drawing.Point(633, 523);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 28);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật khẩu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
<<<<<<< HEAD
            this.label2.Location = new System.Drawing.Point(28, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 19);
=======
            this.label2.Location = new System.Drawing.Point(633, 354);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 28);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên đăng nhập:";
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
            this.password.IconLeft = global::PBL3.Properties.Resources.lock_line;
<<<<<<< HEAD
            this.password.Location = new System.Drawing.Point(32, 137);
            this.password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
=======
            this.password.Location = new System.Drawing.Point(638, 581);
            this.password.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.PlaceholderText = "";
            this.password.SelectedText = "";
<<<<<<< HEAD
            this.password.Size = new System.Drawing.Size(368, 39);
=======
            this.password.Size = new System.Drawing.Size(722, 60);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.password.TabIndex = 1;
            // 
            // username
            // 
            this.username.BorderRadius = 10;
            this.username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.username.DefaultText = "";
            this.username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.username.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.username.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.username.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.username.IconLeft = global::PBL3.Properties.Resources.user_fill;
<<<<<<< HEAD
            this.username.Location = new System.Drawing.Point(32, 54);
            this.username.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
=======
            this.username.Location = new System.Drawing.Point(638, 414);
            this.username.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.username.Name = "username";
            this.username.PasswordChar = '\0';
            this.username.PlaceholderText = "";
            this.username.SelectedText = "";
<<<<<<< HEAD
            this.username.Size = new System.Drawing.Size(368, 39);
            this.username.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::PBL3.Properties.Resources.Coffee_Stamp_Round_Loyalty_Card_Mini_Self_Inking_Stamp_Coffee_Bean_Coffee_Cup_Coffee_Mug_Coffee_Latte_Hot_Coffee_Coffee_Takeaway;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(788, 191);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
=======
            this.username.Size = new System.Drawing.Size(722, 60);
            this.username.TabIndex = 0;
            // 
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            // exitLogin
            // 
            this.exitLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.exitLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.exitLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.exitLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.exitLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.exitLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.exitLogin.ForeColor = System.Drawing.Color.White;
            this.exitLogin.Image = global::PBL3.Properties.Resources.close_large_line;
<<<<<<< HEAD
            this.exitLogin.Location = new System.Drawing.Point(1301, 24);
            this.exitLogin.Name = "exitLogin";
            this.exitLogin.Size = new System.Drawing.Size(45, 43);
=======
            this.exitLogin.Location = new System.Drawing.Point(1713, 59);
            this.exitLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.exitLogin.Name = "exitLogin";
            this.exitLogin.Size = new System.Drawing.Size(145, 98);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.exitLogin.TabIndex = 4;
            this.exitLogin.Click += new System.EventHandler(this.exitButton2_Click);
            // 
            // rbStaff
            // 
            this.rbStaff.AutoSize = true;
            this.rbStaff.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.rbStaff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbStaff.Location = new System.Drawing.Point(1140, 681);
            this.rbStaff.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbStaff.Name = "rbStaff";
            this.rbStaff.Size = new System.Drawing.Size(128, 27);
            this.rbStaff.TabIndex = 5;
            this.rbStaff.TabStop = true;
            this.rbStaff.Text = "Nhân viên";
            this.rbStaff.UseVisualStyleBackColor = true;
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.White;
            this.close.Image = global::PBL3.Properties.Resources.eye_close_line;
            this.close.ImageRotate = 0F;
            this.close.Location = new System.Drawing.Point(1299, 594);
            this.close.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(46, 39);
            this.close.TabIndex = 7;
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // open
            // 
            this.open.BackColor = System.Drawing.Color.White;
            this.open.Image = global::PBL3.Properties.Resources.eye_line;
            this.open.ImageRotate = 0F;
            this.open.Location = new System.Drawing.Point(1299, 594);
            this.open.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(50, 39);
            this.open.TabIndex = 8;
            this.open.TabStop = false;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // loginButton
            // 
            this.loginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginButton.BorderColor = System.Drawing.Color.White;
            this.loginButton.BorderRadius = 20;
            this.loginButton.BorderThickness = 2;
            this.loginButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.loginButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.loginButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.loginButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.loginButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.loginButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.Location = new System.Drawing.Point(817, 738);
            this.loginButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(381, 70);
            this.loginButton.TabIndex = 9;
            this.loginButton.Text = "ĐĂNG NHẬP";
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click_1);
            // 
            // DangNhap
            // 
<<<<<<< HEAD
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.guna2Panel1);
=======
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.close);
            this.Controls.Add(this.open);
            this.Controls.Add(this.password);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.Controls.Add(this.exitLogin);
            this.Controls.Add(this.rbStaff);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbManager);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
<<<<<<< HEAD
=======
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
>>>>>>> 84a749c2ce0818e9ad05027b80fc6f9105d4857a
            this.Name = "DangNhap";
            this.Text = "x";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.open)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox password;
        private Guna.UI2.WinForms.Guna2TextBox username;
        private System.Windows.Forms.RadioButton rbManager;
        private Guna.UI2.WinForms.Guna2Button exitLogin;
        private System.Windows.Forms.RadioButton rbStaff;
        private Guna.UI2.WinForms.Guna2PictureBox close;
        private Guna.UI2.WinForms.Guna2PictureBox open;
        private Guna.UI2.WinForms.Guna2Button loginButton;
    }
}