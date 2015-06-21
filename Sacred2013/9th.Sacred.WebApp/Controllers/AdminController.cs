using _9th.Sacred.Objects.Data;
using _9th.Sacred.WebApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _9th.Sacred.WebApp.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        public ActionResult Index()
        {
            ActionResult returnAction = View();

            // Verify user had admin rights
            CookieUser cUser = Newtonsoft.Json.JsonConvert.DeserializeObject<CookieUser>(Request.Cookies[Constants._COOKIE_NAME_].Value);
            if (!MyUserService.ValidateUserAdmin(cUser.UserToken))
            {
                returnAction = RedirectToAction("Logout", "Account");
            }

            return returnAction;
        }
    }
}