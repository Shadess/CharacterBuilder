﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SacredSystem.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}
