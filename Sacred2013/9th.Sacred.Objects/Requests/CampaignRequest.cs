using _9th.Sacred.Objects.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Objects.Requests
{
    public class CampaignRequest
    {
        public string UserToken { get; set; }
        public Campaign Campaign { get; set; }

        public CampaignRequest()
        {
            InitializeValues();
        }

        public void InitializeValues()
        {
            UserToken = string.Empty;
            Campaign = null;
        }
    }
}
