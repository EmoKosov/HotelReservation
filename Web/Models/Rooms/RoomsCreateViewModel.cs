using System.ComponentModel.DataAnnotations;
using Data.Enumeration;

namespace Web.Models.Rooms
{
    public class RoomsCreateViewModel
    {
        [Required]
        public int Number { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        [Range(0.01,9999.99,ErrorMessage = "Цената трябва да бъде между 0.01 и 9999.99")]
        public decimal PriceAdult { get; set; }
        [Required]
        [Range(0.01, 9999.99, ErrorMessage = "Цената трябва да бъде между 0.01 и 9999.99")]
        public decimal PriceChild { get; set; }
        [Required]
        public RoomTypeEnum RoomType { get; set; }
        public string Message { get; set; }
    }
}
