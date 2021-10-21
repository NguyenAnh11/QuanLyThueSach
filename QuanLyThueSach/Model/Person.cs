using System;
using System.IO;
using System.Data;
using System.Diagnostics;

namespace QuanLyThueSach.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime? Birthday { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
        public Person(int id, string username, DateTime? birthday, int gender, string address, string avatar, string phone)
        {
            Id = id;
            Username = username;
            Birthday = birthday;
            Gender = gender;
            Address = address;
            Avatar = avatar;
            Phone = phone;
        }
        public Person(DataRow row)
        {
            Id = (int)row["id"];
            Username = row["display_name"].ToString();
            Birthday = row.IsNull("birthday") ? null : (DateTime?)row["birthday"];
            Gender = (int)row["gender"];
            Address = row.IsNull("address") ? null : row["address"].ToString();
            Avatar = row["avatar"].ToString();
            Phone = row["phone"].ToString();
        }
    }
}
