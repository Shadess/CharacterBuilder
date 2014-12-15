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
    public class PowerSpecializationsData : DataAccessBase
    {
        public PowerSpecializationsData(DataContext context)
            : base(context)
        { }


        #region Sql Strings



        #endregion


        //--------------------------------------------------
        private void LoadParameters(SqlCommand cmd, PowerSpecialization specialization)
        {
            cmd.Parameters.AddWithValue("@ID", specialization.Id);
            cmd.Parameters.AddWithValue("@POWERID_FK", specialization.PowerId);
            cmd.Parameters.AddWithValue("@DESCRIPTION", specialization.Description);
        }

        public static PowerSpecialization CreateObjectFromDataRow(DataRow row)
        {
            PowerSpecialization specialization = new PowerSpecialization();

            specialization.Id = (row["ID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ID"]);
            specialization.PowerId = (row["POWERID_FK"] == DBNull.Value) ? 0 : Convert.ToInt32(row["POWERID_FK"]);
            specialization.Description = (row["DESCRIPTION"] == DBNull.Value) ? string.Empty : Convert.ToString(row["DESCRIPTION"]);

            return specialization;
        }
    }
}
