using System;
using System.Windows.Forms;
using QuanLyThueSach.Model;

namespace QuanLyThueSach.Forms.Account
{
    public partial class FAccountEmployeeInfo : Form
    {
        private Person Person { get; set; }
        public FAccountEmployeeInfo(Person person)
        {
            InitializeComponent();
            Person = person;
        }

    }
}
