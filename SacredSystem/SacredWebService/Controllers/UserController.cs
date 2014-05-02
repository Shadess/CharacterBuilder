using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SacredWebService.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public Guid LoginUser(string username)
        {
            Guid userToken = Guid.Empty;

            return userToken;
        }

    }
}
