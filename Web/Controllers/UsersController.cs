using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entity;
using Web.Models.Users;
using Web.Models.Shared;
using Web.Models;
using Web.Models.Reservations;
using Web.Models.Validation;

namespace Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly HotelReservationDb context;
        public UsersController()
        {
            context = new HotelReservationDb();
        }

    }
}
