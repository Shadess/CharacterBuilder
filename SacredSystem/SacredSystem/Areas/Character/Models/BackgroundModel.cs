using SacredObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SacredSystem.Areas.Character.Models
{
    public class BackgroundModel
    {
        private List<Background> _theBackgrounds;
        public List<Background> TheBackgrounds
        {
            get
            {
                if (_theBackgrounds == null)
                    _theBackgrounds = new List<Background>();

                return _theBackgrounds;
            }
            set { _theBackgrounds = value; }
        }
    }
}