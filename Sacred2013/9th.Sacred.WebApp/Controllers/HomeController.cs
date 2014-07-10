﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using _9th.Sacred.ApiInterface;
using _9th.Sacred.Objects.Responses;
using _9th.Sacred.WebApp.Models;
using _9th.Sacred.WebApp.Classes;

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
        public ActionResult Index(LoginRegisterModel dualModel, string returnUrl)
        {
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

            return View(dualModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}