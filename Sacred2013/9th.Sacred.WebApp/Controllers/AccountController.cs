using _9th.Sacred.ApiInterface;
using _9th.Sacred.Objects.Responses;
using _9th.Sacred.WebApp.Classes;
using _9th.Sacred.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _9th.Sacred.WebApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginRegisterModel dualModel, string returnUrl)
        {
            // TODO: Login User
            LoginModel model = dualModel.LoginModel;

            if (ModelState.IsValid)
            {
                LoginResponse response = UserApiProxy.ValidateLogin(SSConfiguration.WebApiUrl, model.UserName, model.Password);

                if (response.Success)
                {
                    SessionInfo.UserToken = response.UserToken.ToString();
                    FormsAuthentication.SetAuthCookie(model.UserName, true);

                    if (response.AutoLogoutInMinutes > 0)
                    {
                        Session.Timeout = response.AutoLogoutInMinutes;
                    }

                    // Redirect to url or user homepage
                    if (returnUrl != null && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", Constants._GENERIC_LOGIN_ERROR_);
            }

            return RedirectToAction("Index", "Home", new {@returnUrl = returnUrl});
        }
	}
}