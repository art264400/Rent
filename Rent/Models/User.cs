using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string PhotoUrl { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public bool IsDeleted { get; set; }
        public decimal SumMoney { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        //User()
        //{
        //}
    }
}