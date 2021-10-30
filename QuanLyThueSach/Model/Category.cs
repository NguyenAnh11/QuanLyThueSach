using System.Data;

namespace QuanLyThueSach.Model
{
    public class Category : BaseEntity
    { 

        public Category(int id, string name) : base(id, name)
        {
        }

        public Category(DataRow row) : base(row)
        {

        }

    }
}
