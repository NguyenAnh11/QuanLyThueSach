using System.Data;
using QuanLyThueSach.Model;

namespace QuanLyThueSach.DTO
{
    public class ShiftDto: Shift
    {
        public bool IsSelected { get; set; }
        public ShiftDto(int id, string name, string start, string finish, bool isSelected)
            :base(id, name, start, finish)
        {
            IsSelected = isSelected;
        }
        public ShiftDto(DataRow row) : base(row)
        {
            IsSelected = row.IsNull("selected") ? false : true;
        }
    }
}
