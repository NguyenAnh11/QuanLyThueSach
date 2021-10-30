using System.Data;

namespace QuanLyThueSach.Model
{
    public class Language : BaseEntity
    {
        public Language(int id, string name) : base(id, name)
        {
        }
        public Language(DataRow row) : base(row)
        {
        }
    }
}
