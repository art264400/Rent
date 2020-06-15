using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rent.Interfaces;
using Rent.Models;

namespace Rent.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IRentService _rentService;

        public AdminController(IRentService rentService)
        {
            _rentService = rentService;
        }
        // GET: Admin

        public ActionResult ListUsers()
        {
            var users = _rentService.GetAllUsers();
            return View(users);
        }

        public ActionResult DeleteUser(int id)
        {
            _rentService.DeleteUserById(id);
            return RedirectToAction("ListUsers");
        }

        public ActionResult ListCategories()
        {
            var categories = _rentService.GetAllGategories();
            return View(categories);
        }

        public ActionResult CreateCategory()
        {
            var category = new Category();
            return View(category);
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            _rentService.CreateCategory(category);
            return RedirectToAction("ListCategories");
        }

        public ActionResult UpdateCategory(int id)
        {
            var category = _rentService.GetCategoryById(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            _rentService.UpdateCategory(category);
            return RedirectToAction("ListCategories");
        }

        public ActionResult DeleteCategory(int id)
        {
            _rentService.DeleteCategoryById(id);
            return RedirectToAction("ListCategories");
        }

    }
}