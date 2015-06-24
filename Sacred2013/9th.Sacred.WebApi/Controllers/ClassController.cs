using _9th.Sacred.Objects.Data;
using _9th.Sacred.Objects.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

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

        [HttpPost]
        public int AddClass(ClassRequest request)
        {
            AuthenticateUserToken(request.UserToken);
            return MyClassService.AddClass(request.Class);
        }

        [HttpPost]
        public void EditClass(ClassRequest request)
        {
            AuthenticateUserToken(request.UserToken);
            MyClassService.EditClass(request.Class);
        }

        [HttpGet]
        public void DeleteClassById(string userToken, int id)
        {
            AuthenticateUserToken(userToken);
            MyClassService.DeleteClassById(id);
        }
    }
}