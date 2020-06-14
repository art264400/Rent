using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rent.Models.Tag
{
    public class RegisterTag
    {
        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "пороль")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Повтор пороля")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Ваше фото")]
        public string PhotoUrl { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Город")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Улица")]
        public string Street { get; set; }
        [Required]
        [Display(Name = "Дом")]
        public string Home { get; set; }
        [Required]
        [Display(Name = "Дом")]
        public string Home { get; set; }
        [Display(Name = "Широта")]
        public string Latitude { get; set; }
        [Display(Name = "Долгота")]
        public string Longitude { get; set; }
    }
}