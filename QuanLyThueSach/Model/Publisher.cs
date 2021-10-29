using System.Data;

namespace QuanLyThueSach.Model
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Publisher(int id, string name, string address, string phone) 
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
        }
        public Publisher(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
            Phone = row["phone"].ToString();
            Address = row.IsNull("address") ? string.Empty : row["address"].ToString();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
