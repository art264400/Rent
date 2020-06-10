using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rent.Models;

namespace Rent.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult CreateCategory()
        {
            Category category=new Category();
            return View(category);
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            return View();
        }
    }
}