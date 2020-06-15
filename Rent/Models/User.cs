using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rent.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Логин")]
        public string Login { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Display(Name = "Фото")]
        public string PhotoUrl { get; set; }
        [Display(Name = "Город")]
        public string City { get; set; }
        [Display(Name = "Улица")]
        public string Street { get; set; }
        [Display(Name = "Дом")]
        public string Home { get; set; }
        public bool IsDeleted { get; set; }
        [Display(Name = "Баланс")]
        public decimal SumMoney { get; set; }
        public int RoleId { get; set; }
        [Display(Name = "Роль")]
        public Role Role { get; set; }
        [Display(Name = "Широта")]
        public string Latitude { get; set; }
        [Display(Name = "Долгота")]
        public string Longitude { get; set; }
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        
        //User()
        //{
        //}
    }
}