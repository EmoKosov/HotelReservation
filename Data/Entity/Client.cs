using Data.Enumeration;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    public class Client
    {

        public Client()
        {
            this.Reservations = new List<ClientReservation>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TelephoneNumber { get; set; }

        public string Email { get; set; }

        public bool IsAdult { get; set; }

        public virtual ICollection<ClientReservation> Reservations { get; set; }

    }
}