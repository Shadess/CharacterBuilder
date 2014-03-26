using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Data
{
    public abstract class DataAccessBase
    {
        protected DataContext _datacontext;
        
        public DataAccessBase(DataContext context)
        {
            _datacontext = context;
        }

        protected DataSet ExecuteSqlQuery(string sql)
        {
            return ExecuteSqlQuery(new SqlCommand(sql));
        }

        protected DataSet ExecuteSqlQuery(SqlCommand command)
        {
            DataSet returndata = new DataSet();

            using (SqlConnection connection = new SqlConnection(_datacontext.ConnectionString))
            {
                connection.Open();
                command.Connection = connection;

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(returndata);
                }
            }

            return returndata;
        }

        protected void ExecuteSqlNonQuery(string sql)
        {
            ExecuteSqlNonQuery(new SqlCommand(sql));
        }

        protected void ExecuteSqlNonQuery(SqlCommand command)
        {
            using (SqlConnection connection = new SqlConnection(_datacontext.ConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }

        protected object ExecuteScalarQuery(SqlCommand command)
        {
            object returnval = null;

            using (SqlConnection connection = new SqlConnection(_datacontext.ConnectionString))
            {
                connection.Open();
                command.Connection = connection;

                returnval = command.ExecuteScalar();
            }

            return returnval;
        }

        protected bool DataSetIsEmpty(DataSet data)
        {
            if (data == null || data.Tables.Count < 1 || data.Tables[0].Rows.Count < 1)
            {
                return true;
            }

            return false;
        }
    }
}
