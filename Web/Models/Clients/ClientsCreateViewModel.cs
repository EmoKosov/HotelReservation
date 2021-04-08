using System.ComponentModel.DataAnnotations;
using Data.Enumeration;

namespace Web.Models.Clients
{
    public class ClientsCreateViewModel
    {
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Моля, използвайте само букви")]
        [StringLength(40, ErrorMessage = "Името не трябва да бъде по-дълго от 40 символа")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }


        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Моля, използвайте само букви")]
        [StringLength(40, ErrorMessage = "Фамилията не трябва да бъде по-дълга от 40 символа")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Моля, използвайте само цифри")]
        [StringLength(10, ErrorMessage = "Телефона не може да бъде по-дълъг от 10 символа)")]
        public string TelephoneNumber { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool IsAdult { get; set; }
    }
}
