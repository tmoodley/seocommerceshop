using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using seoWebApplication.st.SharkTankDAL.dataObject;

namespace seoWebApplication.st.SharkTankDAL
{
    public class dBHelper
    { 
        public static string GetSeoWebAppConnectionString()
        {
            return seoWebAppConfiguration.DbConnectionString;
        }

        public static int GetWebstoreId()
        {
            return seoWebAppConfiguration.IdWebstore;
        }

        public static int GetUserId(string UserEmail)
        {
            UserAccountEO userAccount = new UserAccountEO(); 
            return userAccount.getUserId(UserEmail);  
        }

    }
}
