using _9th.Sacred.Objects.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _9th.Sacred.WebApi.Controllers
{
    public class RaceController : BaseController
    {
        [HttpGet]
        public List<Race> GetAll(string userToken)
        {
            AuthenticateUserToken(userToken);
            return MyRaceService.GetAll();
        }
    }
}