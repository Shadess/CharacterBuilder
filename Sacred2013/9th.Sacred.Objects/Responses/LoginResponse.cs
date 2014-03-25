using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Objects.Responses
{
    public class LoginResponse
    {
        public Guid UserToken { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public int AutoLogoutInMinutes { get; set; }

        public LoginResponse()
        {
            InitializeValues();
        }

        public void InitializeValues()
        {
            Success = false;
            Message = string.Empty;
            AutoLogoutInMinutes = 0;
        }
    }
}
