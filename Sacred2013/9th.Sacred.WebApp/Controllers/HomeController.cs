using System;
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
using _9th.Sacred.Objects.Data;
using System.Web.Script.Serialization;

namespace _9th.Sacred.WebApp.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                int userId = Convert.ToInt32(Request.Cookies[Constants._COOKIE_NAME_].Values.Get(Constants._COOKIE_USER_ID_));
                return RedirectToAction("Profile", "User", new { id = userId });
            }

            InputUser blankUser = new InputUser();
            return View(blankUser);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(InputUser model, string returnUrl)
        {
            RegisterResponse response = UserApiProxy.RegisterUser(SSConfiguration.WebApiUrl, model);
            
            if (response.Success)
            {
                // Send verification email to user
                try
                {
                    using (System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(
                        new System.Net.Mail.MailAddress("tylermboettcher@gmail.com", "Sacred System"),
                        new System.Net.Mail.MailAddress(response.RegisteredUser.Email, response.RegisteredUser.Username)))
                    {
                        message.Subject = "Email confirmation";
                        message.Body = string.Format(@"Dear {0},
                        <br /><br />
                        Thank you for registering at Sacred System, please click on the below link to complete your registration.
                        <br /><br />
                        <a href='{1}' title='User Email Confirm'>{1}</a>", response.RegisteredUser.Username, Url.Action("Verify", "Account", new { Id = response.RegisteredUser.Id, Token = response.RegisteredToken.Token }, Request.Url.Scheme));
                        message.IsBodyHtml = true;

                        using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new System.Net.NetworkCredential("tylermboettcher@gmail.com", "setup2Fail");
                            smtp.EnableSsl = true;
                            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                            smtp.Timeout = 20000;
                            smtp.Send(message);
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }

                // Go to registration complete page
                return RedirectToAction("RegistrationComplete", "Account", new { email = response.RegisteredUser.Email });
            }
            else
            {
                model.Errors = response.Errors;
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