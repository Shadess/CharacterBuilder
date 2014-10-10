using _9th.Sacred.Objects.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _9th.Sacred.WebApi.Controllers
{
    public class ClassController : BaseController
    {
        [HttpGet]
        public List<Class> GetAll(string userToken)
        {
            AuthenticateUserToken(userToken);
            return MyClassService.GetAll();
        }
    }
}