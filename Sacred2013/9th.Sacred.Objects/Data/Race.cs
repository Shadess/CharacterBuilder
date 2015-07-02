using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Objects.Data
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CommonName { get; set; }
        public string Lifespan { get; set; }
        public string Height { get; set; }
        public string Origin { get; set; }
        public string SocialStatus { get; set; }
        public string FlavorText { get; set; }
        public string Description { get; set; }

        public List<RacePower> RacePowers { get; set; }

        public Race()
        {
            InitializeValues();
        }

        //-------------------------------------------------
        public void InitializeValues()
        {
            Id = 0;
            Name = string.Empty;
            CommonName = string.Empty;
            Lifespan = string.Empty;
            Height = string.Empty;
            Origin = string.Empty;
            SocialStatus = string.Empty;
            FlavorText = string.Empty;
            Description = string.Empty;

            RacePowers = new List<RacePower>();
        }
    }
}
