using System;
using System.Windows.Forms;
using QuanLyThueSach.Model;
using QuanLyThueSach.Forms.Account;

namespace QuanLyThueSach.Forms.Manager
{
    public partial class FCenter : Form
    {
        private Employee _employee { get; set; }
        public FCenter(Employee employee)
        {
            InitializeComponent();

            _employee = employee;

            txtTitle.Text = $"Xin chào: {employee.Username}";
        }

        private void UserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FProfile fProfile = new FProfile(_employee);
            this.Hide();
            fProfile.ShowDialog();
            this.Show();
        }

        private void ScheduleWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCalendarWork fCalendarWork = new FCalendarWork(_employee);
            this.Hide();
            fCalendarWork.ShowDialog();
            this.Show();
        }
    }
}
