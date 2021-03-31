using System;
using System.ComponentModel.DataAnnotations;
using Data.Enumeration;
using Microsoft.AspNetCore.Mvc;

namespace Web.Models.Users
{
    public class UsersEditViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EGN { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime? FiredOn { get; set; }
        public string Message { get; set; }

    }
}
