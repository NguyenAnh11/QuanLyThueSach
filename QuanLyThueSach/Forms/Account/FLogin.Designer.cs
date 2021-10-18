
namespace QuanLyThueSach.Forms.Account
{
    partial class FLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 292);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(189, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(293, 226);
            this.panel2.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(208, 188);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnSignIn);
            this.panel5.Location = new System.Drawing.Point(0, 116);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(293, 49);
            this.panel5.TabIndex = 2;
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(17, 14);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(75, 23);
            this.btnSignIn.TabIndex = 1;
            this.btnSignIn.Text = "Đăng nhập";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtPassword);
            this.panel4.Controls.Add(this.labelPassword);
            this.panel4.Location = new System.Drawing.Point(0, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(293, 52);
            this.panel4.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(115, 15);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(169, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(14, 22);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(52, 13);
            this.labelPassword.TabIndex = 0;
            this.labelPassword.Text = "Mật khẩu";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtUsername);
            this.panel3.Controls.Add(this.labelUsername);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(293, 52);
            this.panel3.TabIndex = 0;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(115, 15);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(169, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(14, 22);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(81, 13);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Tên đăng nhập";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyThueSach.Properties.Resources.default_avatar;
            this.pictureBox1.Location = new System.Drawing.Point(14, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 226);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 291);
            this.Controls.Add(this.panel1);
            this.Name = "FLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}