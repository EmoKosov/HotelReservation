using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data.Enumeration;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Models.Clients;
using Web.Models.Rooms;
using Web.Models.Users;

namespace Web.Models.Reservations
{
    public class ClientsFilterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
