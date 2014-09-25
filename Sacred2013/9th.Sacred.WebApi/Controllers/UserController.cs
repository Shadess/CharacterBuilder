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
        public LoginResponse ValidateUser(string email, string password)
        {
            return MyUserService.ValidateUser(email, password);
        }

        [HttpGet]
        public void LogoutUser(int userId)
        {
            MyUserService.LogoutUser(userId);
        }

        [HttpPost]
        public RegisterResponse RegisterUser([FromBody] InputUser newUser)
        {
            return MyUserService.RegisterUser(newUser);
        }

        [HttpGet]
        public VerifyResponse VerifyUserRegistration(int id, string token)
        {
            return MyUserService.VerifyUserRegistration(id, token);
        }
    }
}
