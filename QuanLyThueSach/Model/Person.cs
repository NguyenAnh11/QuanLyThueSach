using System;
using System.Data;
using System.Diagnostics;

namespace QuanLyThueSach.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Gender { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public int Role { get; set; }
        public Person(int id, string username, DateTime? birthday, int? gender, string address, int roleId, string avatar)
        {
            Id = id;
            Username = username;
            Birthday = birthday;
            Gender = gender;
            Address = string.IsNullOrEmpty(address) ? string.Empty : address;
            Role = roleId;
            Avatar = string.IsNullOrEmpty(avatar) ? string.Empty : avatar;
        }
        public Person(DataRow row)
        {
            Id = (int)row["id"];
            Username = row["display_name"].ToString();
            Birthday = row.IsNull("birthday") ? null : (DateTime?)row["birthday"];
            Gender = row.IsNull("gender") ? null : (int?)row["gender"];
            Address = row.IsNull("address") ? null : string.Empty;
            Role = (int)row["role"];
            Avatar = row.IsNull("avatar") ? null : string.Empty;
        }
    }
}
