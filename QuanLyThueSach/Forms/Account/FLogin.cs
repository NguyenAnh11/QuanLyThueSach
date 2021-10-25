using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;
using QuanLyThueSach.DTO;
using QuanLyThueSach.DAO;
using QuanLyThueSach.Model;
using QuanLyThueSach.Forms.Manager;

namespace QuanLyThueSach.Forms.Account
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không", "Thoát", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else return;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;

            try
            {
                string pattern = @"^[a-zA-Z0-9]{6,30}";

                Regex regex = new Regex(pattern);

                IDictionary<string, string> loginDict = new Dictionary<string, string>();

                loginDict.Add("Tên đăng nhâp", username);
                loginDict.Add("Mật khẩu", password);

                foreach(var kvp in loginDict)
                {
                    if (!regex.IsMatch(kvp.Value))
                    {
                        throw new Exception($"{kvp.Key} chứa 6 - 30 ký tự và không chứa ký tự đặc biệt");
                    }
                }

                var account = new LoginDto(username, password);

                var employee = (Employee)AccountDAO.Instance().Login(account);

                if (employee == null)
                {
                    throw new Exception("Tên đăng nhập hoặc mật khẩu không chính xác");
                }
                else
                {
                    MessageBox.Show($"Đăng nhập thành công. Xin chào: {employee.Username}");
                    if (employee.Role == (int)Role.Staff)
                    {
                        var fStaff = new FStaff(employee);
                        this.Hide();
                        fStaff.ShowDialog();
                        this.Show();
                    }
                }

            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

    }
}
