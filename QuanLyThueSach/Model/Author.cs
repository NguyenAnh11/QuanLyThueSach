using System;
using System.Data;

namespace QuanLyThueSach.Model
{
    public class Author : BaseEntity
    {
        public DateTime Birthday { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public Author(int id, string name, DateTime birthday, int gender, string address) : base(id, name)
        {
            Birthday = birthday;
            Gender = gender;
            Address = address;
        }
        public Author(DataRow row) : base(row)
        {
            Birthday = row.Field<DateTime>("birthday") == null ? DateTime.Now : row.Field<DateTime>("birthday");
            Gender = row.Field<int>("gender");
            Address = row.Field<string>("address") ?? string.Empty;
        }
    }
}
