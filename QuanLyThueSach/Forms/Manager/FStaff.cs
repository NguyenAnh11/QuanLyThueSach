using System;
using System.Windows.Forms;
using QuanLyThueSach.Model;
using QuanLyThueSach.Forms.Account;

namespace QuanLyThueSach.Forms.Manager
{
    public partial class FStaff : Form
    {
        private Person Person { get; set; }
        public FStaff(Person person)
        {
            InitializeComponent();
            Person = person;

            txtTitle.Text = $"Xin chào: {person.Username}";
        }

        private void UserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAccountEmployeeInfo fAccount = new FAccountEmployeeInfo(Person);
            this.Hide();
            fAccount.ShowDialog();
            this.Show();
        }
    }
}
