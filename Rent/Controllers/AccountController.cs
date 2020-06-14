using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using Rent.Interfaces;
using Rent.Models.Tag;
using Rent.Models.Util;
using RestSharp;

namespace Rent.Controllers
{
    public class AccountController : Controller
    {
        public IRentService _rentService;

        public AccountController(IRentService rentService)
        {
            _rentService = rentService;
        }
        // GET: Account
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Browse_item", "Rent");
            LoginTag loginModel = new LoginTag();
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginTag loginModel)
        {
            if (ModelState.IsValid)
            {

                if (_rentService.VerifyUserByLoginAndPassword(loginModel))
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.SetAuthCookie(loginModel.Login, true);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Registration()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Browse_item", "Rent");
            var registerTag = new RegisterTag();
            return View(registerTag);
        }
        [HttpPost]
        public ActionResult Registration(RegisterTag registerTag)
        {
            if (ModelState.IsValid)
            {
                var geocode = registerTag.City + ", " + registerTag.Street + ", " + registerTag.Home;
                _rentService.AddLongAndLatiByAddress(geocode, registerTag);
                if (!_rentService.RegistrationCreateUser(registerTag))
                {
                    ModelState.AddModelError("Email", "Пользователь с таким email уже существует");
                    return View(registerTag);
                }
                FormsAuthentication.SignOut();
                FormsAuthentication.SetAuthCookie(registerTag.Email, true);
                return RedirectToAction("Browse_item", "Rent");
            }
            else
            {
                return View(registerTag);
            }

        }
    }
}