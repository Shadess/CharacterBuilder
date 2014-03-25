using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.ApiInterface
{
    public class ApiRequest
    {
        public string ApiResource { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public object Content { get; set; }

        public ApiRequest(string apiresource)
        {
            ApiResource = apiresource;
            Parameters = new Dictionary<string, object>();
        }
    }
}
