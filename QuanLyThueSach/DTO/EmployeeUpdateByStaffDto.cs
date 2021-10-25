using System;

namespace QuanLyThueSach.DTO
{
    public class EmployeeUpdateByStaffDto:PersonUpdateDto
    {
        public EmployeeUpdateByStaffDto(int id, string username, DateTime birthday, int gender, string address, string phone, string avatar) : 
            base(id, username, birthday, gender, address, phone, avatar)
        {

        }   
    }
}
