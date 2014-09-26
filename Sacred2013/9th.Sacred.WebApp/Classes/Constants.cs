using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _9th.Sacred.WebApp.Classes
{
    public class Constants
    {
        /// <summary>
        /// Error messages
        /// </summary>
        public const string _GENERIC_LOGIN_ERROR_ = "The username or password is invalid.";

        /// <summary>
        /// Session variable names
        /// </summary>
        public const string _USER_ID_ = "$_userid_$";
        public const string _USER_TOKEN_ = "$_usertoken_$";

        /// <summary>
        /// Cookie variable names
        /// </summary>
        public const string _COOKIE_NAME_ = "SacredCookie";
        public const string _COOKIE_USER_ID_ = "UserId";
        public const string _COOKIE_USER_TOKEN_ = "UserToken";
        public const string _COOKIE_USER_NAME_ = "UserName";
    }
}