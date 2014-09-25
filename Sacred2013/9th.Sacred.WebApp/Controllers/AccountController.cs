﻿using _9th.Sacred.ApiInterface;
using _9th.Sacred.Objects.Data;
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
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(LoginRegisterModel dualModel, string returnUrl)
        //{
        //    // TODO: Login User
        //    LoginModel model = dualModel.LoginModel;

        //    if (ModelState.IsValid)
        //    {
        //        LoginResponse response = UserApiProxy.ValidateLogin(SSConfiguration.WebApiUrl, model.UserName, model.Password);

        //        if (response.Success)
        //        {
        //            SessionInfo.UserToken = response.UserToken.ToString();
        //            FormsAuthentication.SetAuthCookie(model.UserName, true);

        //            if (response.AutoLogoutInMinutes > 0)
        //            {
        //                Session.Timeout = response.AutoLogoutInMinutes;
        //            }

        //            // Redirect to url or user homepage
        //            if (returnUrl != null && Url.IsLocalUrl(returnUrl))
        //            {
        //                return Redirect(returnUrl);
        //            }
        //            else
        //            {
        //                return RedirectToAction("Index", "User");
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", response.Message);
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", Constants._GENERIC_LOGIN_ERROR_);
        //    }

        //    return RedirectToAction("Index", "Home", new {@returnUrl = returnUrl});
        //}

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View(new InputUser());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(InputUser user, string returnUrl)
        {
            LoginResponse response = UserApiProxy.ValidateUser(SSConfiguration.WebApiUrl, user.Email, user.Password);

            if (response.Success)
            {
                // Successful login
                SessionInfo.UserId = response.User.Id.ToString();
                SessionInfo.UserToken = response.UserToken.ToString();
                FormsAuthentication.SetAuthCookie(response.User.Email, true);

                if (response.AutoLogoutInMinutes > 0)
                {
                    Session.Timeout = response.AutoLogoutInMinutes;
                }

                // Redirect to url or user profile
                if (returnUrl != null && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Profile", "User", new { id = response.User.Id });
                }
            }
            else
            {
                user.Errors = new List<string>();
                user.Errors.Add(response.Message);
            }

            return View(user);
        }

        [Authorize]
        public ActionResult Logout()
        {
            // Delete login tokens
            UserApiProxy.LogoutUser(SSConfiguration.WebApiUrl, Convert.ToInt32(SessionInfo.UserId));

            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult RegistrationComplete(string email)
        {
            return View((object)email);
        }

        public ActionResult Verify(int Id, string Token)
        {
            VerifyResponse response = UserApiProxy.VerifyUserRegistration(SSConfiguration.WebApiUrl, Id, Token);

            if (!response.Success)
            {
                // Bad data or something - go home
                return RedirectToAction("Index", "Home");
            }

            return View(response.User);
        }
	}
}