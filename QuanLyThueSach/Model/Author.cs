using System;
using System.Data;

namespace QuanLyThueSach.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public Author(int id, string name, DateTime birthday, int gender, string address)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
            Gender = gender;
            Address = address;
        }
        public Author(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
            Birthday = row.IsNull("birthday") ? DateTime.Now : (DateTime)row["birthday"];
            Gender = (int)row["gender"];
            Address = row.IsNull("address") ? string.Empty : row["address"].ToString();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
