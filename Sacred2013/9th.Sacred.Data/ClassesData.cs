﻿using _9th.Sacred.Objects.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Data
{
    public class ClassesData : DataAccessBase
    {
        public ClassesData(DataContext context)
            : base(context)
        { }


        #region Sql Strings

        private const string SQL_GET_ALL_CLASSES = @"
            SELECT * FROM CLASSES
        ";
        //SELECT * FROM POWERS P
        //    INNER JOIN POWERSMAP pm on pm.POWERID_FK = p.ID
        //WHERE ACTIVE = 1 AND p.CATEGORY = 2 AND pm.CATEGORY = 2
        //ORDER BY TIER, NAME
        //SELECT ps.* FROM POWERSPECIALIZATIONS ps
        //    INNER JOIN POWERS p on p.ID = ps.POWERID_FK
        //    INNER JOIN POWERSMAP pm on pm.POWERID_FK = p.ID
        //WHERE p.ACTIVE = 1 AND p.CATEGORY = 2 AND pm.CATEGORY = 2

        private const string SQL_ADD_CLASS = @"
            INSERT INTO CLASSES
            (NAME, ROLE, FLAVORTEXT, DESCRIPTION)
            VALUES
            (@NAME, @ROLE, @FLAVORTEXT, @DESCRIPTION);
            SELECT CONVERT(int, SCOPE_IDENTITY());
        ";

        private const string SQL_UPDATE_CLASS = @"
            UPDATE CLASSES
            SET NAME = @NAME,
                ROLE = @ROLE,
                FLAVORTEXT = @FLAVORTEXT,
                DESCRIPTION = @DESCRIPTION
            WHERE ID = @ID
        ";

        private const string SQL_DELETE_CLASS = @"DELETE FROM CLASSES WHERE ID = @ID";

        #endregion


        public List<Class> GetAll()
        {
            DataSet data = new DataSet();
            List<Class> classes = new List<Class>();

            using (SqlCommand cmd = new SqlCommand(SQL_GET_ALL_CLASSES))
            {
                data = ExecuteSqlQuery(cmd);
            }

            if (!DataSetIsEmpty(data))
            {
                foreach (DataRow row in data.Tables[0].Rows)
                {
                    Class newClass = ClassesData.CreateObjectFromDataRow(row);
                    classes.Add(newClass);
                }
            }

            //if (!DataSetIsEmpty(data) && data.Tables.Count > 1 && data.Tables[1].Rows.Count > 0)
            //{
            //    DataTable powerTable = data.Tables[1];
            //    DataTable specializationsTable = null;
            //    if (data.Tables.Count > 2 && data.Tables[2].Rows.Count > 0)
            //    {
            //        specializationsTable = data.Tables[2];
            //    }

            //    foreach (DataRow row in data.Tables[0].Rows)
            //    {
            //        Class newClass = ClassesData.CreateObjectFromDataRow(row);

            //        foreach (DataRow powerRow in powerTable.Select("OBJECTID = " + newClass.Id))
            //        {
            //            Power newPower = PowersData.CreateObjectFromDataRow(powerRow);
            //            if (specializationsTable != null)
            //            {
            //                foreach (DataRow specialRow in specializationsTable.Select("POWERID_FK = " + newPower.Id))
            //                {
            //                    newPower.Specializations.Add(PowerSpecializationsData.CreateObjectFromDataRow(specialRow));
            //                }
            //            }

            //            newClass.Powers.Add(newPower);
            //        }

            //        classes.Add(newClass);
            //    }
            //}

            return classes;
        }

        public int AddClass(Class newClass)
        {
            int id = 0;

            using (SqlCommand cmd = new SqlCommand(SQL_ADD_CLASS))
            {
                LoadParameters(cmd, newClass);
                id = (int)ExecuteScalarQuery(cmd);
            }

            return id;
        }

        public void UpdateClass(Class editClass)
        {
            using (SqlCommand cmd = new SqlCommand(SQL_UPDATE_CLASS))
            {
                LoadParameters(cmd, editClass);
                ExecuteSqlNonQuery(cmd);
            }
        }

        public void DeleteClass(int id)
        {
            using (SqlCommand command = new SqlCommand(SQL_DELETE_CLASS))
            {
                command.Parameters.AddWithValue("@ID", id);
                ExecuteSqlNonQuery(command);
            }
        }


        //--------------------------------------------------
        private void LoadParameters(SqlCommand cmd, Class inClass)
        {
            cmd.Parameters.AddWithValue("@ID", inClass.Id);
            cmd.Parameters.AddWithValue("@NAME", inClass.Name);
            cmd.Parameters.AddWithValue("@ROLE", inClass.Role);
            cmd.Parameters.AddWithValue("@FLAVORTEXT", inClass.FlavorText);
            cmd.Parameters.AddWithValue("@DESCRIPTION", inClass.Description);
        }

        public static Class CreateObjectFromDataRow(DataRow row)
        {
            Class tempClass = new Class();

            tempClass.Id = (row["ID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ID"]);
            tempClass.Name = (row["NAME"] == DBNull.Value) ? string.Empty : Convert.ToString(row["NAME"]);
            tempClass.Role = (row["ROLE"] == DBNull.Value) ? string.Empty : Convert.ToString(row["ROLE"]);
            tempClass.FlavorText = (row["FLAVORTEXT"] == DBNull.Value) ? string.Empty : Convert.ToString(row["FLAVORTEXT"]);
            tempClass.Description = (row["DESCRIPTION"] == DBNull.Value) ? string.Empty : Convert.ToString(row["DESCRIPTION"]);

            return tempClass;
        }
    }
}
