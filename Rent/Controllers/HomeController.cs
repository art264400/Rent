using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rent.Context;

namespace Rent.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            //var db = new RentContext();
            //var category = db.Categories.FirstOrDefault(m => m.Id == 1);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}