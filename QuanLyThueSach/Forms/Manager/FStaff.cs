using System;
using System.Windows.Forms;
using QuanLyThueSach.Model;

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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không", "Đăng xuất", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else return;
        }
    }
}
