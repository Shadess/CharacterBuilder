using SacredObjects;
using SacredSystem.Areas.Character.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace SacredSystem.Areas.Character.Controllers
{
    public class CreateController : Controller
    {
        private static HttpClient _client;
        public static HttpClient Client
        {
            get
            {
                if (_client == null)
                {
                    // Setup our httpclient
                    _client = new HttpClient();
                    _client.BaseAddress = new Uri("http://localhost/SacredWebService/");
                    _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }

                return _client;
            }
        }

        //
        // GET: /Character/Create/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Background()
        {
            BackgroundModel bgModel = new BackgroundModel();

            HttpResponseMessage response = Client.GetAsync("api/CreateCharacter/GetAllBackgrounds").Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Background> backgrounds = response.Content.ReadAsAsync<IEnumerable<Background>>().Result;

                bgModel.TheBackgrounds = backgrounds.ToList<Background>();
            }

            return View(bgModel);
        }
    }
}
