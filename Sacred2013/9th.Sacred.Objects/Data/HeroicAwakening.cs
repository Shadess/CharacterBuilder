using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Objects.Data
{
    public class HeroicAwakening
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FlavorText { get; set; }
        public string Description { get; set; }
        public List<Power> Powers { get; set; }

        public HeroicAwakening()
        {
            InitializeValues();
        }

        //-------------------------------------------------
        public void InitializeValues()
        {
            Id = 0;
            Name = string.Empty;
            FlavorText = string.Empty;
            Description = string.Empty;
            Powers = new List<Power>();
        }
    }
}
