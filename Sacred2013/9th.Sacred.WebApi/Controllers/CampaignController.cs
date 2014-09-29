using _9th.Sacred.Objects.Data;
using _9th.Sacred.Objects.Requests;
using _9th.Sacred.Objects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace _9th.Sacred.WebApi.Controllers
{
    public class CampaignController : BaseController
    {
        [HttpPost]
        public CampaignResponse Create(CampaignRequest request)
        {
            AuthenticateUserToken(request.UserToken);
            return MyCampaignService.Create(request.Campaign);
        }

        [HttpGet]
        public List<Campaign> ReadCampaignsForUser(string userToken, int userId)
        {
            AuthenticateUserToken(userToken);
            return MyCampaignService.ReadCampaignsForUser(userId);
        }

        [HttpGet]
        public bool DeleteCampaignById(string userToken, int id)
        {
            AuthenticateUserToken(userToken);
            return MyCampaignService.DeleteCampaignById(id);
        }
    }
}