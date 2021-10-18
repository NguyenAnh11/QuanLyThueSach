using System;
using System.Data;

namespace QuanLyThueSach.Model
{
    public class Customer:Person
    {
        public Customer(DataRow row) : base(row) { }
    }
}
