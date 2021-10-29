using System.Data;

namespace QuanLyThueSach.Model
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Category(DataRow row)
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
