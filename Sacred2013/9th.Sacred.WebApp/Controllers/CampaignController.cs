using _9th.Sacred.ApiInterface;
using _9th.Sacred.Objects.Data;
using _9th.Sacred.Objects.Requests;
using _9th.Sacred.Objects.Responses;
using _9th.Sacred.WebApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _9th.Sacred.WebApp.Controllers
{
    public class CampaignController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Campaign newCampaign)
        {
            string message = string.Empty;

            // Setup our new campaign
            newCampaign.UserId = Convert.ToInt32(Request.Cookies[Constants._COOKIE_NAME_].Values.Get(Constants._COOKIE_USER_ID_));
            newCampaign.CreateDate = DateTime.Now;

            // Create our campaign request
            CampaignRequest request = new CampaignRequest();
            request.UserToken = User.Identity.Name;
            request.Campaign = newCampaign;

            try
            {
                // Send response to create the new campaign
                CampaignResponse response = CampaignApiProxy.CreateCampaign(SSConfiguration.WebApiUrl, request);
                if (response.Success)
                {
                    return RedirectToAction("Profile", "User", new { id = response.Campaign.UserId });
                }
                else
                {
                    return View(response.Message);
                }
            }
            catch (System.Web.Http.HttpResponseException)
            {
                // Should be - HttpResponseException
                return RedirectToAction("Logout", "Account");
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return View(message);
        }

        [Authorize]
        [HttpGet]
        public bool Delete(int id)
        {
            bool result = false;

            try
            {
                result = CampaignApiProxy.DeleteCampaignById(SSConfiguration.WebApiUrl, User.Identity.Name, id);
            }
            catch (Exception) { }

            return result;
        }
    }
}