using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SacredDataLayer
{
    public class CreateCharacterDL
    {
        public static DataSet GetAllBackgrounds(string connString)
        {
            DataSet returnSet = new DataSet();

            // Get the backgrounds from the database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM Backgrounds", conn))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(returnSet, "Backgrounds");
                    }
                }
            } // end using SqlConnection

            return returnSet;
        }
    }
}
