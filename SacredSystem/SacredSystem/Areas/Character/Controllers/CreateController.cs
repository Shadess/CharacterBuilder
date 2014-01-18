using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

using WebServiceModels;

namespace SacredSystem.Areas.Character.Controllers
{
    public class CreateController : Controller
    {
        //
        // GET: /Character/Create/
        [Authorize]
        public ActionResult Index()
        {
            //HttpResponseMessage response = 
            HttpClient client = new HttpClient();
            // Setup our httpclient
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/SacredWebService/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            BackgroundsModel bgModel = new BackgroundsModel();

            HttpResponseMessage response = client.GetAsync("api/CreateCharacter/GetAllBackgrounds").Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<BackgroundsModel> backgrounds = response.Content.ReadAsAsync<IEnumerable<BackgroundsModel>>().Result;
                bgModel.Name = backgrounds.First().Name;
            }

            return View(bgModel);
        }

    }
}
