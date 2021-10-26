
namespace QuanLyThueSach.Forms.Controls
{
    partial class UsrCalendar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnYearNext = new System.Windows.Forms.Button();
            this.btnYearPrev = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnMonthNext = new System.Windows.Forms.Button();
            this.btnMonthPrev = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.btnSelectDate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gridCalendar = new System.Windows.Forms.DataGridView();
            this.colorCalendarInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCalendar)).BeginInit();
            this.SuspendLayout();
            // 
            // cbMonth
            // 
            this.cbMonth.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Location = new System.Drawing.Point(0, 0);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(163, 21);
            this.cbMonth.TabIndex = 0;
            this.cbMonth.SelectedIndexChanged += new System.EventHandler(this.cbMonth_SelectedIndexChanged);
            // 
            // cbYear
            // 
            this.cbYear.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(291, 0);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(168, 21);
            this.cbYear.TabIndex = 1;
            this.cbYear.SelectedIndexChanged += new System.EventHandler(this.cbYear_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnToday);
            this.panel1.Controls.Add(this.btnSelectDate);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Location = new System.Drawing.Point(465, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 320);
            this.panel1.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnYearNext);
            this.panel4.Controls.Add(this.btnYearPrev);
            this.panel4.Location = new System.Drawing.Point(0, 210);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(124, 41);
            this.panel4.TabIndex = 4;
            // 
            // btnYearNext
            // 
            this.btnYearNext.Image = global::QuanLyThueSach.Properties.Resources.ArrowRightDouble;
            this.btnYearNext.Location = new System.Drawing.Point(75, 6);
            this.btnYearNext.Name = "btnYearNext";
            this.btnYearNext.Size = new System.Drawing.Size(32, 32);
            this.btnYearNext.TabIndex = 1;
            this.btnYearNext.UseVisualStyleBackColor = true;
            this.btnYearNext.Click += new System.EventHandler(this.btnYearNext_Click);
            // 
            // btnYearPrev
            // 
            this.btnYearPrev.Image = global::QuanLyThueSach.Properties.Resources.ArrowLeftDouble;
            this.btnYearPrev.Location = new System.Drawing.Point(12, 6);
            this.btnYearPrev.Name = "btnYearPrev";
            this.btnYearPrev.Size = new System.Drawing.Size(32, 32);
            this.btnYearPrev.TabIndex = 0;
            this.btnYearPrev.UseVisualStyleBackColor = true;
            this.btnYearPrev.Click += new System.EventHandler(this.btnYearPrev_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnMonthNext);
            this.panel3.Controls.Add(this.btnMonthPrev);
            this.panel3.Location = new System.Drawing.Point(0, 163);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(124, 41);
            this.panel3.TabIndex = 3;
            // 
            // btnMonthNext
            // 
            this.btnMonthNext.Image = global::QuanLyThueSach.Properties.Resources.ArrowRight;
            this.btnMonthNext.Location = new System.Drawing.Point(75, 6);
            this.btnMonthNext.Name = "btnMonthNext";
            this.btnMonthNext.Size = new System.Drawing.Size(32, 32);
            this.btnMonthNext.TabIndex = 1;
            this.btnMonthNext.UseVisualStyleBackColor = true;
            this.btnMonthNext.Click += new System.EventHandler(this.btnMonthNext_Click);
            // 
            // btnMonthPrev
            // 
            this.btnMonthPrev.Image = global::QuanLyThueSach.Properties.Resources.ArrowLeft;
            this.btnMonthPrev.Location = new System.Drawing.Point(12, 6);
            this.btnMonthPrev.Name = "btnMonthPrev";
            this.btnMonthPrev.Size = new System.Drawing.Size(32, 32);
            this.btnMonthPrev.TabIndex = 0;
            this.btnMonthPrev.UseVisualStyleBackColor = true;
            this.btnMonthPrev.Click += new System.EventHandler(this.btnMonthPrev_Click);
            // 
            // btnToday
            // 
            this.btnToday.Location = new System.Drawing.Point(23, 117);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(75, 23);
            this.btnToday.TabIndex = 2;
            this.btnToday.Text = "Hôm nay";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // btnSelectDate
            // 
            this.btnSelectDate.Location = new System.Drawing.Point(23, 73);
            this.btnSelectDate.Name = "btnSelectDate";
            this.btnSelectDate.Size = new System.Drawing.Size(75, 23);
            this.btnSelectDate.TabIndex = 1;
            this.btnSelectDate.Text = "Chọn";
            this.btnSelectDate.UseVisualStyleBackColor = true;
            this.btnSelectDate.Click += new System.EventHandler(this.btnSelectDate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(23, 27);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gridCalendar
            // 
            this.gridCalendar.AllowUserToAddRows = false;
            this.gridCalendar.AllowUserToDeleteRows = false;
            this.gridCalendar.AllowUserToResizeColumns = false;
            this.gridCalendar.AllowUserToResizeRows = false;
            this.gridCalendar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCalendar.Location = new System.Drawing.Point(0, 28);
            this.gridCalendar.Name = "gridCalendar";
            this.gridCalendar.Size = new System.Drawing.Size(459, 292);
            this.gridCalendar.TabIndex = 3;
            this.gridCalendar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCalendar_CellClick);
            this.gridCalendar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCalendar_CellDoubleClick);
            // 
            // colorCalendarInfo
            // 
            this.colorCalendarInfo.Location = new System.Drawing.Point(0, 327);
            this.colorCalendarInfo.Name = "colorCalendarInfo";
            this.colorCalendarInfo.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.colorCalendarInfo.Size = new System.Drawing.Size(459, 44);
            this.colorCalendarInfo.TabIndex = 4;
            // 
            // UsrCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.colorCalendarInfo);
            this.Controls.Add(this.gridCalendar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.cbMonth);
            this.Name = "UsrCalendar";
            this.Size = new System.Drawing.Size(590, 371);
            this.Load += new System.EventHandler(this.UsrCalendar_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCalendar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnYearNext;
        private System.Windows.Forms.Button btnYearPrev;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnMonthNext;
        private System.Windows.Forms.Button btnMonthPrev;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button btnSelectDate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView gridCalendar;
        private System.Windows.Forms.FlowLayoutPanel colorCalendarInfo;
    }
}
