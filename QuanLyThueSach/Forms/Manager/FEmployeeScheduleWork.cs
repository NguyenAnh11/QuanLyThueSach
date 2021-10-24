using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using QuanLyThueSach.Forms.Controls;
using QuanLyThueSach.Model;
using QuanLyThueSach.DAO;

namespace QuanLyThueSach.Forms.Manager
{
    public partial class FEmployeeScheduleWork : Form
    {
        private Employee _employee { get; set; }
        private IList<Shift> _allShiftInDay { get; set; }
        public FEmployeeScheduleWork(Employee employee)
        {
            InitializeComponent();

            _employee = employee;

            _allShiftInDay = new List<Shift>();
        }

        private void FEmployeeScheduleWork_Load(object sender, EventArgs e)
        {
            var date = DateTime.Now;

            IList<ShiftInDay> shiftInDays = EmployeeDAO.Instance().GetDayHaveShiftInMonthAndInYear(date.Month, date.Year, _employee.Id);

            _allShiftInDay = EmployeeDAO.Instance().GetAllShift();

            var usrCalendar = new UsrCalendar(shiftInDays)
            {
                SelectedDate = date.ToString("yyyy-MM-dd")
            };

            usrCalendar.DateSelected += HandleSelectedDate;

            usrCalendar.BringToFront();

            panelCalendar.Controls.Add(usrCalendar);
        }

        private void HandleSelectedDate(object sender, EventArgs e)
        {
            var usrCalendar = (UsrCalendar)this.Controls[1].Controls[0];

            var date = DateTime.Parse(usrCalendar.SelectedDate);

            //get all shift have in day
            var shifts = EmployeeDAO.Instance().GetAllShiftHaveInDay(_employee.Id, date);

            //remove all control in calendar info
            panelCalendarInfo.Controls.Clear();

            if (shifts.Count == 0)
            {
                var usrNoData = new UsrNoData();

                //usrNoData.BringToFront();

                panelCalendarInfo.Controls.Add(usrNoData);
                
            } else
            {

                var usrShift = new UsrShift(shifts, _allShiftInDay);

                panelCalendarInfo.Controls.Add(usrShift);
            }
        }
    }
}
