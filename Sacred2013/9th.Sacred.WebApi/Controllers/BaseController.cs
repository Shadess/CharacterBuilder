using System;
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

        private RaceService _raceservice;
        public RaceService MyRaceService
        {
            get
            {
                if (_raceservice == null)
                {
                    _raceservice = new RaceService(ConnectionString);
                }

                return _raceservice;
            }
        }

        private ClassService _classservice;
        public ClassService MyClassService
        {
            get
            {
                if (_classservice == null)
                {
                    _classservice = new ClassService(ConnectionString);
                }

                return _classservice;
            }
        }

        private HeroicService _heroicservice;
        public HeroicService MyHeroicService
        {
            get
            {
                if (_heroicservice == null)
                {
                    _heroicservice = new HeroicService(ConnectionString);
                }

                return _heroicservice;
            }
        }

        #endregion
    }
}
