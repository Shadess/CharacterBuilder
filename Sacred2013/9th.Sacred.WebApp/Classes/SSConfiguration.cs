using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace _9th.Sacred.WebApp.Classes
{
    public static class SSConfiguration
    {
        public static string WebApiUrl
        {
            get { return ConfigurationManager.AppSettings["SacredApiUrl"].ToString(); }
        }
    }
}