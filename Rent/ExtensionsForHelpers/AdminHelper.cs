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
            var mvcHtmlString = new MvcHtmlString("Баланс: "+username.SumMoney.ToString());
            return mvcHtmlString;
        }
        public static MvcHtmlString Action(this MvcHtmlString value)
        {
            TagBuilder a = new TagBuilder("a");
            a.Attributes.Add("href","#");
            a.Attributes.Add("class","dropdown-toggle");
            a.Attributes.Add("data-toggle","dropdown");
            a.Attributes.Add("role","button");
            a.Attributes.Add("aria-haspopup","true");
            a.Attributes.Add("aria-expanded","false");
            a.SetInnerText("Админ");
            var mvcHtmlString = new MvcHtmlString(a.ToString());
            return mvcHtmlString;
        }
    }
}