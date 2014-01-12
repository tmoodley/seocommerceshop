using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class reviewData : SEOBaseData<review>
    {
        #region Overrides

        public override List<review> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.reviewSelectAll().ToList();
            }
        }

        public override review Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.reviewSelectById(id).SingleOrDefault();
            }
        }

        public override void Delete(seowebappDataContextDataContext db, int id)
        {
            db.reviewDelete(id);
        }

        #endregion Overrides

        #region Insert

        public int Insert(string connectionString, bool active, string ipaddress, DateTime dateAdded, Nullable<int> mainRate, Nullable<int> product_id, Nullable<int> webstore_id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Insert(db, active, ipaddress, dateAdded, mainRate, product_id, webstore_id);
            }
        }

        public int Insert(seowebappDataContextDataContext db, bool active, string ipaddress, DateTime dateAdded, Nullable<int> mainRate, Nullable<int> product_id, Nullable<int> webstore_id)
        {
            Nullable<int> review_id = 0;

            db.reviewInsert(ref review_id, active, ipaddress, dateAdded, mainRate, product_id, webstore_id);

            return Convert.ToInt32(review_id);
        }

        #endregion Insert

        #region Update

        public bool Update(string connectionString, int review_id, bool active, string ipaddress, DateTime dateAdded, Nullable<int> mainRate, Nullable<int> product_id, Nullable<int> webstore_id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Update(db, review_id, active, ipaddress, dateAdded, mainRate, product_id, webstore_id);
            }
        }

        public bool Update(seowebappDataContextDataContext db, int review_id, bool active, string ipaddress, DateTime dateAdded, Nullable<int> mainRate, Nullable<int> product_id, Nullable<int> webstore_id)
        {
            int rowsAffected = db.reviewUpdate(review_id, active, ipaddress, dateAdded, mainRate, product_id, webstore_id);
            return rowsAffected == 1;
        }

        #endregion Update

    }
}