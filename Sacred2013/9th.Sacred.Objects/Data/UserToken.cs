using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Objects.Data
{
    public class UserToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Guid Token { get; set; }
        public TokenType TokenType { get; set; }
        public DateTime CreateDate { get; set; }

        public UserToken()
        {
            InitializeValues();
        }

        //-------------------------------------------------
        public void InitializeValues()
        {
            Id = 0;
            UserId = 0;
            Token = Guid.Empty;
            TokenType = Data.TokenType.Login;
            CreateDate = (DateTime)SqlDateTime.MinValue;
        }
    }

    public enum TokenType
    {
        Verify = 0,
        Login = 1
    }
}
