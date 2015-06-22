using _9th.Sacred.Data;
using _9th.Sacred.Objects.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Business.Services
{
    public class RaceService : BaseService
    {
        public RaceService(string connectionstring)
            : base(connectionstring, null)
        { }

        public List<Race> GetAll()
        {
            List<Race> races = new List<Race>();

            RacesData rData = new RacesData(CurrentDataContext);
            races = rData.GetAll();

            return races;
        }

        public int AddRace(Race newRace)
        {
            RacesData raceData = new RacesData(CurrentDataContext);
            return raceData.AddRace(newRace);
        }

        public void EditRace(Race race)
        {
            RacesData raceData = new RacesData(CurrentDataContext);
            raceData.UpdateRace(race);
        }
    }
}
