﻿using _9th.Sacred.WebApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _9th.Sacred.WebApp
{
    public abstract class SessionInfo
    {
        public static System.Web.SessionState.HttpSessionState CurrentSession
        {
            get { return HttpContext.Current.Session; }
        }

        public static string UserId
        {
            get { return CurrentSession[Constants._USER_ID_].ToString(); }
            set { CurrentSession[Constants._USER_ID_] = value; }
        }

        public static string UserToken
        {
            get { return CurrentSession[Constants._USER_TOKEN_].ToString(); }
            set { CurrentSession[Constants._USER_TOKEN_] = value; }
        }
    }
}