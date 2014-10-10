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
    public class RacialPowersData : DataAccessBase
    {
        public RacialPowersData(DataContext context)
            : base(context)
        { }


        #region Sql Strings
        #endregion


        //--------------------------------------------------
        private void LoadParameters(SqlCommand cmd, RacialPower power)
        {
            cmd.Parameters.AddWithValue("@ID", power.Id);
            cmd.Parameters.AddWithValue("@NAME", power.Name);
            cmd.Parameters.AddWithValue("@TYPE", power.Type);
            cmd.Parameters.AddWithValue("@ACTIONTYPE", power.ActionType);
            cmd.Parameters.AddWithValue("@EFFECTTYPE", power.EffectType);
            cmd.Parameters.AddWithValue("@RANGE", power.Range);
            cmd.Parameters.AddWithValue("@AURARANGE", power.AuraRange);
            cmd.Parameters.AddWithValue("@DESCRIPTION", power.Description);
        }

        public static RacialPower CreateObjectFromDataRow(DataRow row)
        {
            RacialPower power = new RacialPower();

            power.Id = (row["ID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ID"]);
            power.Name = (row["NAME"] == DBNull.Value) ? string.Empty : Convert.ToString(row["NAME"]);
            power.Type = (row["TYPE"] == DBNull.Value) ? 0 : (PowerType)Convert.ToInt32(row["TYPE"]);
            power.ActionType = (row["ACTIONTYPE"] == DBNull.Value) ? 0 : (ActionType)Convert.ToInt32(row["ACTIONTYPE"]);
            power.EffectType = (row["EFFECTTYPE"] == DBNull.Value) ? 0 : (EffectType)Convert.ToInt32(row["EFFECTTYPE"]);
            power.Range = (row["RANGE"] == DBNull.Value) ? 0 : Convert.ToInt32(row["RANGE"]);
            power.AuraRange = (row["AURARANGE"] == DBNull.Value) ? 0 : Convert.ToInt32(row["AURARANGE"]);
            power.Description = (row["DESCRIPTION"] == DBNull.Value) ? string.Empty : Convert.ToString(row["DESCRIPTION"]);

            return power;
        }
    }
}
