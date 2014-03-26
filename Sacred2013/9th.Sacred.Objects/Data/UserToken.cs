using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Objects.Data
{
    public class UserToken
    {
        public int PrimaryKey { get; set; }
        public int UserId { get; set; }
        public Guid Token { get; set; }
        public DateTime Expiration { get; set; }

        public UserToken()
        {
            InitializeValues();
        }

        //-------------------------------------------------
        public void InitializeValues()
        {
            PrimaryKey = 0;
            UserId = 0;
            Token = Guid.Empty;
            Expiration = DateTime.MinValue;
        }
    }
}
