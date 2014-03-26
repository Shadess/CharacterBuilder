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
    public class UserTokensData : DataAccessBase
    {
        private const string SQL_GET_USERID_FROM_TOKEN = @"Select UserId from UserTokens where Token = @Token and Expiration > GETDATE()";
        private const string SQL_INSERT_NEW_TOKEN = @"Insert into UserTokens (UserId, Token, Expiration) Values (@UserId, @Token, @Expiration)";

        public UserTokensData(DataContext context)
            : base(context)
        { }

        public int GetUserIdFromToken(string token)
        {
            using (SqlCommand cmd = new SqlCommand(SQL_GET_USERID_FROM_TOKEN))
            {
                cmd.Parameters.AddWithValue("@Token", token);

                object theVal = ExecuteScalarQuery(cmd);
                
                if (theVal == null || theVal == DBNull.Value)
                {
                    return -1;
                }

                return (int)theVal;
            }
        }

        public int CreateTokenForUser(UserToken token)
        {
            SqlParameter primaryKey = new SqlParameter("@PrimaryKey", SqlDbType.Int);
            primaryKey.Direction = ParameterDirection.Output;

            using (SqlCommand cmd = new SqlCommand(SQL_INSERT_NEW_TOKEN))
            {
                cmd.Parameters.AddWithValue("@UserId", token.UserId);
                cmd.Parameters.AddWithValue("@Token", token.Token);
                cmd.Parameters.AddWithValue("@Expiration", token.Expiration);

                cmd.Parameters.Add(primaryKey);

                ExecuteSqlNonQuery(cmd);
            }

            return (int)primaryKey.Value;
        }

        //--------------------------------------------------
        public static UserToken CreateObjectFromDataRow(DataRow row)
        {
            UserToken token = new UserToken();

            token.PrimaryKey = row["Id"] == DBNull.Value ? 0 : Convert.ToInt32(row["Id"]);
            token.UserId = row["UserId"] == DBNull.Value ? 0 : Convert.ToInt32(row["UserId"]);
            token.Token = row["Token"] == DBNull.Value ? Guid.Empty : new Guid(row["Token"].ToString());
            token.Expiration = row["Expiration"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["Expiration"]);

            return token;
        }
    }
}
