using QuanLyThueSach.Model;
using System.Windows.Forms;

namespace QuanLyThueSach.Forms.Controls
{
    public partial class UsrShiftInfo : UserControl
    {
        private readonly Shift _shift;
        private bool _selected;
        public UsrShiftInfo(Shift shift, bool selected)
        {
            InitializeComponent();
            _shift = shift;
            _selected = selected;
        }

        private void UsrShiftInfo_Load(object sender, System.EventArgs e)
        {
            start.Text = _shift.Start;
            end.Text = _shift.Finish;
            cb.Checked = _selected;
            cb.Text = _shift.Name;
        }
    }
}
