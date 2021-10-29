using System;
using System.Windows.Forms;
using QuanLyThueSach.Model;
using QuanLyThueSach.Forms.Account;
using QuanLyThueSach.Forms.Controls;

namespace QuanLyThueSach.Forms.Manager
{
    public partial class FCenter : Form
    {
        private Employee _employee { get; set; }
        
        public FCenter(Employee employee)
        {
            InitializeComponent();

            _employee = employee;

        }

        private void UserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fProfile = new FProfile(_employee);
            this.Hide();
            fProfile.ShowDialog();
            this.Show();
        }

        private void ScheduleWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fCalendarWork = new FCalendarWork(_employee);
            this.Hide();
            fCalendarWork.ShowDialog();
            this.Show();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();

            var usrManageBook = new UsrManageBook();

            panelMain.Controls.Add(usrManageBook);

          
        }
    }
}
