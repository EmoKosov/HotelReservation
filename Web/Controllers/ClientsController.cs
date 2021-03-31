using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entity;
using Web.Models.Clients;
using Web.Models.Shared;
using Web.Models.Reservations;
using Web.Models.Rooms;
using Data.Enumeration;

namespace Web.Controllers
{
    public class ClientsController : Controller
    {
        public const int ReservationHourStart = 12;
        private readonly HotelReservationDb context;

        public ClientsController()
        {
            context = new HotelReservationDb();
        }
    }
}
