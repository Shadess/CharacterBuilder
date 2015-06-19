using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Objects.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public bool Verified { get; set; }
        public DateTime SignUpDate { get; set; }

        public User()
        {
            InitializeValues();
        }

        //-------------------------------------------------
        public void InitializeValues()
        {
            Id = 0;
            Email = string.Empty;
            Username = string.Empty;
            Password = null;
            Salt = null;
            Verified = false;
            SignUpDate = (DateTime)SqlDateTime.MinValue;
        }

        public User StripSecurity()
        {
            this.Password = null;
            this.Salt = null;

            return this;
        }
    }

    public class InputUser
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public List<string> Errors { get; set; }

        public InputUser()
        {
            InitializeValues();
        }

        //-------------------------------------------------
        public void InitializeValues()
        {
            Email = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
            Errors = null;
        }
    }

    public class CookieUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserToken { get; set; }
    }
}
