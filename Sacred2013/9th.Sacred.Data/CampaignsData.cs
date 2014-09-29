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
    public class CampaignsData : DataAccessBase
    {
        public CampaignsData(DataContext context)
            : base(context)
        { }


        #region Sql Strings

        private const string SQL_CREATE_CAMPAIGN = @"
            insert into Campaigns (USERID_FK, NAME, CREATEDATE)
            VALUES (@USERID_FK, @NAME, @CREATEDATE);
            SELECT CONVERT(int, SCOPE_IDENTITY());
        ";

        private const string SQL_READ_CAMPAIGNS_BY_USER_ID = @"
            select * from Campaigns where USERID_FK = @USERID_FK
        ";

        private const string SQL_DELETE_CAMPAIGN_BY_ID = @"
            delete from Campaigns where ID = @ID
        ";

        #endregion


        public int Create(Campaign campaign)
        {
            int id = 0;

            using (SqlCommand cmd = new SqlCommand(SQL_CREATE_CAMPAIGN))
            {
                LoadParameters(cmd, campaign);
                id = (int)ExecuteScalarQuery(cmd);
            }

            return id;
        }

        public List<Campaign> ReadCampaignsByUserId(int userId)
        {
            List<Campaign> campaigns = new List<Campaign>();
            DataSet data = new DataSet();

            using (SqlCommand cmd = new SqlCommand(SQL_READ_CAMPAIGNS_BY_USER_ID))
            {
                cmd.Parameters.AddWithValue("@USERID_FK", userId);
                data = ExecuteSqlQuery(cmd);
            }

            if (!DataSetIsEmpty(data))
            {
                foreach (DataRow row in data.Tables[0].Rows)
                {
                    campaigns.Add(CreateObjectFromDataRow(row));
                }
            }

            return campaigns;
        }

        public void DeleteCampaignById(int id)
        {
            using (SqlCommand cmd = new SqlCommand(SQL_DELETE_CAMPAIGN_BY_ID))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                ExecuteSqlNonQuery(cmd);
            }
        }


        //--------------------------------------------------
        private void LoadParameters(SqlCommand cmd, Campaign campaign)
        {
            cmd.Parameters.AddWithValue("@ID", campaign.Id);
            cmd.Parameters.AddWithValue("@USERID_FK", campaign.UserId);
            cmd.Parameters.AddWithValue("@NAME", campaign.Name);
            cmd.Parameters.AddWithValue("@CREATEDATE", campaign.CreateDate);
        }

        public static Campaign CreateObjectFromDataRow(DataRow row)
        {
            Campaign campaign = new Campaign();

            campaign.Id = (row["ID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ID"]);
            campaign.UserId = (row["USERID_FK"] == DBNull.Value) ? 0 : Convert.ToInt32(row["USERID_FK"]);
            campaign.Name = (row["NAME"] == DBNull.Value) ? string.Empty : Convert.ToString(row["NAME"]);
            campaign.CreateDate = (row["CREATEDATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["CREATEDATE"]);

            return campaign;
        }
    }
}
