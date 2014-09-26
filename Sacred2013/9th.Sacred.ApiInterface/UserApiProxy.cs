using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _9th.Sacred.Objects.Responses;
using _9th.Sacred.Objects.Data;

namespace _9th.Sacred.ApiInterface
{
    public abstract class UserApiProxy
    {
        public static LoginResponse ValidateUser(string apiUrl, string email, string password)
        {
            ApiRequest request = new ApiRequest("User/ValidateUser");
            request.Parameters.Add("email", email);
            request.Parameters.Add("password", password);

            ApiProxy proxy = new ApiProxy(apiUrl);
            return proxy.GetResponse<LoginResponse>(request);
        }

        public static void LogoutUser(string apiUrl, int userId)
        {
            ApiRequest request = new ApiRequest("User/LogoutUser");
            request.Parameters.Add("userId", userId);

            ApiProxy proxy = new ApiProxy(apiUrl);
            proxy.GetResponseString(request);
        }

        public static RegisterResponse RegisterUser(string apiUrl, InputUser newUser)
        {
            ApiRequest request = new ApiRequest("User/RegisterUser");
            request.Content = newUser;

            ApiProxy proxy = new ApiProxy(apiUrl);
            return proxy.PostRequest<RegisterResponse>(request);
        }

        public static VerifyResponse VerifyUserRegistration(string apiUrl, int id, string token)
        {
            ApiRequest request = new ApiRequest("User/VerifyUserRegistration");
            request.Parameters.Add("id", id);
            request.Parameters.Add("token", token);

            ApiProxy proxy = new ApiProxy(apiUrl);
            return proxy.GetResponse<VerifyResponse>(request);
        }

        public static User GetUserById(string apiUrl, string userToken, int userId)
        {
            ApiRequest request = new ApiRequest("User/GetUserById");
            request.Parameters.Add("userToken", userToken);
            request.Parameters.Add("userId", userId);

            ApiProxy proxy = new ApiProxy(apiUrl);
            return proxy.GetResponse<User>(request);
        }
    }
}
