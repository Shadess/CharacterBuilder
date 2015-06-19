using _9th.Sacred.Business.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _9th.Sacred.WebApp.Controllers
{
    public class BaseController : Controller
    {
        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["SacredDatabase"].ConnectionString; }
        }

        protected bool AuthenticateUserToken(string usertoken)
        {
            return MyUserService.AuthenticateUserToken(usertoken);
        }

        #region Service Initialization

        private UserService _userservice;
        public UserService MyUserService
        {
            get
            {
                if (_userservice == null)
                {
                    _userservice = new UserService(ConnectionString);
                }

                return _userservice;
            }
        }

        #endregion
    }
}