using System;
using System.ComponentModel.DataAnnotations;
using Data.Enumeration;
using Microsoft.AspNetCore.Mvc;

namespace Web.Models.Users
{
    public class UsersEditViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Потребителското име не трябва да бъде по-дълго от 20 символа")]
        public string Username { get; set; }

        public string Password { get; set; }


        [Required]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Моля, използвайте само букви")]
        [StringLength(40, ErrorMessage = "Името не може да бъде по-дълго от 40 символа")]
        public string FirstName { get; set; }


        [Required]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Моля, използвайте само букви")]
        [StringLength(40, ErrorMessage = "Презимето не може да бъде по-дълго от 40 символа")]
        public string MiddleName { get; set; }


        [Required]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Моля, използвайте само букви")]
        [StringLength(40, ErrorMessage = "Фамилията не може да бъде по-дълга от 40 символа")]
        public string LastName { get; set; }


        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Моля, използвайте само цифри")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "ЕГН-то трябва да бъде 10 символа")]
        public string EGN { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, ErrorMessage = "Телефонният номер не може да бъде по-дълъг от 10 символа")]
        public string TelephoneNumber { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required]
        public bool IsActive { get; set; }

        public DateTime? FiredOn { get; set; }

        public string Message { get; set; }

    }
}
