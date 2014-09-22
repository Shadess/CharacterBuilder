using System;
using System.Collections.Generic;
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
            SignUpDate = DateTime.MinValue;
        }
    }

    public class RegisterUser
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public RegisterUser()
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
        }
    }
}
