using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyThueSach.DTO;

namespace QuanLyThueSach.Forms.Controls
{
    public partial class UsrShiftList : UserControl
    {
        private IList<ShiftDto> _shiftDtos;

        public event EventHandler<IList<ShiftSelectUpdateDto>> UpdateSelectShiftInDay;

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

            IList<ShiftSelectUpdateDto> shiftSelectUpdateDtos = new List<ShiftSelectUpdateDto>();

            foreach(var checkbox in checkboxs)
            {
                var shiftSelectUpdateDto = new ShiftSelectUpdateDto(checkbox.Key, checkbox.Value);

                shiftSelectUpdateDtos.Add(shiftSelectUpdateDto);
            }

            if (UpdateSelectShiftInDay != null)
            {
                UpdateSelectShiftInDay(sender, shiftSelectUpdateDtos);
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
