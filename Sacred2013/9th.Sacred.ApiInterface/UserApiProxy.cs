using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _9th.Sacred.Objects.Responses;

namespace _9th.Sacred.ApiInterface
{
    public abstract class UserApiProxy
    {
        public static LoginResponse ValidateLogin(string apiUrl, string username, string password)
        {
            ApiRequest request = new ApiRequest("user/validatelogin");
            request.Parameters.Add("username", username);
            request.Parameters.Add("password", password);

            ApiProxy proxy = new ApiProxy(apiUrl);

            LoginResponse response = proxy.GetResponse<LoginResponse>(request);
            return response;
        }
    }
}
