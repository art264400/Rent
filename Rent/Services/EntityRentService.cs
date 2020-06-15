using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Rent.Context;
using Rent.Interfaces;
using Rent.Models;
using Rent.Models.Tag;
using Rent.Models.Util;
using RestSharp;
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
                return db.Products.Include(m => m.User).Include(m => m.Category).Where(m => m.UserId == id && m.IsDeleted==false).ToArray();
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
                Longitude = registerTag.Longitude,
                Latitude = registerTag.Latitude,
                PhoneNumber = registerTag.PhoneNumber,
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

        public bool PayMoneyForUserByLogin(decimal money, string login)
        {
            using (var db = new RentContext())
            {
                var user=db.Users.FirstOrDefault(m => m.Login == login);
                if (user == null) return false;
                user.SumMoney += money;
                db.Users.AddOrUpdate(user);
                db.SaveChanges();
                return true;
            }
        }

        public TakenProduct GetTakenProductById(int takenProductId)
        {
            using (var db = new RentContext())
            {
                return db.TakenProducts.FirstOrDefault(m => m.Id == takenProductId);
            }
        }

        public RegisterTag AddLongAndLatiByAddress(string address,RegisterTag registerTag)
        {
            try
            {
                var client = new RestClient("https://geocode-maps.yandex.ru/1.x/");
                var apikey = "a2676e6b-4540-4a36-9b7b-f7d6e77be65b";
                var geocode = address;
                var format = "json";
                var request = new RestRequest("?apikey=" + apikey + "&geocode=" + geocode + "&format=" + format, Method.GET);
                var content = client.Execute(request).Content;
                MainClass res = JsonConvert.DeserializeObject<MainClass>(content);
                String pos = res.response.GeoObjectCollection.featureMember[0].GeoObject.Point.pos;
                String[] words =pos.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                registerTag.Latitude = words[0];
                registerTag.Longitude = words[1];
                return registerTag;
            }
            catch (Exception e)
            {
                return registerTag;
            }
           
        }

        public bool DeleteUserById(int id)
        {
            using (var db = new RentContext())
            {
                var user= db.Users.FirstOrDefault(m => m.Id == id && m.IsDeleted==false);
                if (user == null) return false;
                user.IsDeleted = true;
                db.Users.AddOrUpdate(user);
                db.SaveChanges();
                return true;
            }
        }

        public bool CreateCategory(Category category)
        {
            using (var db = new RentContext())
            {
                db.Categories.AddOrUpdate(category);
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteCategoryById(int id)
        {
            using (var db = new RentContext())
            {
                var category = db.Categories.FirstOrDefault(m => m.Id == id && m.IsDeleted == false);
                if (category == null) return false;
                category.IsDeleted = true;
                db.Categories.AddOrUpdate(category);
                db.SaveChanges();
                return true;
            }
        }

        public bool UpdateCategory(Category category)
        {
            using (var db = new RentContext())
            {
                db.Categories.AddOrUpdate(category);
                db.SaveChanges();
                return true;
            }
        }

        public Category GetCategoryById(int id)
        {
            using (var db = new RentContext())
            {
                return db.Categories.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool DeleteProductById(int id)
        {
            using (var db = new RentContext())
            {
                var product = db.Products.FirstOrDefault(m => m.Id == id && m.IsDeleted==false);
                if (product == null) return false;
                product.IsDeleted = true;
                db.Products.AddOrUpdate(product);
                db.SaveChanges();
                return true;
            }
        }

        public bool UpdateProduct(Product product)
        {
            using (var db = new RentContext())
            {
                db.Products.AddOrUpdate(product);
                db.SaveChanges();
                return true;
            }
        }
        public bool CreateOrder(Order order)
        {
            using (var db = new RentContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return true;
            }
        }

        public Order LastOrderByUserId(int id)
        {
            using (var db = new RentContext())
            {
                return db.Orders.Include(m => m.User).FirstOrDefault(m => m.UserId == id && m.IsDeleted==false);
            }
        }

        public Order GetOrderById(int id)
        {
            using (var db = new RentContext())
            {
                return db.Orders.Include(m=>m.User).FirstOrDefault(m => m.Id == id);
            }
        }
        public bool UpdateOrder(Order order)
        {
            using (var db = new RentContext())
            {
                db.Orders.AddOrUpdate(order);
                db.SaveChanges();
                return true;
            }
        }
    }
}