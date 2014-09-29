using _9th.Sacred.Data;
using _9th.Sacred.Objects.Data;
using _9th.Sacred.Objects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Business.Services
{
    public class CampaignService : BaseService
    {

        public CampaignService(string connectionstring)
            : base(connectionstring, null)
        { }

        public CampaignResponse Create(Campaign newCampaign)
        {
            CampaignResponse response = new CampaignResponse();
            CampaignsData cData = new CampaignsData(CurrentDataContext);

            try
            {
                newCampaign.Id = cData.Create(newCampaign);
                if (newCampaign.Id > 0)
                {
                    response.Success = true;
                    response.Campaign = newCampaign;
                }
                else
                {
                    response.Message = ErrorMessages.CAMPAIGN_CREATE_GENERIC;
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public List<Campaign> ReadCampaignsForUser(int userId)
        {
            CampaignsData cData = new CampaignsData(CurrentDataContext);
            return cData.ReadCampaignsByUserId(userId);
        }

        public bool DeleteCampaignById(int id)
        {
            CampaignsData cData = new CampaignsData(CurrentDataContext);
            cData.DeleteCampaignById(id);
            return true;
        }
    }
}
