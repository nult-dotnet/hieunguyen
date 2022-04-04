using System;
using System.ComponentModel.DataAnnotations;
using Backend.Data.Enums;

namespace Backend.Application.Users.Models
{
    public class UpdateUserResource
    {
        public string FirstMiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }
        public UserStatus Status { get; set; }
    }
}
