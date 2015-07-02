using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Objects.Data
{
    public class RacePower
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Attributes Attributes { get; set; }

        public RacePower()
        {
            InitializeValues();
        }

        //-------------------------------------------------
        public void InitializeValues()
        {
            Id = 0;
            RaceId = 0;
            Name = string.Empty;
            Description = string.Empty;
            Attributes = new Attributes();
        }
    }
}
