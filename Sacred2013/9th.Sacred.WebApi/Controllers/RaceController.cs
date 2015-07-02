using _9th.Sacred.Objects.Data;
using _9th.Sacred.Objects.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

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
        public Race AddRace(RaceRequest request)
        {
            AuthenticateUserToken(request.UserToken);
            return MyRaceService.AddRace(request.Race);
        }

        [HttpPost]
        public Race EditRace(RaceRequest request)
        {
            AuthenticateUserToken(request.UserToken);
            return MyRaceService.EditRace(request.Race);
        }

        [HttpGet]
        public void DeleteRaceById(string userToken, int id)
        {
            AuthenticateUserToken(userToken);
            MyRaceService.DeleteClassById(id);
        }
    }
}