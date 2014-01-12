using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class cuisineData : SEOBaseData<cuisine>
    {
        #region Overrides

        public override List<cuisine> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.cuisineSelectAll().ToList();
            }
        }

        public override cuisine Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.cuisineSelectById(id).SingleOrDefault();
            }
        } 
       

        public override void Delete(seowebappDataContextDataContext db, int id)
        {
            db.cuisineDelete(id);
        }

        #endregion Overrides

        #region Insert

        public int Insert(string connectionString, string name, string seoDescription, string seoTitle, string seoKeywords, Nullable<int> webstore_id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Insert(db, name, seoDescription, seoTitle, seoKeywords, webstore_id);
            }
        }

        public int Insert(seowebappDataContextDataContext db, string name, string seoDescription, string seoTitle, string seoKeywords, Nullable<int> webstore_id)
        {
            Nullable<int> cuisine_id = 0;

            db.cuisineInsert(ref cuisine_id, name, seoDescription, seoTitle, seoKeywords, webstore_id);

            return Convert.ToInt32(cuisine_id);
        }

        #endregion Insert

        #region Update

        public bool Update(string connectionString, int cuisine_id, string name, string seoDescription, string seoTitle, string seoKeywords, Nullable<int> webstore_id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Update(db, cuisine_id, name, seoDescription, seoTitle, seoKeywords, webstore_id);
            }
        }

        public bool Update(seowebappDataContextDataContext db, int cuisine_id, string name, string seoDescription, string seoTitle, string seoKeywords, Nullable<int> webstore_id)
        {
            int rowsAffected = db.cuisineUpdate(cuisine_id, name, seoDescription, seoTitle, seoKeywords, webstore_id);
            return rowsAffected == 1;
        }

        #endregion Update

    }
}