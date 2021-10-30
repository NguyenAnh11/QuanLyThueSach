using System.Data;

namespace QuanLyThueSach.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BaseEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public BaseEntity(DataRow row)
        {
            Id = row.Field<int>("id");
            Name = row.Field<string>("name");
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
