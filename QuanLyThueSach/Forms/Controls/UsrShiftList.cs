using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyThueSach.DTO;
using QuanLyThueSach.Event;

namespace QuanLyThueSach.Forms.Controls
{
    public partial class UsrShiftList : UserControl
    {
        private IList<ShiftDto> _shiftDtos;

        public event EventHandler<IList<UpdateSelectedShiftEventArgs>> UpdateSelectShiftInDay;

        public UsrShiftList(IList<ShiftDto> shiftDtos)
        {
            InitializeComponent();

            _shiftDtos = shiftDtos;
        }

        private void UsrShift_Load(object sender, EventArgs e)
        {
            foreach(var shiftDto in _shiftDtos)
            {
                var usrShiftItem = new UsrShiftItem(shiftDto);

                flowPanelShifts.Controls.Add(usrShiftItem);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var controls = flowPanelShifts.Controls;

            Dictionary<int, bool> checkboxs = new Dictionary<int, bool>();

            LoopControls(checkboxs, controls);

            IList<UpdateSelectedShiftEventArgs> updateSelectedShiftEventArgs = new List<UpdateSelectedShiftEventArgs>();

            foreach(var checkbox in checkboxs)
            {
                var updateSelectedShiftEventArg = new UpdateSelectedShiftEventArgs(checkbox.Key, checkbox.Value);

                updateSelectedShiftEventArgs.Add(updateSelectedShiftEventArg);
            }

            if (UpdateSelectShiftInDay != null)
            {
                UpdateSelectShiftInDay(sender, updateSelectedShiftEventArgs);
            }

        }

        private void LoopControls(Dictionary<int, bool> checkboxs, ControlCollection controls)
        {
            foreach(Control control in controls)
            {
                if(control is CheckBox)
                {
                    var checkbox = (CheckBox)control;
                    checkboxs.Add((int)checkbox.Tag, checkbox.Checked);
                } else if(control.Controls.Count > 0)
                {
                    LoopControls(checkboxs, control.Controls);
                }
            }
        }
    }
}
