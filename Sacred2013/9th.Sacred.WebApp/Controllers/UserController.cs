using _9th.Sacred.ApiInterface;
using _9th.Sacred.WebApp.Classes;
using _9th.Sacred.WebApp.Models;
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
        new public ActionResult Profile(int id)
        {
            UserModel model = new UserModel();

            try
            {
                int loggedInUserId = Convert.ToInt32(Request.Cookies[Constants._COOKIE_NAME_].Values.Get(Constants._COOKIE_USER_ID_));
                model.User = UserApiProxy.GetUserById(SSConfiguration.WebApiUrl, User.Identity.Name, id);
                model.Campaigns = CampaignApiProxy.ReadCampaignsForUser(SSConfiguration.WebApiUrl, User.Identity.Name, id);

                if (model.User == null || model.User.Id != loggedInUserId)
                {
                    // Looking at another's profile
                    return RedirectToAction("Profile", "User", new { id = loggedInUserId });
                }
            }
            catch (System.Web.Http.HttpResponseException)
            {
                // Not authorized
                return RedirectToAction("Logout", "Account");
            }

            return View(model);
        }
    }
}