using System;
using System.Data;

namespace QuanLyThueSach.Model
{
    public class ShiftInDay
    {
        public DateTime Day { get; set; }
        public int Number { get; set; }
        public ShiftInDay(DateTime day, int number)
        {
            Day = day;
            Number = number;
        }
        public ShiftInDay(DataRow row)
        {
            Day = (DateTime)row["day_work"];
            Number = (int)row["number"];
        }
    }
}
