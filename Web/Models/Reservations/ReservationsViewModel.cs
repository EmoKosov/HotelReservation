using Data.Entity;
using Data.Enumeration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Web.Models.Clients;
using Web.Models.Rooms;
using Web.Models.Users;

namespace Web.Models.Reservations
{
    public class ReservationsViewModel
    {
        public int Id { get; set; }

        public virtual RoomsViewModel Room { get; set; }

        public virtual UsersViewModel User { get; set; }

        public int CurrentReservationClientCount { get; set; }

        public DateTime DateOfAccommodation { get; set; }
        public DateTime DateOfExemption { get; set; }

        public bool IsBreakfastIncluded { get; set; }
        public bool IsAllInclusive { get; set; }
        public decimal OverallBill { get; set; }
        public int ClientId { get; set; }
        public virtual IEnumerable<SelectListItem> AvailableClients { get; set; }
        public virtual ICollection<ClientsViewModel> SignedInClients { get; set; }

    }
}
