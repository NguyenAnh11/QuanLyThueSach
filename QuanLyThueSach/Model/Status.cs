using System.Data;

namespace QuanLyThueSach.Model
{
    public class Status : BaseEntity
    {
        public Status(int id, string name) : base(id, name)
        {
        }

        public Status(DataRow row) : base(row)
        {
        }
    }
}
