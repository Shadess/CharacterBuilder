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
    public class PowersData : DataAccessBase
    {
        public PowersData(DataContext context)
            : base(context)
        { }


        #region Sql Strings



        #endregion


        //--------------------------------------------------
        private void LoadParameters(SqlCommand cmd, Power power)
        {
            cmd.Parameters.AddWithValue("@ID", power.Id);
            cmd.Parameters.AddWithValue("@NAME", power.Name);
            cmd.Parameters.AddWithValue("@CATEGORY", power.Category);
            cmd.Parameters.AddWithValue("@POWERTYPE", power.Type);
            cmd.Parameters.AddWithValue("@ACTIONTYPE", power.ActionType);
            cmd.Parameters.AddWithValue("@EFFECTTYPE", power.EffectType);
            cmd.Parameters.AddWithValue("@RANGE", power.Range);
            cmd.Parameters.AddWithValue("@AURARANGE", power.AuraRange);
            cmd.Parameters.AddWithValue("@DESCRIPTION", power.Description);
            cmd.Parameters.AddWithValue("@TIER", power.Tier);
            cmd.Parameters.AddWithValue("@ACTIVE", power.Active);
        }

        public static Power CreateObjectFromDataRow(DataRow row)
        {
            Power power = new Power();

            power.Id = (row["ID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ID"]);
            power.Name = (row["NAME"] == DBNull.Value) ? string.Empty : Convert.ToString(row["NAME"]);
            power.Category = (row["CATEGORY"] == DBNull.Value) ? 0 : (PowerCategory)Convert.ToInt32(row["CATEGORY"]);
            power.Type = (row["POWERTYPE"] == DBNull.Value) ? 0 : (PowerType)Convert.ToInt32(row["POWERTYPE"]);
            power.ActionType = (row["ACTIONTYPE"] == DBNull.Value) ? 0 : (ActionType)Convert.ToInt32(row["ACTIONTYPE"]);
            power.EffectType = (row["EFFECTTYPE"] == DBNull.Value) ? 0 : (EffectType)Convert.ToInt32(row["EFFECTTYPE"]);
            power.Range = (row["RANGE"] == DBNull.Value) ? 0 : Convert.ToInt32(row["RANGE"]);
            power.AuraRange = (row["AURARANGE"] == DBNull.Value) ? 0 : Convert.ToInt32(row["AURARANGE"]);
            power.Description = (row["DESCRIPTION"] == DBNull.Value) ? string.Empty : Convert.ToString(row["DESCRIPTION"]);
            power.Tier = (row["TIER"] == DBNull.Value) ? 0 : Convert.ToInt32(row["TIER"]);
            power.Active = (row["ACTIVE"] == DBNull.Value) ? false : Convert.ToBoolean(row["ACTIVE"]);

            return power;
        }
    }
}
