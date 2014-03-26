using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9th.Sacred.Data;
using _9th.Sacred.Objects.Data;

namespace _9th.Sacred.Business.Services
{
    public abstract class BaseService
    {
        protected User _currentuser;
        protected string _connectionstring;
        protected string _lasterror;

        public BaseService(string connectionstring, User currentuser)
        {
            _connectionstring = connectionstring;
            _currentuser = currentuser;
        }

        public DataContext CurrentDataContext
        {
            get { return new DataContext(_connectionstring, _currentuser); }
        }
    }
}
