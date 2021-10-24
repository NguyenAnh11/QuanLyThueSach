using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyThueSach.Model;

namespace QuanLyThueSach.Forms.Controls
{
    public partial class UsrShift : UserControl
    {
        //shift have in day
        private readonly IList<Shift> _shifts;

        //shift employee can have
        private readonly IList<Shift> _allShift;
        public UsrShift(IList<Shift> shifts, IList<Shift> allShift)
        {
            InitializeComponent();

            _shifts = shifts;

            _allShift = allShift;
        }

        private void UsrShift_Load(object sender, System.EventArgs e)
        {
            foreach (var shift in _allShift)
            {
                bool isSelected = false;
                foreach(var item in _shifts)
                {
                    if(item.Id == shift.Id)
                    {
                        isSelected = true;
                        break;
                    }
                }
                var usrShiftInfo = new UsrShiftInfo(shift, isSelected);
                flowPanelShifts.Controls.Add(usrShiftInfo);
            }
        }
    }
}
