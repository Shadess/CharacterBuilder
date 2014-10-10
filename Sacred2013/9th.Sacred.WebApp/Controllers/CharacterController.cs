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
            return RedirectToAction("Create");
        }

        [Authorize]
        public ActionResult Create(NewCharacterModel model)
        {
            // Setup our view model
            CharacterCreateModel characterData = new CharacterCreateModel();
            NewCharacterModel savedCharData = SacredSession.CharCreateModel;

            // Setup view model saved character data
            if (!model.IsNew)
            {
                // If model is not new we have progressed forward
                savedCharData = model.Copy();
                model.Section++;
                characterData.SavedCharacter = model;
            }
            else
            {
                // Post back so let's get our old save data
                characterData.SavedCharacter = savedCharData;
            }

            // Fill in our view model
            if (characterData.SavedCharacter.Section == CreateCharacterSection.Race)
            {
                characterData.Races = RaceApiProxy.GetAll(SSConfiguration.WebApiUrl, User.Identity.Name);
            }
            else if (characterData.SavedCharacter.Section == CreateCharacterSection.Class)
            {
                characterData.Classes = ClassApiProxy.GetAll(SSConfiguration.WebApiUrl, User.Identity.Name);
            }

            // Save the user character data into the session
            SacredSession.CharCreateModel = savedCharData;

            return View(characterData);
        }
    }
}