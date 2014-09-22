﻿using System;
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

        private const string SQL_CREATE_USER = @"
            INSERT INTO USERS
            (EMAIL, USERNAME, PASSWORD, SALT, VERIFIED, SIGNUPDATE)
            VALUES
            (@EMAIL, @USERNAME, @PASSWORD, @SALT, @VERIFIED, @SIGNUPDATE);
            SELECT CONVERT(int, SCOPE_IDENTITY());
        ";

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

        public int CreateUser(User newUser)
        {
            int id = 0;

            using (SqlCommand cmd = new SqlCommand(SQL_CREATE_USER))
            {
                LoadParameters(cmd, newUser);
                id = (int)ExecuteScalarQuery(cmd);
            }

            return id;
        }

        //--------------------------------------------------
        private void LoadParameters(SqlCommand cmd, User user)
        {
            cmd.Parameters.AddWithValue("@ID", user.Id);
            cmd.Parameters.AddWithValue("@EMAIL", user.Email);
            cmd.Parameters.AddWithValue("@USERNAME", user.Username);
            cmd.Parameters.AddWithValue("@PASSWORD", user.Password);
            cmd.Parameters.AddWithValue("@SALT", user.Salt);
            cmd.Parameters.AddWithValue("@VERIFIED", user.Verified);
            cmd.Parameters.AddWithValue("@SIGNUPDATE", user.SignUpDate);
        }

        public static User CreateObjectFromDataRow(DataRow row)
        {
            User newUser = new User();

            newUser.Id = (row["ID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Id"]);
            newUser.Email = (row["EMAIL"] == DBNull.Value) ? string.Empty : Convert.ToString(row["EMAIL"]);
            newUser.Username = (row["USERNAME"] == DBNull.Value) ? string.Empty : Convert.ToString(row["USERNAME"]);
            newUser.Password = (row["PASSWORD"] == DBNull.Value) ? null : (byte[])row["PASSWORD"];
            newUser.Salt = (row["SALT"] == DBNull.Value) ? null : (byte[])row["SALT"];
            newUser.Verified = (row["VERIFIED"] == DBNull.Value) ? false : Convert.ToBoolean(row["VERIFIED"]);
            newUser.SignUpDate = (row["SIGNUPDATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["SIGNUPDATE"]);

            return newUser;
        }
    }
}
