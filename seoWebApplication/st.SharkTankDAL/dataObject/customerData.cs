using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class customerData 
    {

        public List<customer> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.customerSelectAll().ToList();
            }
        }

        public customer Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.customerSelectById(id).SingleOrDefault();
            } 
        }

        public customer Login(string email)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.customerLogin(email, dBHelper.GetWebstoreId()).SingleOrDefault();
            }
        }

        public void updatePoints(int cId, int points)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                db.customerUpdatePoints(cId, points);
            }
        }

      

        public customer FbLogin(int uid)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.customerSelectByFbId(uid, dBHelper.GetWebstoreId()).SingleOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                db.customerDelete(id); 
            }
        }

         #region Insert



        public int Insert(int webstore_id, string fname, string lname, string address1, string address2, string city, string region, string zip, string country, string shippingRegion, decimal dayPhone, decimal cellPhone, decimal evePhone, string creditCard, string username, string password, string email, string squestion, string sanswer, bool sendMail, Nullable<int> fbId, Nullable<int> rewardPoints)
        { 
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                Nullable<int> customer_id = 0;

                db.customerInsert(ref customer_id, webstore_id, fname, lname, address1, address2, city, region, zip, country, shippingRegion, dayPhone, cellPhone, evePhone, creditCard, username, password, email, squestion, sanswer, sendMail, fbId, rewardPoints);

                return Convert.ToInt32(customer_id); 
            }
        }

        #endregion Insert

        #region Update



        public bool Update(int customerid, string fname, string lname, string address1, string address2, string city, string region, string zip, string country, string shippingRegion, decimal dayPhone, decimal cellPhone, decimal evePhone, string creditCard, string username, string password, string email, string squestion, string sanswer, bool sendMail, Nullable<int> fbId, Nullable<int> rewardPoints)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                int rowsAffected = db.customerUpdate(customerid, dBHelper.GetWebstoreId(), fname, lname, address1, address2, city, region, zip, country, shippingRegion, dayPhone, cellPhone, evePhone, creditCard, username, password, email, squestion, sanswer, sendMail, fbId, rewardPoints);
                return rowsAffected == 1; 
            } 
        }

        #endregion Update

    }
    
}