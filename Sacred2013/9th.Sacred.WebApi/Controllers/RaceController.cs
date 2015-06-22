using _9th.Sacred.Objects.Data;
using _9th.Sacred.Objects.Requests;
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

        [HttpPost]
        public int AddRace(RaceRequest request)
        {
            AuthenticateUserToken(request.UserToken);
            return MyRaceService.AddRace(request.Race);
        }

        [HttpPost]
        public void EditRace(RaceRequest request)
        {
            AuthenticateUserToken(request.UserToken);
            MyRaceService.EditRace(request.Race);
        }
    }
}