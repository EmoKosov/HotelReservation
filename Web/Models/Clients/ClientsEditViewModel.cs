using System.ComponentModel.DataAnnotations;
using Data.Enumeration;
using Microsoft.AspNetCore.Mvc;

namespace Web.Models.Clients
{
    public class ClientsEditViewModel
    {
        [HiddenInput]
        public int Id { get; set; }


        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Моля, използвайте само букви")]
        [StringLength(40, ErrorMessage = "Name must be no longer than 40 characters")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }


        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Моля, използвайте само букви")]
        [StringLength(40, ErrorMessage = "Name must be no longer than 40 characters")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, ErrorMessage = "Телефона не може да бъде по-дълъг от 10 символа)")]
        public string TelephoneNumber { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool IsAdult { get; set; }

    }
}
