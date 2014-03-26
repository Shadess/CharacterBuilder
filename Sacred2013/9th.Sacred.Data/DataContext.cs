using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9th.Sacred.Objects.Data;

namespace _9th.Sacred.Data
{
    public class DataContext
    {
        public User CurrentUser { get; set; }
        public string ConnectionString { get; set; }

        public DataContext(string connectionstring, User currentuser)
        {
            ConnectionString = connectionstring;
            CurrentUser = currentuser;
        }
    }
}
