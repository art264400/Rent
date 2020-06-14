using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rent.Interfaces;
using Rent.Models;
using Rent.Services;

namespace Rent.ExtensionsForHelpers
{
    public static class AdminHelper
    {

        public static MvcHtmlString If(this MvcHtmlString value, bool evaluation)
        {
            return evaluation ? value : MvcHtmlString.Empty;
        }
        public static MvcHtmlString Money(this MvcHtmlString value)
        {
            IRentService _rentService=new EntityRentService();
            var username=_rentService.GetUserByLogin(value.ToString());
            var mvcHtmlString = new MvcHtmlString("Баланс"+username.SumMoney.ToString());
            return mvcHtmlString;
        }
    }
}