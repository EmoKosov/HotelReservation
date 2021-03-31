using System.ComponentModel.DataAnnotations;
using Data.Enumeration;

namespace Web.Models.Users
{
    public class UsersCreateViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EGN { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
