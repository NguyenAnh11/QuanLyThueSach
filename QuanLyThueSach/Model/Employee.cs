using System;
using System.Data;

namespace QuanLyThueSach.Model
{
    public class Employee:Person
    {
       public int? Salary { get; set; }
       public Employee(int id, string username, DateTime? birthday, int gender, string address, string avatar, string phone, int role, int? salary) 
            :base(id, username, birthday, gender, address, avatar, phone)
        {
            Salary = salary;
        }
       public Employee(DataRow row) : base(row)
        {
            Salary = row.IsNull("salary") ? null : (int?)row["salary"];
        }
    }
}
