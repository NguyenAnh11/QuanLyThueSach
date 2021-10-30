using System.Data;

namespace QuanLyThueSach.Model
{
    public class Publisher : BaseEntity
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public Publisher(int id, string name, string address, string phone) : base(id, name)
        {
            Address = address;
            Phone = phone;
        }
        public Publisher(DataRow row) : base(row)
        {
            Phone = row.Field<string>("phone");
            Address = row.Field<string>("address") ?? string.Empty;
        }
    }
}
