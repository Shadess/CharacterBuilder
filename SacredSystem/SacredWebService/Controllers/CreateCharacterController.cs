using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SacredWebService.Controllers
{
    public class CreateCharacterController : ApiController
    {
        //public IEnumerable<SSBackgroundsModel> GetAllBackgrounds()
        //{
        //    List<SSBackgroundsModel> theBackgrounds = new List<SSBackgroundsModel>();

        //    string connString = System.Configuration.ConfigurationManager.ConnectionStrings["SacredSystemAlphaConnection"].ConnectionString;
        //    DataSet allBackgrounds = CreateCharacterDL.GetAllBackgrounds(connString);

        //    foreach (DataRow dRow in allBackgrounds.Tables[0].Rows)
        //    {
        //        SSBackgroundsModel tempModel = new SSBackgroundsModel();
        //        tempModel.Id = (int)dRow["id"];
        //        tempModel.Name = dRow["backgroundname"].ToString();
        //        tempModel.Cost = (int)dRow["cost"];
        //        tempModel.Description = dRow["bgdescription"].ToString();
        //        tempModel.Benefit = dRow["benefit"].ToString();

        //        theBackgrounds.Add(tempModel);
        //    }

        //    return theBackgrounds;
        //}
    }
}
