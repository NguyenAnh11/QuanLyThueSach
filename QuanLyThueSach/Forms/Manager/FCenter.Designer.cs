
namespace QuanLyThueSach.Forms.Manager
{
    partial class FCenter
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.UserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScheduleWorkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FunctionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panelMain = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UserInfoToolStripMenuItem,
            this.ScheduleWorkToolStripMenuItem,
            this.FunctionToolStripMenuItem,
            this.ManageToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1114, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // UserInfoToolStripMenuItem
            // 
            this.UserInfoToolStripMenuItem.Name = "UserInfoToolStripMenuItem";
            this.UserInfoToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.UserInfoToolStripMenuItem.Text = "Thông tin tài khoản";
            this.UserInfoToolStripMenuItem.Click += new System.EventHandler(this.UserInfoToolStripMenuItem_Click);
            // 
            // ScheduleWorkToolStripMenuItem
            // 
            this.ScheduleWorkToolStripMenuItem.Name = "ScheduleWorkToolStripMenuItem";
            this.ScheduleWorkToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.ScheduleWorkToolStripMenuItem.Text = "Lịch công việc";
            this.ScheduleWorkToolStripMenuItem.Click += new System.EventHandler(this.ScheduleWorkToolStripMenuItem_Click);
            // 
            // FunctionToolStripMenuItem
            // 
            this.FunctionToolStripMenuItem.Name = "FunctionToolStripMenuItem";
            this.FunctionToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.FunctionToolStripMenuItem.Text = "Chức năng";
            // 
            // ManageToolStripMenuItem
            // 
            this.ManageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BookToolStripMenuItem});
            this.ManageToolStripMenuItem.Name = "ManageToolStripMenuItem";
            this.ManageToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.ManageToolStripMenuItem.Text = "Quản lý thư mục";
            // 
            // BookToolStripMenuItem
            // 
            this.BookToolStripMenuItem.Name = "BookToolStripMenuItem";
            this.BookToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.BookToolStripMenuItem.Text = "Sách";
            this.BookToolStripMenuItem.Click += new System.EventHandler(this.BookToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.ExitToolStripMenuItem.Text = "Thoát";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(713, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(0, 28);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1123, 701);
            this.panelMain.TabIndex = 1;
            // 
            // FCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 726);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FCenter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bán sách";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem UserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScheduleWorkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FunctionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BookToolStripMenuItem;
        private System.Windows.Forms.Panel panelMain;
    }
}