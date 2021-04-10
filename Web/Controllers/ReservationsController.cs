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
    /// <summary>
    /// The main reservations class
    /// CRUD operations with reservations
    /// </summary> 
    public class ReservationsController : Controller
    {

        private readonly int PageSize = GlobalVar.AmountOfElementsDisplayedPerPage;
        /// <summary>
        /// Default value
        /// </summary>
        public const int ReservationHourStart = 12;
        private readonly HotelReservationDb context;
        /// <summary>
        /// The main constuctor 
        /// opens database
        /// </summary>
        public ReservationsController()
        {
            context = new HotelReservationDb();
        }
        /// <summary>
        /// Default method by the template
        /// </summary>
        public IActionResult ChangePageSize(int id)
        {
            if (id > 0)
            {
                GlobalVar.AmountOfElementsDisplayedPerPage = id;
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// The main method
        /// Show reservations
        /// </summary>
        public IActionResult Index(ReservationsIndexViewModel model)
        {

            if (GlobalVar.LoggedOnUserId == -1)
            {
                return RedirectToAction("LogInRequired", "Users");
            }

            model.Pager ??= new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            List<Reservation> reservations = context.Reservations.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).ToList();

            List<ReservationsViewModel> list = new List<ReservationsViewModel>();

            foreach (var reservation in reservations)
            {
                int userId = reservation.UserId;
                int roomId = reservation.RoomId;

                UsersViewModel userVM = new UsersViewModel()
                {
                    Id = reservation.User.Id,
                    FirstName = reservation.User.FirstName,
                    LastName = reservation.User.LastName,
                };

                RoomsViewModel roomVM = new RoomsViewModel()
                {
                    Id = reservation.Room.Id,
                    Capacity = reservation.Room.Capacity,
                    PriceAdult = reservation.Room.PriceAdult,
                    PriceChild = reservation.Room.PriceChild,
                    Number = reservation.Room.Number,
                    Type = (RoomTypeEnum)reservation.Room.Type
                };

                int clientsCount = context.ClientReservation.Where(x => x.ReservationId == reservation.Id).Count();

                list.Add(new ReservationsViewModel()
                {
                    Id = reservation.Id,
                    User = userVM,
                    Room = roomVM,
                    CurrentReservationClientCount = clientsCount,
                    DateOfAccommodation = reservation.DateOfAccommodation,
                    DateOfExemption = reservation.DateOfExemption,
                    IsAllInclusive = reservation.IsAllInclusive,
                    IsBreakfastIncluded = reservation.IsBreakfastIncluded,
                    OverallBill = reservation.OverallBill,
                });

            }

            model.Items = list;
            model.Pager.PagesCount = Math.Max(1, (int)Math.Ceiling(context.Reservations.Count() / (double)PageSize));

            return View(model);
        }

        /// <summary>
        /// The create post method
        /// Creates reservation and add to database
        /// </summary> 
        public IActionResult Create()
        {

            if (GlobalVar.LoggedOnUserId == -1)
            {
                return RedirectToAction("LogInRequired", "Users");
            }

            ReservationsCreateViewModel model = new ReservationsCreateViewModel();

            model = CreateReservationVMWithDropdown(model, null);

            return View(model);
        }

        /// <summary>
        /// The create post method
        /// Creates reservation and add to database
        /// </summary>    
        [HttpPost]
        [ValidateAntiForgeryToken]   
        public IActionResult Create(ReservationsCreateViewModel createModel)
        {
            if (GlobalVar.LoggedOnUserId == -1)
            {
                return RedirectToAction("LogInRequired", "Users");
            }

            if (ModelState.IsValid)
            {

                try
                {
                    Validate(new Validation_Reservation()
                    {
                        DateOfAccommodation = createModel.DateOfAccommodation,
                        DateOfExemption = createModel.DateOfExemption,
                        RoomId = createModel.RoomId,
                        ReservationId = -1
                    });
                }
                catch (InvalidOperationException e)
                {
                    createModel = CreateReservationVMWithDropdown(createModel, e.Message);
                    return View(createModel);
                }

                Reservation reservation = new Reservation
                {
                    UserId = createModel.UserId,
                    RoomId = createModel.RoomId,
                    DateOfAccommodation = createModel.DateOfAccommodation,
                    DateOfExemption = createModel.DateOfExemption,
                    IsAllInclusive = createModel.IsAllInclusive,
                    IsBreakfastIncluded = createModel.IsBreakfastIncluded,
                    OverallBill = 0
                };

                context.Reservations.Add(reservation);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            createModel = CreateReservationVMWithDropdown(createModel, null);
            return View(createModel);
        }
        /// <summary>
        /// The edit method
        /// Edits reservation
        /// </summary>
        public IActionResult Edit(int? id)
        {

            if (GlobalVar.LoggedOnUserId == -1)
            {
                return RedirectToAction("LogInRequired", "Users");
            }

            if (id == null || !ReservationExists((int)id))
            {
                return NotFound();
            }

            Reservation reservation = context.Reservations.Find(id);

            ReservationsEditViewModel model = new ReservationsEditViewModel()
            {
                Id = reservation.Id,
                DateOfAccommodation = reservation.DateOfAccommodation,
                DateOfExemption = reservation.DateOfExemption,
                IsAllInclusive = reservation.IsAllInclusive,
                IsBreakfastIncluded = reservation.IsBreakfastIncluded,
                OverallBill = reservation.OverallBill
            };

            return View(model);
        }

        /// <summary>
        /// The edit method
        /// Edits reservation
        /// </summary>     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ReservationsEditViewModel editModel)
        {

            if (GlobalVar.LoggedOnUserId == -1)
            {
                return RedirectToAction("LogInRequired", "Users");
            }

            if (!ReservationExists(editModel.Id))
            {
                return NotFound();
            }



            if (ModelState.IsValid)
            {

                try
                {
                    Validate(new Validation_Reservation()
                    {
                        DateOfAccommodation = editModel.DateOfAccommodation,
                        DateOfExemption = editModel.DateOfExemption,
                        RoomId = context.Reservations.Find(editModel.Id).RoomId,
                        ReservationId = editModel.Id
                    });
                }
                catch (InvalidOperationException e)
                {
                    editModel.Message = e.Message;
                    return View(editModel);
                }


                Reservation reservation = context.Reservations.Find(editModel.Id);

                reservation.DateOfAccommodation = editModel.DateOfAccommodation;
                reservation.DateOfExemption = editModel.DateOfExemption;
                reservation.IsAllInclusive = editModel.IsAllInclusive;
                reservation.IsBreakfastIncluded = editModel.IsBreakfastIncluded;

                context.Reservations.Update(reservation);
                context.SaveChanges();


                reservation.OverallBill = CalculateOverAllPrice(reservation.Id);
                context.Reservations.Update(reservation);
                context.SaveChanges();


                return RedirectToAction(nameof(Index));
            }

            return View(editModel);
        }

        /// <summary>
        /// The delete method
        /// Deletes reservation
        /// </summary>
        public IActionResult Delete(int? id)
        {

            if (GlobalVar.LoggedOnUserRights != GlobalVar.UserRights.Admininstrator)
            {
                return RedirectToAction("LogInPermissionDenied", "Users");
            }

            if (id == null || !ReservationExists((int)id))
            {
                return NotFound();
            }

            Reservation reservation = context.Reservations.Find(id);
            context.Reservations.Remove(reservation);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        /// <summary>
        /// The details method
        /// Gets information about reservation
        /// </summary>
        public IActionResult Detail(int? id)
        {
            if (GlobalVar.LoggedOnUserId == -1)
            {
                return RedirectToAction("LogInRequired", "Users");
            }

            if (id == null || !ReservationExists((int)id))
            {
                return NotFound();
            }

            Reservation reservation = context.Reservations.Find(id);

            UsersViewModel userVM = new UsersViewModel()
            {
                Id = reservation.User.Id,
                FirstName = reservation.User.FirstName,
                MiddleName = reservation.User.MiddleName,
                LastName = reservation.User.LastName,
                Username = reservation.User.Username
            };

            RoomsViewModel roomVM = new RoomsViewModel()
            {
                Id = reservation.Room.Id,
                Capacity = reservation.Room.Capacity,
                PriceAdult = reservation.Room.PriceAdult,
                PriceChild = reservation.Room.PriceChild,
                Number = reservation.Room.Number,
                Type = (RoomTypeEnum)reservation.Room.Type
            };

            var allClients = context.Clients.ToList();

            var allClientReservations = context.ClientReservation.Where(x => x.ReservationId == id).ToList();

            var reservedClients = new List<Client>();

            var availableClients = allClients;

            foreach (var clientReservation in allClientReservations)
            {
                availableClients.RemoveAll(x => x.Id == clientReservation.ClientId);
                var client = (context.Clients.Find(clientReservation.ClientId));
                reservedClients.Add(client);
            }

            var availableClientsVM = availableClients.Select(x => new SelectListItem()
            {
                Text = x.FirstName + " " + x.LastName + " (" + x.Email + ")",
                Value = x.Id.ToString()
            }).ToList();

            var reservedClientsVM = reservedClients.Select(x => new ClientsViewModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email

            }).ToList();

            var model = new ReservationsViewModel()
            {
                User = userVM,
                Room = roomVM,
                CurrentReservationClientCount = reservedClients.Count(),
                DateOfAccommodation = reservation.DateOfAccommodation,
                DateOfExemption = reservation.DateOfExemption,
                IsAllInclusive = reservation.IsAllInclusive,
                IsBreakfastIncluded = reservation.IsBreakfastIncluded,
                OverallBill = reservation.OverallBill,
                AvailableClients = availableClientsVM,
                SignedInClients = reservedClientsVM
            };

            return View(model);
        }

        /// <summary>
        /// The connecting method
        /// Connects user to reservation
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LinkClientReservation(ReservationsViewModel linkModel)
        {
            if (GlobalVar.LoggedOnUserId == -1)
            {
                return RedirectToAction("LogInRequired", "Users");
            }

            var clientId = linkModel.ClientId;
            var reservationId = linkModel.Id;

            if (reservationId <= 0)
            {
                return RedirectToAction("Index");
            }

            if (clientId <= 0)
            {
                return RedirectToAction("Detail", new { id = reservationId });
            }
            var clientReservation = new ClientReservation()
            {
                ClientId = clientId,
                ReservationId = reservationId
            };
            var currentRoomOccupyCount = (context.ClientReservation.Where(x => x.ReservationId == reservationId).ToList()).Count;
            Room room = context.Rooms.Find(context.Reservations.Find(reservationId).RoomId);
            if (currentRoomOccupyCount >= room.Capacity)
            {
                return RedirectToAction("Detail", new { id = reservationId });
            }
            var elem = context.ClientReservation.Find(clientId, reservationId);
            if (elem != null)
            {
                throw new InvalidOperationException($"Клиентът {clientId} вече е добавен към резервацията {reservationId}");
            }
            else
            {
                context.ClientReservation.Add(clientReservation);
                context.SaveChanges();

                bool isClientAdult = (context.Clients.Find(clientId)).IsAdult;
                decimal pricePerDay = 0;
                if (isClientAdult)
                {
                    pricePerDay += (context.Rooms.Find(room.Id)).PriceAdult;
                }
                else
                {
                    pricePerDay += (context.Rooms.Find(room.Id)).PriceChild;
                }
                Reservation reservation = context.Reservations.Find(reservationId);
                decimal clientOverall = pricePerDay * CalculateDaysPassed(reservation.DateOfAccommodation, reservation.DateOfExemption);
                clientOverall = AddExtras(clientOverall, reservation.IsAllInclusive, reservation.IsBreakfastIncluded);
                reservation.OverallBill += clientOverall;
                context.Reservations.Update(reservation);
                context.SaveChanges();
            }
            return RedirectToAction("Detail", new { id = reservationId });
        }
        private bool ReservationExists(int id)
        {
            return context.Reservations.Any(e => e.Id == id);
        }
        private void Validate(Validation_Reservation model)
        {
            if (CalculateDaysPassed(model.DateOfAccommodation, model.DateOfExemption) <= 0)
            {
                throw new InvalidOperationException("Датата на назначаване трябва да бъде преди датата на освобождаване");
            }
            if (model.DateOfAccommodation.AddHours(ReservationHourStart) <= DateTime.UtcNow)
            {
                throw new InvalidOperationException("Датата на назначаване трябва да бъде след моментната дата");
            }
            foreach (var item in context.Reservations.Where(x => x.RoomId == model.RoomId && x.Id!=model.ReservationId))
            {
                if ((item.DateOfAccommodation >= model.DateOfAccommodation && item.DateOfAccommodation < model.DateOfExemption)
                    ||
                    (item.DateOfExemption > model.DateOfAccommodation && item.DateOfExemption <= model.DateOfExemption))
                {
                    throw new InvalidOperationException($"Стаята вече е резервирана за този период. Изберете дата преди {item.DateOfAccommodation}, или след {item.DateOfExemption}");
                }
            }
        }
        private int CalculateDaysPassed(DateTime startDate, DateTime endDate)
        {
            double daysDiffDouble = (endDate - startDate).TotalDays;

            int daysDiff = (int)daysDiffDouble;
            if (daysDiffDouble > daysDiff)
            {
                daysDiff++;
            }
            return daysDiff;
        }
        private decimal CalculateOneDayPriceWithoutExtrasForRoom(int reservationId)
        {
            Reservation reservation = context.Reservations.Find(reservationId);
            decimal underagePrice = context.Rooms.Find(reservation.RoomId).PriceChild;
            decimal adultPrice = context.Rooms.Find(reservation.RoomId).PriceAdult;
            var clientList = context.ClientReservation.Where(x => x.ReservationId == reservationId).ToList();
            decimal pricePerDay = 0;
            foreach (var id in clientList)
            {
                bool isClientAdult = context.Clients.Find(id.ClientId).IsAdult;
                if (isClientAdult)
                {
                    pricePerDay += adultPrice;
                }
                else
                {
                    pricePerDay += underagePrice;
                }
            }
            return pricePerDay;
        }
        private decimal CalculateOverallBillWithoutExtrasForRoom(int reservationId, int days)
        {
            return CalculateOneDayPriceWithoutExtrasForRoom(reservationId) * days;
        }
        private decimal AddExtras(decimal money, bool isAllInclusive, bool isBreakfastIncluded)
        {
            decimal bonusPercentage = 0;
            if (isAllInclusive)
            {
                bonusPercentage += 12;
            }
            if (isBreakfastIncluded)
            {
                bonusPercentage += 5;
            }
            return money * (1 + bonusPercentage / 100);
        }
        private decimal CalculateOverAllPrice(int reservationId)
        {
            Reservation reservation = context.Reservations.Find(reservationId);
            int days = CalculateDaysPassed(reservation.DateOfAccommodation, reservation.DateOfExemption);
            var overallBillWithoutextras = CalculateOverallBillWithoutExtrasForRoom(reservationId, days);
            return AddExtras(overallBillWithoutextras, reservation.IsAllInclusive, reservation.IsBreakfastIncluded);
        }
        private ReservationsCreateViewModel CreateReservationVMWithDropdown(ReservationsCreateViewModel model, string message)
        {
            model.Message = message;
            model.Rooms = context.Rooms.Select(x => new SelectListItem()
            {
                Text = $"{x.Number.ToString()} [0/{x.Capacity}] (type: {((RoomTypeEnum)x.Type).ToString()})",
                Value = x.Id.ToString()
            }).ToList();
            model.Users = context.Users.Where(x => x.IsActive).Select(x => new SelectListItem()
            {
                Text = x.FirstName + " " + x.LastName + " (" + x.Email + ")",
                Value = x.Id.ToString()
            }).ToList();
            return model;
        }
    }
}