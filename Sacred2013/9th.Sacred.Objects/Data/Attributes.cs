using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Objects.Data
{
    public class Attributes
    {
        public int Id { get; set; }
        public int HitPoints { get; set; }
        public int Armor { get; set; }
        public int Speed { get; set; }
        public int Stamina { get; set; }
        public int Mana { get; set; }
        public int Regen { get; set; }
        public int Initiative { get; set; }
        public int Vision { get; set; }
        public int SpecializationPoint { get; set; }
        public int AwakeningPoint { get; set; }
        public bool Acrobatics { get; set; }
        public bool Arcana { get; set; }
        public bool Athletics { get; set; }
        public bool Bluff { get; set; }
        public bool Diplomacy { get; set; }
        public bool Endurance { get; set; }
        public bool Heal { get; set; }
        public bool History { get; set; }
        public bool Insight { get; set; }
        public bool Intimidate { get; set; }
        public bool Nature { get; set; }
        public bool Perception { get; set; }
        public bool Religion { get; set; }
        public bool Stealth { get; set; }
        public bool Thievery { get; set; }

        public Attributes()
        {
            Id = 0;
            HitPoints = 0;
            Armor = 0;
            Speed = 0;
            Stamina = 0;
            Mana = 0;
            Regen = 0;
            Initiative = 0;
            Vision = 0;
            SpecializationPoint = 0;
            AwakeningPoint = 0;
            Acrobatics = false;
            Arcana = false;
            Athletics = false;
            Bluff = false;
            Diplomacy = false;
            Endurance = false;
            Heal = false;
            History = false;
            Insight = false;
            Intimidate = false;
            Nature = false;
            Perception = false;
            Religion = false;
            Stealth = false;
            Thievery = false;
        }
    }
}
