using _9th.Sacred.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace _9th.Sacred.WebApp.Classes
{
    public abstract class SacredSession
    {
        public static HttpSessionState SSSession
        {
            get { return HttpContext.Current.Session; }
        }

        public static NewCharacterModel  CharCreateModel
        {
            get
            {
                if (SSSession["$_character_create_model_$"] == null)
                {
                    SSSession["$_character_create_model_$"] = new NewCharacterModel();
                }

                return SSSession["$_character_create_model_$"] as NewCharacterModel;
            }
            set { SSSession["$_character_create_model_$"] = value; }
        }
    }
}