using Data.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    public class ClientReservation
    {

        public ClientReservation() {}

        public int ClientId { get; set; }
        public int ReservationId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Reservation Reservation { get; set; }

    }
}
