using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rent.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Discription { get; set; }
        public string PhotoUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsTaken { get; set; }
        public bool IsDeleted { get; set; }
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}