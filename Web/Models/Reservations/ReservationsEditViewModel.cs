using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data.Enumeration;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Clients;
using Web.Models.Rooms;
using Web.Models.Users;

namespace Web.Models.Reservations
{
    public class ReservationsEditViewModel
    {
        public int Id { get; set; }
        public DateTime DateOfAccommodation { get; set; }
        public DateTime DateOfExemption { get; set; }
        public bool IsBreakfastIncluded { get; set; }
        public bool IsAllInclusive { get; set; }
        public decimal OverallBill { get; set; }
        public string Message { get; set; }

    }
}
