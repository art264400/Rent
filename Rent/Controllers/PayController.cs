using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Rent.Interfaces;
using Rent.Models;
using Rent.Models.Tag;

namespace Rent.Controllers
{
    [Authorize]
    public class PayController : Controller
    {
        public IRentService _rentService;

        public PayController(IRentService rentService)
        {
            _rentService = rentService;
        }
        // GET: Pay
        public ActionResult Index()
        {
            var userId = _rentService.GetUserByLogin(User.Identity.Name).Id;
            Order order = new Order
            {
                UserId = userId
            };
            _rentService.CreateOrder(order);
            var newOrder = _rentService.LastOrderByUserId(userId);
            OrderModel orderModel = new OrderModel { OrderId = newOrder.Id.ToString() };
            return View(orderModel);
        }

        [HttpGet]
        public string Paid()
        {
            return "<p>заказ оплачен</p>";
        }

        [HttpPost]
        public void Paid(string notification_type, string operation_id, string label, string datetime,
            decimal amount, decimal withdraw_amount, string sender, string sha1_hash, string currency, bool codepro)
        {
            string key = "6M3n1qddP8qRJVhsQiy54V1w"; // секретный код
            // проверяем хэш
            string paramString = String.Format("{0}&{1}&{2}&{3}&{4}&{5}&{6}&{7}&{8}",
                notification_type, operation_id, amount, currency, datetime, sender,
                codepro.ToString().ToLower(), key, label);
            string paramStringHash1 = GetHash(paramString);
            // создаем класс для сравнения строк
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            // если хэши идентичны, добавляем данные о заказе в бд
            if (0 == comparer.Compare(paramStringHash1, sha1_hash))
            {
                var order=_rentService.GetOrderById(Convert.ToInt32(label));
                order.Operation_Id = operation_id;
                order.Date = DateTime.Now;
                order.Amount = amount;
                order.WithdrawAmount = withdraw_amount;
                order.Sender = sender;
                order.IsDeleted = true;
                _rentService.UpdateOrder(order);
                _rentService.PayMoneyForUserByLogin(amount, order.User.Login);
            }
        }
        public string GetHash(string val)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] data = sha.ComputeHash(Encoding.Default.GetBytes(val));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}