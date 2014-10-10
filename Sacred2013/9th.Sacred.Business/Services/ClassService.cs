using _9th.Sacred.Data;
using _9th.Sacred.Objects.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Business.Services
{
    public class ClassService : BaseService
    {
        public ClassService(string connectionstring)
            : base(connectionstring, null)
        { }

        public List<Class> GetAll()
        {
            ClassesData cData = new ClassesData(CurrentDataContext);
            return cData.GetAll();
        }
    }
}
