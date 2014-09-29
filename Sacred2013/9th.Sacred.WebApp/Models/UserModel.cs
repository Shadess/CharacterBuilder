using _9th.Sacred.Objects.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace _9th.Sacred.WebApp.Models
{
    public class UserModel
    {
        public User User { get; set; }
        public bool IsMyProfile { get; set; }
        public List<Campaign> Campaigns { get; set; }

        public UserModel()
        {
            InitializeValues();
        }

        public void InitializeValues()
        {
            User = null;
            IsMyProfile = false;
            Campaigns = new List<Campaign>();
        }

        public string GravatarLink()
        {
            MD5 md5hasher = MD5.Create();
            byte[] data = md5hasher.ComputeHash(Encoding.Default.GetBytes(this.User.Email));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return string.Format("http://www.gravatar.com/avatar/{0}?size=150", sBuilder.ToString());
        }
    }
}