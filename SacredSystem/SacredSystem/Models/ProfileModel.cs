using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebServiceModels;

namespace SacredSystem.Models
{
    public class ProfileModel
    {
        public string DisplayName { get; set; }

        private List<ProfileCharacter> _characters;
        public List<ProfileCharacter> Characters
        {
            get
            {
                if (_characters == null)
                    _characters = new List<ProfileCharacter>();

                return _characters;
            }
            set { _characters = value; }
        }
    }

    public class ProfileCharacter
    {
        public string CharId { get; set; }
        public string CharName { get; set; }
        public int Level { get; set; }
        public BasicClasses Class { get; set; }
        public ParagonClasses ParagonClass { get; set; }
        public HeroicSpirits HeroicSpirit { get; set; }
        public string CampaignName { get; set; }
    }

    public class ProfileCampaign
    {
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
    }
}