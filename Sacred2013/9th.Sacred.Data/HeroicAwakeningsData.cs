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
    public class HeroicAwakeningsData : DataAccessBase
    {
        public HeroicAwakeningsData(DataContext context)
            : base(context)
        { }


        #region Sql Strings

        private const string SQL_GET_ALL_HEROICS = @"
            SELECT * FROM HEROICAWAKENINGS
            SELECT * FROM POWERS P
	            INNER JOIN POWERSMAP pm on pm.POWERID_FK = p.ID
            WHERE ACTIVE = 1 AND p.CATEGORY = 3 AND pm.CATEGORY = 3
            ORDER BY TIER, NAME
            SELECT ps.* FROM POWERSPECIALIZATIONS ps
	            INNER JOIN POWERS p on p.ID = ps.POWERID_FK
	            INNER JOIN POWERSMAP pm on pm.POWERID_FK = p.ID
            WHERE p.ACTIVE = 1 AND p.CATEGORY = 3 AND pm.CATEGORY = 3
        ";

        #endregion


        public List<HeroicAwakening> GetAll()
        {
            DataSet data = new DataSet();
            List<HeroicAwakening> heroics = new List<HeroicAwakening>();

            using (SqlCommand cmd = new SqlCommand(SQL_GET_ALL_HEROICS))
            {
                data = ExecuteSqlQuery(cmd);
            }

            if (!DataSetIsEmpty(data) && data.Tables.Count > 1 && data.Tables[1].Rows.Count > 0)
            {
            }

            return heroics;
        }
    }
}
