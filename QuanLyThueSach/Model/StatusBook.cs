using System.Data;

namespace QuanLyThueSach.Model
{
    public class StatusBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StatusBook(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public StatusBook(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
