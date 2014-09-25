using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _9th.Sacred.WebApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User Profile
        public ActionResult Profile(int id)
        {
            return View();
        }
    }
}