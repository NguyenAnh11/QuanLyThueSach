using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using QuanLyThueSach.Model;
using QuanLyThueSach.DAO;
using QuanLyThueSach.DTO.Account;
using QuanLyThueSach.DTO.Staff;
using System.Text.RegularExpressions;

namespace QuanLyThueSach.Forms.Account
{
    public partial class FEmployeeProfile : Form
    {
        private Employee _employee { get; set; }
        private ImageEx _imageEx { get; set; }
        private OpenFileDialog _openFileDialog { get; set;}
        private IList<TextBox> _lTextBox { get; set; }
        private IList<CheckBox> _lCheckBox { get; set; }
        public FEmployeeProfile(Employee employee)
        {
            InitializeComponent();

            _employee = employee;

            _openFileDialog = new OpenFileDialog();
            _openFileDialog.Filter = "Image Files(*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";

            if (_employee.Avatar != Folder.DefaultAvatar)
            {
                btnRemoveAvatar.Enabled = true;
            } else
            {
                btnRemoveAvatar.Enabled = false;
            }

            _lTextBox = new List<TextBox>() { txtOldPass, txtNewPass, txt2NewPass };
            _lCheckBox = new List<CheckBox>() { cbOldPass, cbNewPass, cb2NewPass };

            LoadData(_employee);
        }

        public void LoadData(Employee employee)
        {

            txtId.Text = employee.Id.ToString();

            txtUsername.Text = employee.Username;

            dateBirthday.Value = employee.Birthday.HasValue == false ? DateTime.Now : employee.Birthday.Value;
            
            if(employee.Gender == (int)Gender.Male)
            {
                rdbMale.Checked = true;
            } 
            else if(employee.Gender == (int)Gender.Female)
            {
                rdbFemale.Checked = true;
            }

            txtAddress.Text = employee.Address;

            if(employee.Role == (int)Role.Admin)
            {
                rdbAdmin.Checked = true;
            }
            else if(employee.Role == (int)Role.Staff)
            {
                rdbStaff.Checked = true;
            }

            pictureAvatar.Image = Image.FromFile(employee.Avatar);

            txtPhone.Text = employee.Phone;
        }

        private void btnChooseAvatar_Click(object sender, EventArgs e)
        {
            DialogResult result = _openFileDialog.ShowDialog();
            
            if(result == DialogResult.OK)
            {
                string name = _openFileDialog.FileName;

                _imageEx = new ImageEx(name);

                pictureAvatar.Image = _imageEx.Image;

                btnRemoveAvatar.Enabled = true;
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();
            int gender = rdbMale.Checked ? (int)Gender.Male : (int)Gender.Female;

            DateTime birthday = dateBirthday.Value;

            string avatar = _employee.Avatar;

            try
            {
                if (_imageEx != null)
                {
                    string format = Path.GetExtension(_imageEx.FileName);

                    avatar = Path.Combine(Folder.Images, Guid.NewGuid().ToString() + format);
                }


                if (string.IsNullOrEmpty(username) || username.Length > 255)
                {
                    throw new Exception("Họ tên không để rỗng và có độ dài tối đa 255 ký tự");
                }

                int year = DateTime.Now.Year;
                if(birthday.Year > year - 18)
                {
                    throw new Exception("Yêu cầu trên 18 tuổi");
                }
                
                var employeeDto = new EmployeeUpdateByStaffDto(_employee.Id, username, birthday, gender, address, phone, avatar);

                int row = AccountDAO.Instance().UpdateProfile(employeeDto);

                if(row == 1)
                {
                    MessageBox.Show("Cập nhật thông tin thành công");

                    if(_imageEx != null)
                    {
                        File.Copy(_imageEx.FileName, avatar);
                    }

                    _employee.Username = username;
                    _employee.Address = address;
                    _employee.Phone = phone;
                    _employee.Gender = gender;
                    _employee.Birthday = birthday;
                    _employee.Avatar = avatar;
                }


            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnRemoveAvatar_Click(object sender, EventArgs e)
        {
            pictureAvatar.Image = Image.FromFile(Folder.DefaultAvatar);

            if(_imageEx == null)
            {
                _imageEx = new ImageEx(Folder.DefaultAvatar);
            } else
            {
                _imageEx.FileName = Folder.DefaultAvatar;
            }

            btnRemoveAvatar.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn hủy thay đổi", "Hủy", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }
    
        private void btnUpdatePass_Click(object sender, EventArgs e)
        {
            string oldPass = txtOldPass.Text.Trim();

            string newPass = txtNewPass.Text.Trim();

            string new2Pass = txt2NewPass.Text.Trim();

            try
            {
                var passwordDTO = new PasswordUpdateDto(oldPass, newPass, new2Pass);

                string pattern = @"\d{6,30}";

                Regex regex = new Regex(pattern);

                IDictionary<string, string> passDict = new Dictionary<string, string>();

                passDict.Add("Mật khẩu cũ", oldPass);
                passDict.Add("Mật khẩu mới", newPass);
                passDict.Add("Nhập lại mật khẩu mới", new2Pass);

                foreach (var kvp in passDict)
                {
                    if (!regex.IsMatch(kvp.Value))
                    {
                        throw new Exception($"{kvp.Key} chỉ chứa số và có độ dài 6 - 30 ký tự");
                    }
                }

                if(new2Pass != newPass)
                {
                    throw new Exception("Nhập lại mật khẩu mới không khớp với mật khẩu mới");
                }

                int row = AccountDAO.Instance().UpdatePassword(_employee.Id, passwordDTO);

                if(row == 1)
                {
                    MessageBox.Show("Thay đổi thành công");
                }
               
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbOldPass_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            int index = _lCheckBox.IndexOf(checkbox);
            if (checkbox.Checked)
            {
                _lTextBox[index].UseSystemPasswordChar = false;
            } else
            {
                _lTextBox[index].UseSystemPasswordChar = true;
            }
        }

        private void cbNewPass_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            int index = _lCheckBox.IndexOf(checkbox);
            if (checkbox.Checked)
            {
                _lTextBox[index].UseSystemPasswordChar = false;
            }
            else
            {
                _lTextBox[index].UseSystemPasswordChar = true;
            }
        }

        private void cb2NewPass_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            int index = _lCheckBox.IndexOf(checkbox);
            if (checkbox.Checked)
            {
                _lTextBox[index].UseSystemPasswordChar = false;
            }
            else
            {
                _lTextBox[index].UseSystemPasswordChar = true;
            }
        }

        private void btnCancelPass_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn dừng sự thay đổi này", "Thoát", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                this.Close();
            } else
            {
                return;
            }
        }
    }
}
