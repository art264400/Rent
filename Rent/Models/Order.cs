﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent.Models
{
    public class Order
    {
        public int Id { get; set; } // id заказа
        public DateTime? Date { get; set; } // дата
        public decimal Sum { get; set; } // сумма заказа
        public string Sender { get; set; } // отправитель - кошелек в ЯД
        public string Operation_Id { get; set; } // id операции в ЯД
        public decimal? Amount { get; set; } // сумма, которую заплатали с учетом комиссии
        public decimal? WithdrawAmount { get; set; } // сумма, которую заплатали без учета комиссии
        public int? UserId { get; set; } // id пользователя в системе, который сделал заказ
        public User User { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}