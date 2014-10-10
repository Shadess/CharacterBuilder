using _9th.Sacred.Objects.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.ApiInterface
{
    public abstract class RaceApiProxy
    {
        public static List<Race> GetAll(string apiUrl, string userToken)
        {
            ApiRequest request = new ApiRequest("Race/GetAll");
            request.Parameters.Add("userToken", userToken);

            ApiProxy proxy = new ApiProxy(apiUrl);
            return proxy.GetResponse<List<Race>>(request);
        }
    }
}
