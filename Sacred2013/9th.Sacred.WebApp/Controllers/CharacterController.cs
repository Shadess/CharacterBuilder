using _9th.Sacred.ApiInterface;
using _9th.Sacred.WebApp.Classes;
using _9th.Sacred.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _9th.Sacred.WebApp.Controllers
{
    public class CharacterController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult CreateStart()
        {
            SacredSession.CharCreateModel = null;
            return RedirectToAction("Create", new { section = CreateCharacterSection.Race });
        }

        [Authorize]
        [OutputCache(NoStore = true, Duration = 1)]
        public ActionResult Create(CreateCharacterSection section)
        {
            // Setup our view model
            CharacterCreateModel characterData = new CharacterCreateModel();
            characterData.SavedCharacter = SacredSession.CharCreateModel;
            characterData.SavedCharacter.Section = section;

            // Fill in our view model
            if (section == CreateCharacterSection.Race)
            {
                characterData.Races = RaceApiProxy.GetAll(SSConfiguration.WebApiUrl, User.Identity.Name);
            }
            else if (section == CreateCharacterSection.Class)
            {
                characterData.Classes = ClassApiProxy.GetAll(SSConfiguration.WebApiUrl, User.Identity.Name);
            }
            else if (section == CreateCharacterSection.Heroic)
            {
                characterData.Heroics = HeroicApiProxy.GetAll(SSConfiguration.WebApiUrl, User.Identity.Name);
            }

            return View(characterData);
        }

        [Authorize]
        [HttpPost]
        public ActionResult HandleCreate(NewCharacterModel model)
        {
            model.Section++;
            SacredSession.CharCreateModel = model.Copy();

            return RedirectToAction("Create", new { section = model.Section });
        }
    }
}