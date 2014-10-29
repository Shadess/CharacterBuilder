using _9th.Sacred.Objects.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Data
{
    public class RacesData : DataAccessBase
    {
        public RacesData(DataContext context)
            : base(context)
        { }


        #region Sql Strings

        private const string SQL_GET_ALL_RACES = @"
            SELECT * FROM RACES
            SELECT * FROM POWERS p
	            INNER JOIN POWERSMAP pm on pm.POWERID_FK = p.ID
            WHERE ACTIVE = 1 and p.CATEGORY = 1 AND pm.CATEGORY = 1
        ";

        #endregion


        public List<Race> GetAll()
        {
            DataSet data = new DataSet();
            List<Race> races = new List<Race>();

            using (SqlCommand cmd = new SqlCommand(SQL_GET_ALL_RACES))
            {
                data = ExecuteSqlQuery(cmd);
            }

            if (!DataSetIsEmpty(data) && data.Tables.Count == 2 && data.Tables[1].Rows.Count > 0)
            {
                DataTable powerTable = data.Tables[1];

                foreach (DataRow row in data.Tables[0].Rows)
                {
                    Race newRace = RacesData.CreateObjectFromDataRow(row);

                    foreach (DataRow powerRow in powerTable.Select("OBJECTID = " + newRace.Id))
                    {
                        newRace.Powers.Add(PowersData.CreateObjectFromDataRow(powerRow));
                    }

                    races.Add(newRace);
                }
            }

            return races;
        }


        //--------------------------------------------------
        private void LoadParameters(SqlCommand cmd, Race race)
        {
            cmd.Parameters.AddWithValue("@ID", race.Id);
            cmd.Parameters.AddWithValue("@NAME", race.Name);
            cmd.Parameters.AddWithValue("@COMMONNAME", race.CommonName);
            cmd.Parameters.AddWithValue("@LIFESPAN", race.Lifespan);
            cmd.Parameters.AddWithValue("@HEIGHT", race.Height);
            cmd.Parameters.AddWithValue("@ORIGIN", race.Origin);
            cmd.Parameters.AddWithValue("@SOCIALSTATUS", race.SocialStatus);
            cmd.Parameters.AddWithValue("@FLAVORTEXT", race.FlavorText);
            cmd.Parameters.AddWithValue("@DESCRIPTION", race.Description);
        }

        public static Race CreateObjectFromDataRow(DataRow row)
        {
            Race race = new Race();

            race.Id = (row["ID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ID"]);
            race.Name = (row["NAME"] == DBNull.Value) ? string.Empty : Convert.ToString(row["NAME"]);
            race.CommonName = (row["COMMONNAME"] == DBNull.Value) ? string.Empty : Convert.ToString(row["COMMONNAME"]);
            race.Lifespan = (row["LIFESPAN"] == DBNull.Value) ? string.Empty : Convert.ToString(row["LIFESPAN"]);
            race.Height = (row["HEIGHT"] == DBNull.Value) ? string.Empty : Convert.ToString(row["HEIGHT"]);
            race.Origin = (row["ORIGIN"] == DBNull.Value) ? string.Empty : Convert.ToString(row["ORIGIN"]);
            race.SocialStatus = (row["SOCIALSTATUS"] == DBNull.Value) ? string.Empty : Convert.ToString(row["SOCIALSTATUS"]);
            race.FlavorText = (row["FLAVORTEXT"] == DBNull.Value) ? string.Empty : Convert.ToString(row["FLAVORTEXT"]);
            race.Description = (row["DESCRIPTION"] == DBNull.Value) ? string.Empty : Convert.ToString(row["DESCRIPTION"]);

            return race;
        }
    }
}
