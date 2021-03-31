using System.ComponentModel.DataAnnotations;
using Data.Enumeration;

namespace Web.Models.Clients
{
    public class ClientsCreateViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsAdult { get; set; }
    }
}
