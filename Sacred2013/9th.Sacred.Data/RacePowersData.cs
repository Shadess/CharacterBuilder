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
    public class RacePowersData : DataAccessBase
    {
        public RacePowersData(DataContext context)
            : base(context)
        { }


        #region Sql Strings

        private const string SQL_ADD_RACEPOWER = @"
            INSERT INTO RACEPOWERS
            (RACEID_FK, NAME, DESCRIPTION)
            VALUES
            (@RACEID_FK, @NAME, @DESCRIPTION);
            SELECT CONVERT(int, SCOPE_IDENTITY());
        ";

        private const string SQL_UPDATE_RACEPOWER = @"
            UPDATE RACEPOWERS
            SET NAME = @NAME,
                DESCRIPTION = @DESCRIPTION
            WHERE ID = @ID
        ";

        private const string SQL_DELETE_RACEPOWER = @"DELETE FROM RACEPOWERS WHERE ID = @ID";

        #endregion


        public int AddPower(RacePower newPower)
        {
            int id = 0;

            using (SqlCommand cmd = new SqlCommand(SQL_ADD_RACEPOWER))
            {
                LoadParameters(cmd, newPower);
                id = (int)ExecuteScalarQuery(cmd);
            }

            return id;
        }

        public void UpdatePower(RacePower power)
        {
            using (SqlCommand cmd = new SqlCommand(SQL_UPDATE_RACEPOWER))
            {
                LoadParameters(cmd, power);
                ExecuteSqlNonQuery(cmd);
            }
        }

        public void RemovePower(int id)
        {
            using (SqlCommand cmd = new SqlCommand(SQL_DELETE_RACEPOWER))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                ExecuteSqlNonQuery(cmd);
            }
        }


        //--------------------------------------------------
        private void LoadParameters(SqlCommand cmd, RacePower power)
        {
            cmd.Parameters.AddWithValue("@ID", power.Id);
            cmd.Parameters.AddWithValue("@RACEID_FK", power.RaceId);
            cmd.Parameters.AddWithValue("@NAME", power.Name);
            cmd.Parameters.AddWithValue("@DESCRIPTION", power.Description);
        }

        public static RacePower CreateObjectFromDataRow(DataRow row)
        {
            RacePower power = new RacePower();

            power.Id = (row["ID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ID"]);
            power.RaceId = (row["RACEID_FK"] == DBNull.Value) ? 0 : Convert.ToInt32(row["RACEID_FK"]);
            power.Name = (row["NAME"] == DBNull.Value) ? string.Empty : Convert.ToString(row["NAME"]);
            power.Description = (row["DESCRIPTION"] == DBNull.Value) ? string.Empty : Convert.ToString(row["DESCRIPTION"]);

            return power;
        }
    }
}
