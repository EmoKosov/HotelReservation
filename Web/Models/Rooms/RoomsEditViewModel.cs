using System.ComponentModel.DataAnnotations;
using Data.Enumeration;
using Microsoft.AspNetCore.Mvc;

namespace Web.Models.Rooms
{
    public class RoomsEditViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public bool IsFree { get; set; }
        public decimal PriceAdult { get; set; }
        public decimal PriceChild { get; set; }
        public RoomTypeEnum RoomType { get; set; }
        public string Message { get; set; }

    }
}
