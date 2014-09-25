using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Business
{
    public class ErrorMessages
    {
        // Login error messages
        public const string LOGIN_NO_USER_WITH_PROVIDED_USERNAME = "A user with that username does not exist.";
        public const string LOGIN_INVALID_PASSWORD = "Invalid password.";
        
        // Register error messages
        public const string REGISTER_DUPLICATE_USER_EMAIL = "A user with that e-mail is already registered.";
        public const string REGISTER_GENERAL_ERROR = "There was an error in registration. Please check your input and try again.";
    }
}
