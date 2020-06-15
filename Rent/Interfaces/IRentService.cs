using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Context;
using Rent.Models;
using Rent.Models.Tag;

namespace Rent.Interfaces
{
    public interface IRentService
    {
        User[] GetAllUsers();
        User GetUserById(int id);
        User GetUserByLogin(string login);
        bool RemoveUserById(int id);
        bool updateUser(User updateUser);
        bool UpdateUserById(int id);
        bool VerifyUserByLoginAndPassword(LoginTag loginModel);
        bool WriteOffMoneyFromUserByLogin(decimal money,string login);
        bool PayMoneyForUserByLogin(decimal money, string login);
        bool RegistrationCreateUser(RegisterTag registerTag);
        bool DeleteUserById(int id);

        Product[] GetAllProducts();
        Product GetProductById(int id);

        Product[] GetProductByUserId(int id);
        bool CheckedIsTakenProductByProductId(int id);
        bool CheckedNoIsTakenProductByProductId(int id);
        bool CreateProduct(Product product);
        bool DeleteProductById(int id);
        bool UpdateProduct(Product product);


        void DeleteTakenProductById(int id,int userId);
        //получение всех список заброинрованных моих вещей
        TakenProduct[] GetAllTakenProductsByUserId(int userId);
        //получить список, товаров, которые я взял в аренду
        TakenProduct[] GetAllListMyTakenProduct(int userId);
        TakenProduct GetTakenProductById(int takenProductId);
        bool CreateTakenProduct(TakenProduct takenProduct);
        bool ChekedLessorProof(int idProof, int UserId); 
        bool ChekedLessorReturnProof(int idProof, int UserId);
        bool CheckedTenantProof(int idProof, int UserId);

        Category[] GetAllGategories();
        bool CreateCategory(Category category);
        bool DeleteCategoryById(int id);
        bool UpdateCategory(Category category);
        Category GetCategoryById(int id);

        RegisterTag AddLongAndLatiByAddress(string address,RegisterTag registerTag);

        bool CreateOrder(Order order);
        Order LastOrderByUserId(int id);
        Order GetOrderById(int id);
        bool UpdateOrder(Order order);
    }
}
