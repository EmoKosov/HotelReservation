using System.ComponentModel.DataAnnotations;
using Data.Enumeration;

namespace Web.Models.Rooms
{
    public class RoomsCreateViewModel
    {
        public int Number { get; set; }
        public int Capacity { get; set; }
        public decimal PriceAdult { get; set; }
        public decimal PriceChild { get; set; }
        public RoomTypeEnum RoomType { get; set; }
        public string Message { get; set; }
    }
}
