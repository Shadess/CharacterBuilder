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
        private const string SQL_GET_USERID_FROM_TOKEN = @"Select USERID_FK from UserTokens where TOKEN = @TOKEN and TOKENTYPE = @TOKENTYPE and CREATEDATE > @DATECUTOFF";

        private const string SQL_INSERT_NEW_TOKEN = @"
            Insert into UserTokens (USERID_FK, TOKEN, TOKENTYPE, CREATEDATE) Values (@USERID_FK, @TOKEN, @TOKENTYPE, @CREATEDATE);
            SELECT CONVERT(int, SCOPE_IDENTITY());
        ";
        private const string SQL_VERIFY_TOKEN_FOR_REGISTRATION = @"
            SELECT * FROM UserTokens
            WHERE USERID_FK = @USERID_FK
                AND TOKEN = @TOKEN
                AND TOKENTYPE = @TOKENTYPE
        ";

        private const string SQL_DELETE_TOKEN_BY_ID = @"
            DELETE FROM UserTokens WHERE ID = @ID
        ";

        private const string SQL_DELETE_ALL_TOKENS_BY_USER_ID = @"
            DELETE FROM UserTokens WHERE USERID_FK = @USERID_FK AND TOKENTYPE = @TOKENTYPE
        ";

        public UserTokensData(DataContext context)
            : base(context)
        { }

        public int GetUserIdFromToken(string token)
        {
            using (SqlCommand cmd = new SqlCommand(SQL_GET_USERID_FROM_TOKEN))
            {
                cmd.Parameters.AddWithValue("@TOKEN", token);
                cmd.Parameters.AddWithValue("@TOKENTYPE", TokenType.Login);
                cmd.Parameters.AddWithValue("@DATECUTOFF", DateTime.Now.AddDays(-3).ToString());

                object theVal = ExecuteScalarQuery(cmd);
                
                if (theVal == null || theVal == DBNull.Value)
                {
                    return -1;
                }

                return (int)theVal;
            }
        }

        public int CreateToken(UserToken token)
        {
            int tokenId = 0;

            using (SqlCommand cmd = new SqlCommand(SQL_INSERT_NEW_TOKEN))
            {
                LoadParameters(cmd, token);
                //ExecuteSqlNonQuery(cmd);
                tokenId = (int)ExecuteScalarQuery(cmd);
            }

            return tokenId;
        }

        public UserToken ReadTokenForRegistration(UserToken token)
        {
            DataSet data = null;

            using (SqlCommand cmd = new SqlCommand(SQL_VERIFY_TOKEN_FOR_REGISTRATION))
            {
                LoadParameters(cmd, token);
                data = ExecuteSqlQuery(cmd);
            }

            if (DataSetIsEmpty(data))
            {
                return null;
            }

            return CreateObjectFromDataRow(data.Tables[0].Rows[0]);
        }

        public void DeleteTokenById(int id)
        {
            using (SqlCommand cmd = new SqlCommand(SQL_DELETE_TOKEN_BY_ID))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                ExecuteSqlNonQuery(cmd);
            }
        }

        public void DeleteAllTokensByUserId(int userId, TokenType tokenType)
        {
            using (SqlCommand cmd = new SqlCommand(SQL_DELETE_ALL_TOKENS_BY_USER_ID))
            {
                cmd.Parameters.AddWithValue("@USERID_FK", userId);
                cmd.Parameters.AddWithValue("@TOKENTYPE", tokenType);
                ExecuteSqlNonQuery(cmd);
            }
        }


        //--------------------------------------------------
        private void LoadParameters(SqlCommand cmd, UserToken token)
        {
            cmd.Parameters.AddWithValue("@ID", token.Id);
            cmd.Parameters.AddWithValue("@USERID_FK", token.UserId);
            cmd.Parameters.AddWithValue("@TOKEN", token.Token.ToString());
            cmd.Parameters.AddWithValue("@TOKENTYPE", token.TokenType);
            cmd.Parameters.AddWithValue("@CREATEDATE", token.CreateDate);
        }

        public static UserToken CreateObjectFromDataRow(DataRow row)
        {
            UserToken token = new UserToken();

            token.Id = row["ID"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID"]);
            token.UserId = row["USERID_FK"] == DBNull.Value ? 0 : Convert.ToInt32(row["USERID_FK"]);
            token.Token = row["TOKEN"] == DBNull.Value ? Guid.Empty : new Guid(row["TOKEN"].ToString());
            token.TokenType = row["TOKENTYPE"] == DBNull.Value ? TokenType.Login : (TokenType)Convert.ToInt32(row["TOKENTYPE"]);
            token.CreateDate = row["CREATEDATE"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["CREATEDATE"]);

            return token;
        }
    }
}
