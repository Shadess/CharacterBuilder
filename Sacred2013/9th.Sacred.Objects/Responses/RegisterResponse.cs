using _9th.Sacred.Objects.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Objects.Responses
{
    public class RegisterResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public User RegisteredUser { get; set; }
        public UserToken RegisteredToken { get; set; }
        public List<string> Errors { get; set; }

        public RegisterResponse()
        {
            InitializeValues();
        }

        public void InitializeValues()
        {
            Success = false;
            Message = string.Empty;
            RegisteredUser = null;
            Errors = null;
        }
    }
}
