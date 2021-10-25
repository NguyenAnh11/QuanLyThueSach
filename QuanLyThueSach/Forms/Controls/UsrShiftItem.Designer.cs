
namespace QuanLyThueSach.Forms.Controls
{
    partial class UsrShiftItem
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
            this.cb = new System.Windows.Forms.CheckBox();
            this.start = new System.Windows.Forms.Label();
            this.end = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb
            // 
            this.cb.AutoSize = true;
            this.cb.Location = new System.Drawing.Point(0, 18);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(15, 14);
            this.cb.TabIndex = 0;
            this.cb.UseVisualStyleBackColor = true;
            // 
            // start
            // 
            this.start.AutoSize = true;
            this.start.Location = new System.Drawing.Point(76, 18);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(29, 13);
            this.start.TabIndex = 1;
            this.start.Text = "Start";
            // 
            // end
            // 
            this.end.AutoSize = true;
            this.end.Location = new System.Drawing.Point(160, 18);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(26, 13);
            this.end.TabIndex = 2;
            this.end.Text = "End";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = ":";
            // 
            // UsrShiftItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.end);
            this.Controls.Add(this.start);
            this.Controls.Add(this.cb);
            this.Name = "UsrShiftItem";
            this.Size = new System.Drawing.Size(199, 48);
            this.Load += new System.EventHandler(this.UsrShiftInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb;
        private System.Windows.Forms.Label start;
        private System.Windows.Forms.Label end;
        private System.Windows.Forms.Label label1;
    }
}
