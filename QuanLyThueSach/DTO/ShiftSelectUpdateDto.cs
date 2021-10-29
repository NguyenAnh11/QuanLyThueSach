using System;


namespace QuanLyThueSach.DTO
{
    public class ShiftSelectUpdateDto:EventArgs
    {
        public int Id { get; set; }
        public bool Selected { get; set; }
        public ShiftSelectUpdateDto(int id, bool selected)
        {
            Id = id;
            Selected = selected;
        }
    }
}
