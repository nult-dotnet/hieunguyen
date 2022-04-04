using Backend.Application.Users.Models;
using Backend.Data.Entities;
using System;

namespace Backend.Application.Users.Extensions
{
    public static class UserExtensions
    {
        public static void Map(this User user, UpdateUserResource request)
        {
            user.FirstMiddleName = request.FirstMiddleName;

            user.LastName = request.LastName;

            user.PhoneNumber = request.PhoneNumber;

            user.Gender = request.Gender;

            if (request.Birthday != null)
            {
                user.Birthday = request.Birthday.GetValueOrDefault();
            }

            user.Address = request.Address;

            user.Status = request.Status;

            user.ModifiedDate = DateTime.Now;
        }
    }
}
