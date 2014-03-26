using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9th.Sacred.Objects.Data;

namespace _9th.Sacred.Data
{
    public class UsersData : DataAccessBase
    {
        private const string SQL_READ_USER_BY_ID = @"Select * from Users where Id = @Id";
        private const string SQL_READ_USER_BY_USERNAME = @"Select * from Users where Username = @Username";

        public UsersData(DataContext context)
            : base(context)
        { }

        public User ReadUserById(int id)
        {
            DataSet data = null;

            using (SqlCommand cmd = new SqlCommand(SQL_READ_USER_BY_ID))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                data = ExecuteSqlQuery(cmd);
            }

            if (DataSetIsEmpty(data))
            {
                return null;
            }

            return CreateObjectFromDataRow(data.Tables[0].Rows[0]);
        }

        public User ReadUserByUsername(string username)
        {
            DataSet data = null;

            using (SqlCommand cmd = new SqlCommand(SQL_READ_USER_BY_USERNAME))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                data = ExecuteSqlQuery(cmd);
            }

            if (DataSetIsEmpty(data))
            {
                return null;
            }

            return CreateObjectFromDataRow(data.Tables[0].Rows[0]);
        }

        //--------------------------------------------------
        public static User CreateObjectFromDataRow(DataRow row)
        {
            User newUser = new User();

            newUser.PrimaryKey = row["Id"] == DBNull.Value ? 0 : Convert.ToInt32(row["Id"]);
            newUser.UserName = row["Username"] == DBNull.Value ? string.Empty : Convert.ToString(row["Username"]);
            newUser.Password = row["Password"] == DBNull.Value ? null : (byte[])row["Password"];
            newUser.Salt = row["Salt"] == DBNull.Value ? null : (byte[])row["Salt"];
            newUser.DisplayName = row["DisplayName"] == DBNull.Value ? string.Empty : Convert.ToString(row["DisplayName"]);

            return newUser;
        }
    }
}
