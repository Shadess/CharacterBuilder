﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using _9th.Sacred.Business.Services;
using _9th.Sacred.Objects.Data;
using System.Web.Http;

namespace _9th.Sacred.WebApi.Controllers
{
    public abstract class BaseController : ApiController
    {
        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["SacredDatabase"].ConnectionString; }
        }

        private User _myuser;
        protected User MyUser
        {
            get { return _myuser; }
            set { _myuser = value; }
        }

        protected void AuthenticateUserToken(string usertoken)
        {
            if (!MyUserService.AuthenticateUserToken(usertoken))
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            //_myuser = MyUserService.GetUserFromUserToken(usertoken);
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

        private CampaignService _campaignservice;
        public CampaignService MyCampaignService
        {
            get
            {
                if (_campaignservice == null)
                {
                    _campaignservice = new CampaignService(ConnectionString);
                }

                return _campaignservice;
            }
        }

        #endregion
    }
}
