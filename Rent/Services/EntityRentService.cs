using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Rent.Context;
using Rent.Interfaces;
using Rent.Models;
using Rent.Models.Tag;
using NotImplementedException = System.NotImplementedException;

namespace Rent.Services
{
    public class EntityRentService : IRentService
    {
        public User[] GetAllUsers()
        {
            using (var db = new RentContext())
            {
                return db.Users.Where(m => m.IsDeleted == false).ToArray();
            }
        }

        public User GetUserById(int id)
        {
            using (var db = new RentContext())
            {
                return db.Users.FirstOrDefault(m => m.Id == id);
            }
        }

        public User GetUserByLogin(string login)
        {
            using (var db = new RentContext())
            {
                return db.Users.FirstOrDefault(m => m.Login == login);
            }
        }

        public bool RemoveUserById(int id)
        {
            using (var db = new RentContext())
            {
                var user = GetUserById(id);
                if (user == null) return false;
                user.IsDeleted = true;
                db.Users.AddOrUpdate(user);
                db.SaveChanges();
                return true;
            }
        }

        public bool updateUser(User updateUser)
        {
            using (var db = new RentContext())
            {
                db.Users.AddOrUpdate(updateUser);
                db.SaveChanges();
                return true;
            }
        }

        public bool UpdateUserById(int id)
        {
            throw new NotImplementedException();
        }

        public bool VerifyUserByLoginAndPassword(LoginTag loginModel)
        {
            using (var db = new RentContext())
            {
                var user = db.Users.FirstOrDefault(m => m.Login == loginModel.Login && m.Password == loginModel.Password);
                if (user != null)
                {
                    return true;
                }

                return false;
            }
        }

        public Product[] GetAllProducts()
        {
            using (var db = new RentContext())
            {
                return db.Products
                    .Where(m => m.IsDeleted == false && m.IsTaken == false)
                    .Include(m => m.Category)
                    .Include(m => m.User)
                    .ToArray();
            }
        }

        public Product GetProductById(int id)
        {
            using (var db = new RentContext())
            {
                var product = db.Products.Include(m => m.Category).Include(m => m.User).FirstOrDefault(m =>
                        m.IsDeleted == false && m.IsTaken == false && m.Id == id);
                return product;
            }
        }
        //списываем деньги у пользователя по логину
        public bool WriteOffMoneyFromUserByLogin(decimal money, string login)
        {
            using (var db = new RentContext())
            {
                var user = db.Users.FirstOrDefault(m => m.Login == login);
                if (user == null) return false;
                if (user.SumMoney < money) return false;
                user.SumMoney -= money;
                db.Users.AddOrUpdate(user);
                db.SaveChanges();
                return true;
            }
        }

        public bool CheckedIsTakenProductByProductId(int id)
        {
            using (var db = new RentContext())
            {
                var product = db.Products.Include(m => m.User).FirstOrDefault(m => m.Id == id);
                if (product == null) return false;
                product.IsTaken = true;
                db.Products.AddOrUpdate(product);
                db.SaveChanges();
                return true;
            }
        }

        public bool CreateProduct(Product product)
        {
            using (var db=new RentContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
                return true;
            }
        }

        public TakenProduct[] GetAllTakenProductsByUserId(int userId)
        {
            using (var db = new RentContext())
            {
                return db.TakenProducts.Include(m => m.User).Include(m => m.Product).Where(m => m.IsDeleted == false && m.Product.UserId == userId).ToArray();
            }
        }

        public TakenProduct[] GetAllListMyTakenProduct(int userId)
        {
            using (var db = new RentContext())
            {
                return db.TakenProducts.Include(m => m.User).Include(m => m.Product).Where(m => m.IsDeleted == false && m.UserId == userId).ToArray();
            }
        }

        public Product[] GetProductByUserId(int id)
        {
            using (var db = new RentContext())
            {
                return db.Products.Include(m => m.User).Include(m => m.Category).Where(m => m.UserId == id).ToArray();
            }
        }

        public bool CreateTakenProduct(TakenProduct takenProduct)
        {
            using (var db = new RentContext())
            {
                db.TakenProducts.AddOrUpdate(takenProduct);
                db.SaveChanges();
                return true;
            }
        }

        public bool ChekedLessorProof(int idProof, int UserId)
        {
            using (var db = new RentContext())
            {
                var takenProduct = db.TakenProducts.Include(m => m.Product).FirstOrDefault(m => m.Id == idProof && m.Product.UserId == UserId && m.IsDeleted == false);
                if (takenProduct == null) return false;
                takenProduct.LessorProof = true;
                db.TakenProducts.AddOrUpdate(takenProduct);
                db.SaveChanges();
                return true;
            }
        }

        public bool ChekedLessorReturnProof(int idProof, int UserId)
        {
            using (var db = new RentContext())
            {
                var takenProduct = db.TakenProducts.Include(m => m.Product).FirstOrDefault(m => m.Id == idProof && m.Product.UserId == UserId && m.IsDeleted == false);
                if (takenProduct == null) return false;
                takenProduct.LessonReturnProof = true;
                db.TakenProducts.AddOrUpdate(takenProduct);
                db.SaveChanges();
                return true;
            }
        }

        public bool CheckedTenantProof(int idProof, int UserId)
        {
            using (var db = new RentContext())
            {
                var takenProduct = db.TakenProducts.FirstOrDefault(m => m.Id == idProof && m.UserId == UserId && m.IsDeleted == false);
                if (takenProduct == null) return false;
                takenProduct.TenantProof = true;
                db.TakenProducts.AddOrUpdate(takenProduct);
                db.SaveChanges();
                return true;
            }
        }

        public void DeleteTakenProductById(int id, int userId)
        {
            using (var db = new RentContext())
            {
                var takenProduct = db.TakenProducts.FirstOrDefault(m => m.Id == id && m.Product.UserId == userId);
                takenProduct.IsDeleted = true;
                db.TakenProducts.AddOrUpdate(takenProduct);
                db.SaveChanges();
            }
        }

        public Category[] GetAllGategories()
        {
            using (var db = new RentContext())
            {
                return db.Categories.Where(m => m.IsDeleted == false).ToArray();
            }
        }

        public bool CheckedNoIsTakenProductByProductId(int id)
        {
            using (var db = new RentContext())
            {
                var product = db.Products.Include(m => m.User).FirstOrDefault(m => m.Id == id);
                if (product == null) return false;
                product.IsTaken = false;
                db.Products.AddOrUpdate(product);
                db.SaveChanges();
                return true;
            }
        }

        public bool RegistrationCreateUser(RegisterTag registerTag)
        {
            var user = new User()
            {
                Login = registerTag.Email,
                Password = registerTag.Password,
                Name = registerTag.Name,
                Surname = registerTag.Surname,
                PhotoUrl = registerTag.PhotoUrl,
                City = registerTag.City,
                Street = registerTag.Street,
                Home = registerTag.Home,
                IsDeleted = false,
                RoleId = 2,
                SumMoney = 0
            };
            using (var db = new RentContext())
            {
                var userIsLive = db.Users.FirstOrDefault(m => m.Login == registerTag.Email);
                if (userIsLive != null) return false;
                db.Users.AddOrUpdate(user);
                db.SaveChanges();
                return true;
            }
        }
    }
}