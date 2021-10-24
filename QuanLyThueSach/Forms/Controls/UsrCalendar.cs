using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Globalization;
using QuanLyThueSach.Model;

namespace QuanLyThueSach.Forms.Controls
{
    public partial class UsrCalendar : UserControl
    {
        private const int DEF_LOW_YEAR = -3;

        private const int DEF_HIGH_YEAR = 3;

        private readonly Color DEF_OTHERMONTH_BACK = Color.LightGray;

        private readonly Color DEF_OTHERMONTH_FORE = Color.SteelBlue;

        //day have one shift
        private readonly Color DEF_DAY_COLOR_1 = Color.LimeGreen;

        //day have two shift
        private readonly Color DEF_DAY_COLOR_2 = Color.Orange;

        //day have three shift
        private readonly Color DEF_DAY_COLOR_3 = Color.IndianRed;

        //day have four shift
        private readonly Color DEF_DAY_COLOR_4 = Color.Red;

        // list color represent shift in day
        private IList<Color> _colorRepresentNumberShiftInDay;

        // list button expand what color cell represent  in calendar

        private IList<Button> _buttons;

        private readonly int DEF_BUTTON_WIDTH = 75;

        private readonly int DEF_BUTTON_HEIGHT = 23;

        private CultureInfo _culture;

        private string _currentDate { get; set; }

        private string _selectedDate { get; set; }

        private bool _firstLoad = true;

        private IList<ShiftInDay> _shiftInDays { get; set; }

        public event EventHandler DateSelected;

        public UsrCalendar(IList<ShiftInDay> shiftInDays)
        {
            InitializeComponent();

            _culture = new CultureInfo("vi-VI");

            _selectedDate = DateTime.Now.ToString("yyyy-MM-dd");

            _shiftInDays = new List<ShiftInDay>();

            if (shiftInDays.Count > 0)
            {
                foreach(var shiftInDay in shiftInDays)
                {
                    _shiftInDays.Add(shiftInDay);
                }
            }

            _colorRepresentNumberShiftInDay = new List<Color>();

            _colorRepresentNumberShiftInDay.Add(DEF_DAY_COLOR_1);
            _colorRepresentNumberShiftInDay.Add(DEF_DAY_COLOR_2);
            _colorRepresentNumberShiftInDay.Add(DEF_DAY_COLOR_3);
            _colorRepresentNumberShiftInDay.Add(DEF_DAY_COLOR_4);

            _buttons = new List<Button>();

            for(int index = 0; index < _colorRepresentNumberShiftInDay.Count; index++)
            {
                Button button = new Button();
                button.Width = DEF_BUTTON_WIDTH;
                button.Height = DEF_BUTTON_HEIGHT;
                button.Text = $"{index + 1} Ca";
               
                button.Enabled = false;
                button.Font = new Font("Microsoft Sans Serif", 10);
                button.BackColor = _colorRepresentNumberShiftInDay[index];

                _buttons.Add(button);
            }
        }

        public string SelectedDate
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                _selectedDate = value;
                _currentDate = _selectedDate;
            }
        }

        //set number shift in a day in calendar use to make color for day have shift

        public void SetShiftInDayInCalendar(IList<ShiftInDay> shiftInDays)
        {
            _shiftInDays.Clear();

            foreach(var shiftInDay in shiftInDays)
            {
                _shiftInDays.Add(shiftInDay);
            }

            gridCalendar.Update();
        }

        private void ComboboxSetValue(ComboBox comboBox, string value)
        {
            for(int i = 0; i < comboBox.Items.Count; i++)
            {
                var item = (Item)comboBox.Items[i];
                if(item.Id == value)
                {
                    comboBox.SelectedIndex = i;
                    break;
                }
            }
        }

        private string ComboboxGetValue(ComboBox comboBox)
        {
            string value = String.Empty;
            if(comboBox.SelectedIndex > 0)
            {
                var item = (Item)comboBox.SelectedItem;
                value = item.Id;
            }
            return value;
        }

        private void UsrCalendar_Load(object sender, EventArgs e)
        {
            _currentDate = _selectedDate;

            cbMonth.Items.Clear();

            for(int month = 1; month < 13; month++)
            {
                string text = _culture.DateTimeFormat.GetMonthName(month);
                cbMonth.Items.Add(new Item(month.ToString(), text));
            }

            cbYear.Items.Clear();

            for(int year = DateTime.Now.Year + DEF_LOW_YEAR; year <= DateTime.Now.Year + DEF_HIGH_YEAR; year++)
            {
                cbYear.Items.Add(new Item(year.ToString(), year.ToString()));
            }

            ComboboxSetValue(cbMonth, DateTime.Parse(_currentDate).Month.ToString());

            ComboboxSetValue(cbYear, DateTime.Parse(_currentDate).Year.ToString());

            gridCalendar.Columns.Add("Mon", _culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Monday));
            gridCalendar.Columns.Add("Tue", _culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Tuesday));
            gridCalendar.Columns.Add("Wed", _culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Wednesday));
            gridCalendar.Columns.Add("Thu", _culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Thursday));
            gridCalendar.Columns.Add("Fri", _culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Friday));
            gridCalendar.Columns.Add("Sat", _culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Saturday));
            gridCalendar.Columns.Add("Sun", _culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Sunday));

            for(int col = 0; col < 7; col++)
            {
                gridCalendar.Columns[col].SortMode = DataGridViewColumnSortMode.NotSortable;
                gridCalendar.Columns[col].Width = gridCalendar.Width / 8;
                gridCalendar.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            gridCalendar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            ShowMonth();

            foreach(var button in _buttons)
            {
                colorCalendarInfo.Controls.Add(button);
            }

            _firstLoad = false;
        }

        private void ShowMonth()
        {
            var now = DateTime.Parse(_currentDate);

            int year = now.Year;

            int month = now.Month;

            var date = new DateTime(year, month, 1);

            int col = (int)date.DayOfWeek - 1, row = 0;

            gridCalendar.Rows.Clear();

            gridCalendar.Rows.Add();

            if (col < 0) col = 6;
            
            for(int day=1; day<=DateTime.DaysInMonth(year, month); day++)
            {
                row = gridCalendar.Rows.Count - 1;
                gridCalendar.Rows[row].Cells[col].Value = day;
                gridCalendar.Rows[row].Cells[col].Tag = date.ToString("yyyy-MM-dd");
                date = date.AddDays(1);
                col += 1;
                if(col> 6 && day < DateTime.DaysInMonth(year, month))
                {
                    col = 0;
                    gridCalendar.Rows.Add();
                }
            }

            col = 0;
            while (gridCalendar.Rows[0].Cells[col].Value == null) col += 1;
            date = new DateTime(year, month, 1);
            while (col > 0)
            {
                col -= 1;
                date = date.AddDays(-1);
                gridCalendar.Rows[0].Cells[col].Value = date.Day;
                gridCalendar.Rows[0].Cells[col].Tag = date.ToString("yyyy-MM-dd");
                gridCalendar.Rows[0].Cells[col].Style.BackColor = DEF_OTHERMONTH_BACK;
                gridCalendar.Rows[0].Cells[col].Style.ForeColor = DEF_OTHERMONTH_FORE;
            }

            col = 0;
            row = gridCalendar.Rows.Count - 1;
            while (gridCalendar.Rows[row].Cells[col].Value != null)
            {
                int day = (int)gridCalendar.Rows[row].Cells[col].Value;
                date = new DateTime(year, month, day);
                col += 1;
                if (col > 6) break;
            }
            while (col < 7)
            {
                date = date.AddDays(1);
                gridCalendar.Rows[row].Cells[col].Value = date.Day;
                gridCalendar.Rows[row].Cells[col].Tag = date.ToString("yyyy-MM-dd");
                gridCalendar.Rows[row].Cells[col].Style.BackColor = DEF_OTHERMONTH_BACK;
                gridCalendar.Rows[row].Cells[col].Style.ForeColor = DEF_OTHERMONTH_FORE;
                col += 1;
            }

            #region Color for day weekend
            //for (row = 0; row < gridCalendar.Rows.Count; row++)
            //{
            //    if(gridCalendar.Rows[row].Cells[5].Style.BackColor == Color.Empty)
            //    {
            //        gridCalendar.Rows[row].Cells[5].Style.BackColor = DEF_WEEKEND;
            //    } 
            //    if(gridCalendar.Rows[row].Cells[6].Style.BackColor == Color.Empty)
            //    {
            //        gridCalendar.Rows[row].Cells[6].Style.BackColor = DEF_WEEKEND;
            //    }
            //}
            #endregion

            for (row = 0; row < gridCalendar.Rows.Count; row++)
            {
                for (col = 0; col < gridCalendar.Columns.Count; col++)
                {
                    string value = gridCalendar.Rows[row].Cells[col].Tag.ToString();
                    foreach(var shiftInDay in _shiftInDays)
                    {
                        if(shiftInDay.Day.ToString("yyyy-MM-dd") == value)
                        {
                            int index = shiftInDay.Number - 1;

                            gridCalendar.Rows[row].Cells[col].Style.BackColor = _colorRepresentNumberShiftInDay[index];
                        }
                    }
                }
            }

            gridCalendar.ClearSelection();

            for (row = 0; row < gridCalendar.Rows.Count; row++)
            {
                for (col = 0; col < gridCalendar.Columns.Count; col++)
                {
                    string value = (string)gridCalendar.Rows[row].Cells[col].Tag;
                    if(value == _selectedDate)
                    {
                        gridCalendar.Rows[row].Cells[col].Selected = true;
                    }
                }
            }

           
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_firstLoad)
            {
                int month = int.Parse(ComboboxGetValue(cbMonth));
                var date = DateTime.Parse(_currentDate);

                _currentDate = new DateTime(date.Year, month, date.Day).ToString("yyyy-MM-dd");

                
                ShowMonth();
            }
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_firstLoad)
            {
                int year = int.Parse(ComboboxGetValue(cbYear));
                var date = DateTime.Parse(_currentDate);

                _currentDate = new DateTime(year, date.Month, date.Day).ToString("yyyy-MM-dd");

                ShowMonth();
            }
        }

        private void btnMonthPrev_Click(object sender, EventArgs e)
        {
            int index = cbMonth.SelectedIndex;
            if (index > 0) cbMonth.SelectedIndex -= 1;
            else
            {
                cbMonth.SelectedIndex = cbMonth.Items.Count - 1;
                btnYearPrev_Click(sender, e);
            }
        }

        private void btnMonthNext_Click(object sender, EventArgs e)
        {
            int index = cbMonth.SelectedIndex;
            if (index < cbMonth.Items.Count - 1)
            {
                cbMonth.SelectedIndex += 1;
            } else
            {
                cbMonth.SelectedIndex = 0;
                btnYearNext_Click(sender, e);
            }
        }

        private void btnYearPrev_Click(object sender, EventArgs e)
        {
            int index = cbYear.SelectedIndex;
            if (index > 0) cbYear.SelectedIndex -= 1; 
        }

        private void btnYearNext_Click(object sender, EventArgs e)
        {
            int index = cbYear.SelectedIndex;
            if(index < cbYear.Items.Count - 1)
            {
                cbYear.SelectedIndex += 1;
            }
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            _currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            _selectedDate = DateTime.Now.ToString("yyyy-MM-dd");
            var date = DateTime.Parse(_currentDate);
            ComboboxSetValue(cbMonth, date.Month.ToString());
            ComboboxSetValue(cbYear, date.Year.ToString());
            ShowMonth();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _selectedDate = string.Empty;
        }

        private void btnSelectDate_Click(object sender, EventArgs e)
        {
            if(DateSelected != null)
            {
                DateSelected(sender, e);
            }
        }

        private void gridCalendar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = gridCalendar.SelectedCells[0];
            _selectedDate = DateTime.Parse(cell.Tag.ToString()).ToString("yyyy-MM-dd");
            
        }

        private void gridCalendar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = gridCalendar.SelectedCells[0];
            _selectedDate = DateTime.Parse(cell.Tag.ToString()).ToString("yyyy-MM-dd");

            btnSelectDate_Click(sender, e);
        }

    }
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public Item(string id, string text)
        {
            Id = id;
            Text = text;
        }
        public override string ToString()
        {
            return Text;
        }
    }

}
