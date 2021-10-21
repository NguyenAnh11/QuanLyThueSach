using System;

namespace QuanLyThueSach.DTO.Account
{
    public class PasswordUpdateDto
    {
        public string OldPass { get; set; }
        public string NewPass { get; set; }
        public string New2Pass { get; set; }

        public PasswordUpdateDto(string oldPass, string newPass, string new2Pass)
        {
            OldPass = oldPass;
            NewPass = newPass;
            New2Pass = new2Pass;
        }
    }

}
