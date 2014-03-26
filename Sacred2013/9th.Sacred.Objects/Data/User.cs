using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Objects.Data
{
    public class User
    {
        public int PrimaryKey { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public string DisplayName { get; set; }

        public User()
        {
            InitializeValues();
        }

        //-------------------------------------------------
        public void InitializeValues()
        {
            PrimaryKey = 0;
            UserName = string.Empty;
            Password = null;
            Salt = null;
            DisplayName = string.Empty;
        }
    }
}
