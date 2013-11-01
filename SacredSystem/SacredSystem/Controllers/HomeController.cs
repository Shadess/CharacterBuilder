using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SacredSystem.Models;

namespace SacredSystem.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            string error = Request["error"];

            if (error != null && error != string.Empty)
                ModelState.AddModelError("", error);

            if (User.Identity.IsAuthenticated)
            {
                System.Diagnostics.Debug.WriteLine("USER LOGGED IN");
                return RedirectToAction("Index", "User");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
