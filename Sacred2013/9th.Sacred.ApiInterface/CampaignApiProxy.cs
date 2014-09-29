using _9th.Sacred.Objects.Data;
using _9th.Sacred.Objects.Requests;
using _9th.Sacred.Objects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.ApiInterface
{
    public abstract class CampaignApiProxy
    {
        public static CampaignResponse CreateCampaign(string apiUrl, CampaignRequest content)
        {
            ApiRequest request = new ApiRequest("Campaign/Create");
            request.Content = content;

            ApiProxy proxy = new ApiProxy(apiUrl);
            return proxy.PostRequest<CampaignResponse>(request);
        }

        public static List<Campaign> ReadCampaignsForUser(string apiUrl, string userToken, int userId)
        {
            ApiRequest request = new ApiRequest("Campaign/ReadCampaignsForUser");
            request.Parameters.Add("userToken", userToken);
            request.Parameters.Add("userId", userId);

            ApiProxy proxy = new ApiProxy(apiUrl);
            return proxy.GetResponse<List<Campaign>>(request);
        }

        public static bool DeleteCampaignById(string apiUrl, string userToken, int id)
        {
            ApiRequest request = new ApiRequest("Campaign/DeleteCampaignById");
            request.Parameters.Add("userToken", userToken);
            request.Parameters.Add("id", id);

            ApiProxy proxy = new ApiProxy(apiUrl);
            return proxy.GetResponse<bool>(request);
        }
    }
}
