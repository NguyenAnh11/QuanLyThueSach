
namespace QuanLyThueSach.Forms.Controls
{
    partial class UsrShift
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
            this.label1 = new System.Windows.Forms.Label();
            this.flowPanelShifts = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin ca làm việc";
            // 
            // flowPanelShifts
            // 
            this.flowPanelShifts.AutoScroll = true;
            this.flowPanelShifts.Location = new System.Drawing.Point(0, 73);
            this.flowPanelShifts.Name = "flowPanelShifts";
            this.flowPanelShifts.Padding = new System.Windows.Forms.Padding(10);
            this.flowPanelShifts.Size = new System.Drawing.Size(228, 298);
            this.flowPanelShifts.TabIndex = 1;
            // 
            // UsrShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowPanelShifts);
            this.Controls.Add(this.label1);
            this.Name = "UsrShift";
            this.Size = new System.Drawing.Size(228, 371);
            this.Load += new System.EventHandler(this.UsrShift_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowPanelShifts;
    }
}
