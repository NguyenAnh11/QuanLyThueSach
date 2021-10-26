using System.Windows.Forms;
using QuanLyThueSach.DTO;

namespace QuanLyThueSach.Forms.Controls
{
    public partial class UsrShiftItem : UserControl
    {
        private ShiftDto _shiftDto;
        public UsrShiftItem(ShiftDto shiftDto)
        {
            InitializeComponent();

            _shiftDto = shiftDto;
        }

        private void UsrShiftInfo_Load(object sender, System.EventArgs e)
        {
            end.Text = _shiftDto.Finish;

            start.Text = _shiftDto.Start;

            cb.Checked = _shiftDto.IsSelected;

            cb.Text = _shiftDto.Name;

            cb.Tag = _shiftDto.Id;
        }
    }
}
