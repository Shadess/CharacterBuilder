using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using _9th.Sacred.Data;
using _9th.Sacred.Objects.Data;
using _9th.Sacred.Objects.Responses;

namespace _9th.Sacred.Business.Services
{
    public class UserService : BaseService
    {
        public UserService(string connectionstring)
            : base(connectionstring, null)
        { }

        public bool AuthenticateUserToken(string usertoken)
        {
            UserTokensData tokenData = new UserTokensData(CurrentDataContext);
            int id = tokenData.GetUserIdFromToken(usertoken);

            return (id > 0);
        }

        public void RegisterUser(string username, string password, string displayname)
        {
            // TODO - register a user
            // Create our random 256 bit salt
            RNGCryptoServiceProvider rngGod = new System.Security.Cryptography.RNGCryptoServiceProvider();
            byte[] salt = new byte[32];
            rngGod.GetBytes(salt);
        }

        public LoginResponse ValidateUser(string username, string password)
        {
            LoginResponse response = new LoginResponse();
            UsersData data = new UsersData(CurrentDataContext);
            User theUser = data.ReadUserByUsername(username);

            if (theUser != null)
            {
                // PBKDF2 hashing of password and salt
                Rfc2898DeriveBytes dBytes = new System.Security.Cryptography.Rfc2898DeriveBytes(password, theUser.Salt, 200000);
                byte[] pass2Check = dBytes.GetBytes(256);
                
                if (pass2Check.SequenceEqual(theUser.Password))
                {
                    // Create user login token
                    UserToken token = new UserToken();
                    token.UserId = theUser.PrimaryKey;
                    token.Token = new Guid();
                    token.Expiration = DateTime.Now.AddDays(7);

                    response.Success = true;
                    response.UserToken = token.Token;
                    response.AutoLogoutInMinutes = 0;
                }
                else
                {
                    response.Message = ErrorMessages.INVALID_PASSWORD;
                }
            }
            else
            {
                response.Message = ErrorMessages.NO_USER_WITH_PROVIDED_USERNAME;
            }

            return response;
        }

        public User GetUserFromUserToken(string usertoken)
        {
            UserTokensData tokenData = new UserTokensData(CurrentDataContext);
            int id = tokenData.GetUserIdFromToken(usertoken);

            if (id < 1)
            {
                return null;
            }

            return ReadUserByPrimarykey(id);
        }

        public User ReadUserByPrimarykey(int primarykey)
        {
            UsersData data = new UsersData(CurrentDataContext);
            User user = data.ReadUserById(primarykey);

            return user;
        }
    }
}
