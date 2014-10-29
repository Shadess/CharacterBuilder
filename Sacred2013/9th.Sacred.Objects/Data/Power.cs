using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Objects.Data
{
    public class Power
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PowerCategory Category { get; set; }
        public PowerType Type { get; set; }
        public ActionType ActionType { get; set; }
        public EffectType EffectType { get; set; }
        public int Range { get; set; }
        public int AuraRange { get; set; }
        public string Description { get; set; }
        public int Tier { get; set; }
        public bool Active { get; set; }
        public List<PowerSpecialization> Specializations { get; set; }

        public Power()
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
            Tier = 0;
            Active = true;
            Specializations = new List<PowerSpecialization>();
        }
    }

    public enum PowerCategory
    {
        Race = 1,
        Class = 2,
        Heroic = 3
    }

    public enum PowerType
    {
        Passive = 1,
        Encounter = 2,
        Mana = 3,
        Armor = 4,
        Paragon = 5
    }

    public enum ActionType
    {
        None = 0,
        Free = 1,
        Move = 2,
        Major = 3,
        Minor = 4,
        [Description("Move or Minor")]
        MoveOrMinor = 5
    }

    public enum EffectType
    {
        None = 0,
        Personal = 1,
        MeleeTouch = 2,
        Aura = 3,
        Range = 4,
        WeaponRange = 5,
        CombatZone = 6,
        CompanionRange = 7
    }
}
