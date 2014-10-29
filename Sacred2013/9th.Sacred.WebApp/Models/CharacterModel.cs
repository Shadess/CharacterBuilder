using _9th.Sacred.Objects.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _9th.Sacred.WebApp.Models
{
    public class CharacterModel
    {
        
    }

    public class CharacterCreateModel
    {
        public NewCharacterModel SavedCharacter { get; set; }
        public List<Race> Races { get; set; }
        public List<Class> Classes { get; set; }

        public CharacterCreateModel()
        {
            InitializeValues();
        }

        public void InitializeValues()
        {
            SavedCharacter = new NewCharacterModel();
            Races = new List<Race>();
            Classes = new List<Class>();
        }
    }

    public class NewCharacterModel
    {
        public CreateCharacterSection Section { get; set; }
        public bool IsNew { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public int Race { get; set; }
        public int Class { get; set; }

        public NewCharacterModel()
        {
            InitializeValues();
        }

        public void InitializeValues()
        {
            Section = CreateCharacterSection.Race;
            IsNew = true;
            Name = string.Empty;
            Weight = string.Empty;
            Height = string.Empty;
            Sex = string.Empty;
            Age = 0;
            Race = 0;
            Class = 0;
        }

        public NewCharacterModel Copy()
        {
            return (NewCharacterModel)this.MemberwiseClone();
        }
    }

    public enum CreateCharacterSection
    {
        Race = 0,
        Class = 1,
        Heroic = 2
    }
}