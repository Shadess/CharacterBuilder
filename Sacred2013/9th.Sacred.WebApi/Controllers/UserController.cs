using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _9th.Sacred.Objects.Responses;
using _9th.Sacred.Objects.Data;

namespace _9th.Sacred.WebApi.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public LoginResponse ValidateLogin(string username, string password)
        {
            return MyUserService.ValidateUser(username, password);
        }

        [HttpPost]
        public RegisterResponse RegisterUser([FromBody] RegisterUser newUser)
        {
            return MyUserService.RegisterUser(newUser);
        }
    }
}
