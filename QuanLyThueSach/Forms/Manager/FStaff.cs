using System;
using System.Windows.Forms;
using QuanLyThueSach.Model;
using QuanLyThueSach.Forms.Account;

namespace QuanLyThueSach.Forms.Manager
{
    public partial class FStaff : Form
    {
        private Employee _employee { get; set; }
        public FStaff(Employee employee)
        {
            InitializeComponent();

            _employee = employee;

            txtTitle.Text = $"Xin chào: {employee.Username}";
        }

        private void UserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FEmployeeProfile fAccount = new FEmployeeProfile(_employee);
            this.Hide();
            fAccount.ShowDialog();
            this.Show();
        }
    }
}
