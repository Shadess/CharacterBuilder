using _9th.Sacred.Data;
using _9th.Sacred.Objects.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Business.Services
{
    public class HeroicService : BaseService
    {
        public HeroicService(string connectionstring)
            : base(connectionstring, null)
        { }

        public List<HeroicAwakening> GetAll()
        {
            HeroicAwakeningsData data = new HeroicAwakeningsData(CurrentDataContext);
            return data.GetAll();
        }
    }
}
