using _9th.Sacred.ApiInterface;
using _9th.Sacred.Business.Services;
using _9th.Sacred.Objects.Data;
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
    public class UserController : BaseController
    {
        // GET: User Profile
        new public ActionResult Profile(int id)
        {
            //UserModel model = new UserModel();

            //try
            //{
            //    int loggedInUserId = Convert.ToInt32(Request.Cookies[Constants._COOKIE_NAME_].Values.Get(Constants._COOKIE_USER_ID_));
            //    model.User = UserApiProxy.GetUserById(SSConfiguration.WebApiUrl, User.Identity.Name, id);
            //    model.Campaigns = CampaignApiProxy.ReadCampaignsForUser(SSConfiguration.WebApiUrl, User.Identity.Name, id);

            //    if (model.User == null || model.User.Id != loggedInUserId)
            //    {
            //        // Looking at another's profile
            //        return RedirectToAction("Profile", "User", new { id = loggedInUserId });
            //    }
            //}
            //catch (System.Web.Http.HttpResponseException)
            //{
            //    // Not authorized
            //    return RedirectToAction("Logout", "Account");
            //}

            //return View(model);

            //ActionResult returnAction = RedirectToAction("Logout", "Account");

            //CookieUser cUser = Newtonsoft.Json.JsonConvert.DeserializeObject<CookieUser>(Request.Cookies[Constants._COOKIE_NAME_].Value);
            //if (AuthenticateUserToken(cUser.UserToken))
            //{
            //    Objects.Data.User profileUser = MyUserService.ReadUserById(id);
            //    Objects.Data.User loggedInUser = MyUserService.ReadUserByToken(cUser.UserToken);

            //    if (profileUser == null || profileUser.Id != loggedInUser.Id)
            //    {
            //        // Looking at another's profile
            //        returnAction = RedirectToAction("Profile", "User", new { id = loggedInUser.Id });
            //    }
            //    else
            //    {
            //        returnAction = View("~/Views/User/Profile.cshtml", null, profileUser.Username);
            //    }
            //}

            return View();
        }
    }
}