using System.ComponentModel.DataAnnotations;
using Data.Enumeration;

namespace Web.Models.Users
{
    public class UsersLogInViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }

    }
}
