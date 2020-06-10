using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Rent.Models;

namespace Rent.Context
{
    public class RentContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TakenProduct> TakenProducts { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}