using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entity;
using Web.Models.Rooms;
using Web.Models.Shared;
using Web.Models.Users;
using Web.Models.Reservations;
using Data.Enumeration;
using Web.Models.Validation;

namespace Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly HotelReservationDb context;
        public const int ReservationHourStart = 12;

        public RoomsController()
        {
            context = new HotelReservationDb();
        }
    }
}