using System;
using System.Data;

namespace QuanLyThueSach.Model
{
    public class Shift
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Start { get; set; }
        public string Finish { get; set; }

        public Shift(int id, string name, string start, string finish)
        {
            Id = id;
            Name = name;
            Start = start;
            Finish = finish;
        }

        public Shift(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();

            var start = row["time_start"].ToString();

            Start = start.Remove(start.LastIndexOf(':'));

            var end = row["time_end"].ToString();

            Finish = end.Remove(end.LastIndexOf(':'));
        }
    }
}
