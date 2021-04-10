using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data.Enumeration;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Models.Clients;
using Web.Models.Rooms;
using Web.Models.Users;

namespace Web.Models.Reservations
{
    public class UsersFilterViewModel
    {


        [StringLength(20, ErrorMessage = "Потребителското име не може да бъде по-дълго от 20 символа")]
        public string Username { get; set; }


        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Името може да съдържа само букви")]
        [StringLength(40, ErrorMessage = "Името не може да бъде по-дълго от 40 символа")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }


        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Презимето може да съдържа само букви")]
        [StringLength(40, ErrorMessage = "Презимето не може да бъде по-дълго от 40 символа")]
        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }


        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Фамилията може да съдържа само букви")]
        [StringLength(40, ErrorMessage = "Фамилията не може да бъде по-дълга от 40 символа")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }


        [DataType(DataType.Text)]
        public string Email { get; set; }

    }
}
