using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SacredSystem.Models;

namespace SacredSystem.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        [Authorize]
        public ActionResult Index()
        {
            ProfileModel tModel = new ProfileModel();
            tModel.DisplayName = User.Identity.Name;
            return View(tModel);
        }

    }
}
