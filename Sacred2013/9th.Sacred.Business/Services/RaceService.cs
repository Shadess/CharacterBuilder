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

        public Race AddRace(Race newRace)
        {
            // Add race
            RacesData raceData = new RacesData(CurrentDataContext);
            newRace.Id = raceData.AddRace(newRace);

            RacePowersData powersData = new RacePowersData(CurrentDataContext);
            foreach (RacePower power in newRace.RacePowers)
            {
                power.RaceId = newRace.Id;
                power.Id = powersData.AddPower(power);
            }

            return newRace;
        }

        public Race EditRace(Race race)
        {
            RacesData raceData = new RacesData(CurrentDataContext);
            raceData.UpdateRace(race);

            RacePowersData powersData = new RacePowersData(CurrentDataContext);
            foreach (RacePower power in race.RacePowers)
            {
                if (power.Id == 0)
                {
                    power.RaceId = race.Id;
                    power.Id = powersData.AddPower(power);
                }
                else
                {
                    powersData.UpdatePower(power);
                }
            }

            return race;
        }

        public void DeleteClassById(int id)
        {
            RacesData raceData = new RacesData(CurrentDataContext);
            raceData.DeleteRaceById(id);
        }

        public void RemovePower(int id)
        {
            RacePowersData powersData = new RacePowersData(CurrentDataContext);
            powersData.RemovePower(id);
        }
    }
}
