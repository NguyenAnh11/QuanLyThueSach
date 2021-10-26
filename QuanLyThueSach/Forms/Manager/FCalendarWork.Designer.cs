
namespace QuanLyThueSach.Forms.Manager
{
    partial class FCalendarWork
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
            this.panelCalendar = new System.Windows.Forms.Panel();
            this.panelCalendarInfo = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelCalendar
            // 
            this.panelCalendar.Location = new System.Drawing.Point(0, 0);
            this.panelCalendar.Name = "panelCalendar";
            this.panelCalendar.Size = new System.Drawing.Size(590, 371);
            this.panelCalendar.TabIndex = 0;
            // 
            // panelCalendarInfo
            // 
            this.panelCalendarInfo.Location = new System.Drawing.Point(595, 0);
            this.panelCalendarInfo.Name = "panelCalendarInfo";
            this.panelCalendarInfo.Size = new System.Drawing.Size(228, 371);
            this.panelCalendarInfo.TabIndex = 1;
            // 
            // FEmployeeScheduleWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 372);
            this.Controls.Add(this.panelCalendarInfo);
            this.Controls.Add(this.panelCalendar);
            this.Name = "FEmployeeScheduleWork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch công việc";
            this.Load += new System.EventHandler(this.FEmployeeScheduleWork_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCalendar;
        private System.Windows.Forms.Panel panelCalendarInfo;
    }
}