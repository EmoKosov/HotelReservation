using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entity;
using Web.Models.Reservations;
using Web.Models.Shared;
using Web.Models.Users;
using Web.Models.Rooms;
using Web.Models.Clients;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Enumeration;
using System.Diagnostics;
using Web.Models.Validation;

namespace Web.Controllers
{
    public class ReservationsController : Controller
    {

        public const int ReservationHourStart = 12;
        private readonly HotelReservationDb context;

        public ReservationsController()
        {
            context = new HotelReservationDb();
        }
    }
}