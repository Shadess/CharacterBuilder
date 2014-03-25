using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _9th.Sacred.Objects.Responses;
using _9th.Sacred.WebApp.Models;

namespace _9th.Sacred.WebApp.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // TODO - Validate login
                LoginResponse response;

                //if (response.Success)
                //{

                //}
                //else
                //{
                //    ModelState.AddModelError("", response.Message);
                //}
            }
            else
            {
                ModelState.AddModelError("", Constants._GENERIC_LOGIN_ERROR_);
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}