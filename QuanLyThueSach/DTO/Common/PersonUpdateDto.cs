﻿using System;
using QuanLyThueSach.Model;

namespace QuanLyThueSach.DTO.Common
{
    public class PersonUpdateDto
    { 
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Birthday { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }
        public PersonUpdateDto(int id, string username, DateTime birthday, int gender, string address, string phone, string avatar)
        {
            Id = id;
            Username = username;
            Birthday = birthday;
            Gender = gender;
            Address = address;
            Phone = phone;
            Avatar = avatar;
        }
    }
}
