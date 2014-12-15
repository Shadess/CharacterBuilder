using _9th.Sacred.Objects.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _9th.Sacred.WebApi.Controllers
{
    public class HeroicAwakeningController : BaseController
    {
        [HttpGet]
        public List<HeroicAwakening> GetAll(string userToken)
        {
            AuthenticateUserToken(userToken);
            return MyHeroicService.GetAll();
        }
    }
}
