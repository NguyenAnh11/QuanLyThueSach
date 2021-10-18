using System;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using QuanLyThueSach.DTO.Account;
using QuanLyThueSach.DAO;
using QuanLyThueSach.Model;

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

            var account = new AccountLoginDTO(username, password);
            var validator = new AccountLoginValidator();
            var result = validator.Validate(account);
            if (!result.IsValid)
            {
                IDictionary<string, string> errorDict = new Dictionary<string, string>();
                foreach(var error in result.Errors)
                {
                    if (!errorDict.ContainsKey(error.PropertyName))
                    {
                        errorDict.Add(error.PropertyName, error.ErrorMessage);
                    }
                }
                var errorMessage = new StringBuilder();
                foreach(var item in errorDict)
                {
                    errorMessage.AppendLine(item.Value);
                }
                MessageBox.Show(errorMessage.ToString());
                return;
            } else
            {
                var person = AccountDAO.Instance().Login(username, password);
                if(person == null)
                {
                    MessageBox.Show("Bạn đăng nhập thất bại");
                } else
                {
                    MessageBox.Show("Bạn đăng nhập thành công");
                    int role = person.Role;
                    if(role == (int)Role.Admin)
                    {

                    } else if(role == (int)Role.Staff)
                    {

                    }
                }
            }
        }

    }
}
