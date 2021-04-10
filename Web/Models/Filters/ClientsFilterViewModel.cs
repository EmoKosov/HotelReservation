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
    public class ClientsFilterViewModel
    {

        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Името може да съдържа само букви")]
        [StringLength(40, ErrorMessage = "Името не може да бъде по-дълго от 40 символа")]
        public string FirstName { get; set; }


        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Фамилията може да съдържа само букви")]
        [StringLength(40, ErrorMessage = "Фамилията не може да бъде по-дълга от 40 символа")]
        public string LastName { get; set; }

    }
}
