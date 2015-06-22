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
        ";
        //SELECT * FROM POWERS p
        //        INNER JOIN POWERSMAP pm on pm.POWERID_FK = p.ID
        //    WHERE ACTIVE = 1 and p.CATEGORY = 1 AND pm.CATEGORY = 1

        private const string SQL_ADD_RACE = @"
            INSERT INTO RACES
            (NAME, COMMONNAME, LIFESPAN, HEIGHT, ORIGIN, SOCIALSTATUS, FLAVORTEXT, DESCRIPTION)
            VALUES
            (@NAME, @COMMONNAME, @LIFESPAN, @HEIGHT, @ORIGIN, @SOCIALSTATUS, @FLAVORTEXT, @DESCRIPTION);
            SELECT CONVERT(int, SCOPE_IDENTITY());
        ";

        private const string SQL_UPDATE_RACE = @"
            UPDATE RACES
            SET NAME = @NAME,
                COMMONNAME = @COMMONNAME,
                LIFESPAN = @LIFESPAN,
                HEIGHT = @HEIGHT,
                ORIGIN = @ORIGIN,
                SOCIALSTATUS = @SOCIALSTATUS,
                FLAVORTEXT = @FLAVORTEXT,
                DESCRIPTION = @DESCRIPTION
            WHERE ID = @ID
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

            //if (!DataSetIsEmpty(data) && data.Tables.Count == 2 && data.Tables[1].Rows.Count > 0)
            if (!DataSetIsEmpty(data))
            {
                //DataTable powerTable = data.Tables[1];

                foreach (DataRow row in data.Tables[0].Rows)
                {
                    Race newRace = RacesData.CreateObjectFromDataRow(row);

                    //foreach (DataRow powerRow in powerTable.Select("OBJECTID = " + newRace.Id))
                    //{
                    //    newRace.Powers.Add(PowersData.CreateObjectFromDataRow(powerRow));
                    //}

                    races.Add(newRace);
                }
            }

            return races;
        }

        public int AddRace(Race newRace)
        {
            int id = 0;

            using (SqlCommand cmd = new SqlCommand(SQL_ADD_RACE))
            {
                LoadParameters(cmd, newRace);
                id = (int)ExecuteScalarQuery(cmd);
            }

            return id;
        }

        public void UpdateRace(Race race)
        {
            using (SqlCommand cmd = new SqlCommand(SQL_UPDATE_RACE))
            {
                LoadParameters(cmd, race);
                ExecuteSqlNonQuery(cmd);
            }
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
