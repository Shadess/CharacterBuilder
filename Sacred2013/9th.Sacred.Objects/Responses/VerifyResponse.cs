using _9th.Sacred.Objects.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Objects.Responses
{
    public class VerifyResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public User User { get; set; }

        public VerifyResponse()
        {
            InitializeValues();
        }

        public void InitializeValues()
        {
            Success = false;
            Message = string.Empty;
            User = null;
        }
    }
}
