using Data.Enumeration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class Room
    {

        public Room()
        {
            IsFree = true;
            this.Reservations = new List<Reservation>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public decimal PriceAdult { get; set; }
        public decimal PriceChild { get; set; }
        public int Type { get; set; }
        public bool IsFree { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

    }
}
