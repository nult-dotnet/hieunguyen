using System;
using System.Collections.Generic;
using Backend.Data.Enums;

namespace Backend.Application.Users.Models
{
    public class UserVm
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string FirstMiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public UserStatus Status { get; set; }
        public List<string> UserInRole { get; set; }
    }
}
