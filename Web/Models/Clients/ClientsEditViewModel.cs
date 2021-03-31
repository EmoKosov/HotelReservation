using System.ComponentModel.DataAnnotations;
using Data.Enumeration;
using Microsoft.AspNetCore.Mvc;

namespace Web.Models.Clients
{
    public class ClientsEditViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsAdult { get; set; }

    }
}
