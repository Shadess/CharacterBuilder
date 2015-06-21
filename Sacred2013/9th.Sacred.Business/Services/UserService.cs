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

        public LoginResponse ValidateUser(string email, string password)
        {
            LoginResponse response = new LoginResponse();
            UsersData data = new UsersData(CurrentDataContext);
            User theUser = data.ReadUserByEmail(email);

            if (theUser != null)
            {
                // PBKDF2 hashing of password and salt
                Rfc2898DeriveBytes dBytes = new System.Security.Cryptography.Rfc2898DeriveBytes(password, theUser.Salt, NumKeyIterations);
                byte[] pass2Check = dBytes.GetBytes(256);
                
                if (pass2Check.SequenceEqual(theUser.Password))
                {
                    // Create user login token
                    UserToken token = new UserToken();
                    token.UserId = theUser.Id;
                    token.Token = Guid.NewGuid();
                    token.TokenType = TokenType.Login;
                    token.CreateDate = DateTime.Now;

                    UserTokensData tokenData = new UserTokensData(CurrentDataContext);
                    token.Id = tokenData.CreateToken(token);

                    response.Success = true;
                    response.UserToken = token.Token;
                    response.AutoLogoutInMinutes = 0;
                    response.User = theUser.StripSecurity();
                }
                else
                {
                    response.Message = ErrorMessages.LOGIN_INVALID_PASSWORD;
                }
            }
            else
            {
                response.Message = ErrorMessages.LOGIN_NO_USER_WITH_PROVIDED_USERNAME;
            }

            return response;
        }

        public void LogoutUser(int userId)
        {
            UserTokensData tData = new UserTokensData(CurrentDataContext);
            tData.DeleteAllTokensByUserId(userId, TokenType.Login);
        }

        public RegisterResponse RegisterUser(InputUser regUser)
        {
            RegisterResponse response = new RegisterResponse();
            response.Errors = new List<string>();

            try
            {
                UsersData data = new UsersData(CurrentDataContext);

                if (data.UserExists(regUser.Email))
                {
                    response.Success = false;
                    response.Message = ErrorMessages.REGISTER_DUPLICATE_USER_EMAIL;
                    response.Errors.Add(ErrorMessages.REGISTER_DUPLICATE_USER_EMAIL);
                }
                else
                {
                    // Create our random 256 bit salt
                    RNGCryptoServiceProvider rngGod = new System.Security.Cryptography.RNGCryptoServiceProvider();
                    byte[] salt = new byte[32];
                    rngGod.GetBytes(salt);

                    // Prepare our password
                    Rfc2898DeriveBytes dBytes = new System.Security.Cryptography.Rfc2898DeriveBytes(regUser.Password, salt, NumKeyIterations);

                    User newUser = new User();
                    newUser.Email = regUser.Email;
                    newUser.Username = regUser.UserName;
                    newUser.Password = dBytes.GetBytes(256);
                    newUser.Salt = salt;
                    newUser.Verified = false;
                    newUser.SignUpDate = DateTime.Now;

                    // Create our user
                    newUser.Id = data.CreateUser(newUser);


                    // Create registration verification token
                    UserToken token = new UserToken();
                    token.UserId = newUser.Id;
                    token.Token = Guid.NewGuid();
                    token.TokenType = TokenType.Verify;
                    token.CreateDate = DateTime.Now;

                    UserTokensData tokenData = new UserTokensData(CurrentDataContext);
                    token.Id = tokenData.CreateToken(token);


                    // Send back our response
                    response.Success = true;
                    response.Message = newUser.Email;
                    response.RegisteredUser = newUser;
                    response.RegisteredToken = token;
                }
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                response.Errors.Add(ErrorMessages.REGISTER_GENERAL_ERROR);
            }

            return response;
        }

        public VerifyResponse VerifyUserRegistration(int id, string token)
        {
            VerifyResponse response = new VerifyResponse();

            UserToken token2Verify = new UserToken();
            token2Verify.UserId = id;
            token2Verify.Token = new Guid(token);
            token2Verify.TokenType = TokenType.Verify;

            UserTokensData tokenData = new UserTokensData(CurrentDataContext);
            UserToken returnToken = tokenData.ReadTokenForRegistration(token2Verify);

            if (returnToken != null)
            {
                // Update user to be verified
                UsersData uData = new UsersData(CurrentDataContext);
                User theUser = uData.ReadUserById(id);
                theUser.Verified = true;
                uData.UpdateUser(theUser);

                // Delete the registration token
                tokenData.DeleteTokenById(returnToken.Id);

                response.Success = true;
                response.User = theUser.StripSecurity();
            }

            return response;
        }

        public User ReadUserById(int userId)
        {
            UsersData data = new UsersData(CurrentDataContext);
            User user = data.ReadUserById(userId);

            if (user != null)
            {
                return user.StripSecurity();
            }
            else
            {
                return user;
            }
        }

        public User ReadUserByToken(string usertoken)
        {
            UserTokensData tokenData = new UserTokensData(CurrentDataContext);
            int id = tokenData.GetUserIdFromToken(usertoken);

            if (id < 1)
            {
                return null;
            }

            return ReadUserById(id);
        }

        public bool ValidateUserAdmin(string userToken)
        {
            bool userTokenIsAdmin = false;

            UserTokensData tokenData = new UserTokensData(CurrentDataContext);
            int id = tokenData.GetUserIdFromToken(userToken);

            if (id > 0)
            {
                // User exists now check admin privileges
                UsersData usersData = new UsersData(CurrentDataContext);
                User user = usersData.ReadUserById(id);
                userTokenIsAdmin = user.IsAdmin;
            }

            return userTokenIsAdmin;
        }
    }
}
