﻿using System;
using System.Windows.Forms;
using QuanLyThueSach.Model;
using QuanLyThueSach.Forms.Account;

namespace QuanLyThueSach.Forms.Manager
{
    public partial class FStaff : Form
    {
        private Employee _employee { get; set; }
        public FStaff(Employee employee)
        {
            InitializeComponent();

            _employee = employee;

            txtTitle.Text = $"Xin chào: {employee.Username}";
        }

        private void UserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FUserProfile fProfile = new FUserProfile(_employee);
            this.Hide();
            fProfile.ShowDialog();
            this.Show();
        }

        private void ScheduleWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FEmployeeScheduleWork fEmployeeScheduleWork = new FEmployeeScheduleWork(_employee);
            this.Hide();
            fEmployeeScheduleWork.ShowDialog();
            this.Show();
        }
    }
}
