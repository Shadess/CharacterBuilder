using _9th.Sacred.Data;
using _9th.Sacred.Objects.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Business.Services
{
    public class PowerService : BaseService
    {
        public PowerService(string connectionstring)
            : base(connectionstring, null)
        { }

        public List<Power> GetAll()
        {
            PowersData powerData = new PowersData(CurrentDataContext);
            return powerData.GetAll();
        }
    }
}
