using Data.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    public class User
    {

        public User()
        {
            this.IsActive = true;
            this.DateOfBeingFired = null;
            this.Reservations = new List<Reservation>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EGN { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBeingHired { get; set; } = DateTime.UtcNow;
        public DateTime? DateOfBeingFired { get; set; }


        public bool IsActive { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }


    }
}