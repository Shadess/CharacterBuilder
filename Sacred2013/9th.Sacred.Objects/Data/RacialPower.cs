using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Objects.Data
{
    public class RacialPower
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PowerType Type { get; set; }
        public ActionType ActionType { get; set; }
        public EffectType EffectType { get; set; }
        public int Range { get; set; }
        public int AuraRange { get; set; }
        public string Description { get; set; }

        public RacialPower()
        {
            InitializeValues();
        }

        //-------------------------------------------------
        public void InitializeValues()
        {
            Id = 0;
            Name = string.Empty;
            Type = 0;
            ActionType = 0;
            EffectType = 0;
            Range = 0;
            AuraRange = 0;
            Description = string.Empty;
        }
    }
}
