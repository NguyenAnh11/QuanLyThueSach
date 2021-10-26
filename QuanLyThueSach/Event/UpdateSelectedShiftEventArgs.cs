using System;


namespace QuanLyThueSach.Event
{
    public class UpdateSelectedShiftEventArgs:EventArgs
    {
        public int Id { get; set; }
        public bool Selected { get; set; }
        public UpdateSelectedShiftEventArgs(int id, bool selected)
        {
            Id = id;
            Selected = selected;
        }
    }
}
