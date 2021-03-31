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
    public class ReservationsCreateViewModel
    {
        public DateTime DateOfAccommodation { get; set; } = DateTime.UtcNow;
        public DateTime DateOfExemption { get; set; } = DateTime.UtcNow;
        public bool IsBreakfastIncluded { get; set; }
        public bool IsAllInclusive { get; set; }
        public decimal OverallBill { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public IEnumerable<SelectListItem> Rooms { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
        public string Message { get; set; }

    }
}
