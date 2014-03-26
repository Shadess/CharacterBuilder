using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _9th.Sacred.Objects.Responses;

namespace _9th.Sacred.WebApi.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public LoginResponse ValidateLogin(string username, string password)
        {
            return MyUserService.ValidateUser(username, password);
        }
    }
}
