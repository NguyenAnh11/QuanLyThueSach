using System;
using System.Data;

namespace QuanLyThueSach.Model
{
    public class Employee:Person
    {
       public string Phone { get; set; }
       public int? Salary { get; set; }
       public Employee(DataRow row) : base(row)
        {
            Phone = row["phone"].ToString();
            Salary = row.IsNull("salary") ? null : (int?)row["salary"];
        }
    }
}
