using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using QuanLyThueSach.Forms.Controls;
using QuanLyThueSach.Model;
using QuanLyThueSach.DAO;
using QuanLyThueSach.DTO;

namespace QuanLyThueSach.Forms.Manager
{
    public partial class FCalendarWork : Form
    {
        private Employee _employee;

        //calendar
        private UsrCalendar _usrCalendar;

        //get all day have shift in month by current date in calendar
        private IList<ShiftInDay> _shiftInDays;

        //get all shift in day and mark checkbox of shift selected if is choose
        private IList<ShiftDto> _shiftDtos;

        public FCalendarWork(Employee employee)
        {
            InitializeComponent();

            _employee = employee;
        }

        private void FEmployeeScheduleWork_Load(object sender, EventArgs e)
        {
            //set selected date to now and assign current date to selected date
            var date = DateTime.Now;

            _shiftInDays = new List<ShiftInDay>();

            _shiftInDays = EmployeeDAO.Instance().GetDayHaveShiftInMonthAndInYear(date.Month, date.Year, _employee.Id);

            _usrCalendar = new UsrCalendar(_shiftInDays)
            {
                SelectedDate = date.ToString("yyyy-MM-dd")
            };

            _usrCalendar.DateSelected += HandleSelectedDate;

            _usrCalendar.CancelDateSelected += HandleCancelSelectedDate;

            _usrCalendar.LoadData += LoadDataWhenMonthOrYearChange;

            _usrCalendar.BringToFront();

            panelCalendar.Controls.Add(_usrCalendar);
        }

        private void HandleSelectedDate(object sender, EventArgs e)
        {

            var date = DateTime.Parse(_usrCalendar.SelectedDate);

            _shiftDtos = new List<ShiftDto>();

            _shiftDtos = EmployeeDAO.Instance().GetShiftInDay(_employee.Id, date);

            panelCalendarInfo.Controls.Clear();

            var usrShiftList = new UsrShiftList(_shiftDtos);

            usrShiftList.UpdateSelectShiftInDay += HandleUpdateShiftSelectInDay;

            panelCalendarInfo.Controls.Add(usrShiftList);
        }

        private void HandleCancelSelectedDate(object sender, EventArgs e)
        {
            panelCalendarInfo.Controls.Clear();
        }

        private void LoadDataWhenMonthOrYearChange(object sender, EventArgs e)
        {
            var currentDate = DateTime.Parse(_usrCalendar.CurrentDate);

            _shiftInDays = EmployeeDAO.Instance().GetDayHaveShiftInMonthAndInYear(currentDate.Month, currentDate.Year, _employee.Id);

            _usrCalendar.SetShiftInDayInCalendar(_shiftInDays);
        }

        private void HandleUpdateShiftSelectInDay(object sender, IList<ShiftSelectUpdateDto> eventArgs)
        {
            var date = DateTime.Parse(_usrCalendar.SelectedDate);

            try
            {
                int numberShiftSelectedInDay = _shiftDtos.Where(s => s.IsSelected).Count();

                for (int index = 0; index < _shiftDtos.Count; index++)
                {
                    if (_shiftDtos[index].IsSelected != eventArgs[index].Selected)
                    {

                        if (!eventArgs[index].Selected)
                        {
                            numberShiftSelectedInDay -= 1;
                        } else
                        {
                            numberShiftSelectedInDay += 1;
                        }

                        _shiftDtos[index].IsSelected = eventArgs[index].Selected;

                        EmployeeDAO.Instance().UpdateShiftSelectInDay(_employee.Id, _shiftDtos[index].Id, date);
                    }
                }

                var shiftInDay = new ShiftInDay(date, numberShiftSelectedInDay);

                _usrCalendar.UpdateShiftInDayInCalendar(shiftInDay);

                MessageBox.Show("Cập nhật thành công");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
