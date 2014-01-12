using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class pointsData : SEOBaseData<points>
    {
        #region Overrides

        public override List<points> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            { 
                return db.pointsSelectAll().ToList();
            }
        }

        public override points Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.pointsSelectByWId(id).SingleOrDefault();
            }
        }

        public override void Delete(seowebappDataContextDataContext db, int id)
        {
            db.pointsDelete(id);
        }

        #endregion Overrides

        #region Insert

        public int Insert(string connectionString, Nullable<int> webstore_id, string name, string conversionRate, Nullable<int> point, decimal percentage, bool active)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Insert(db, webstore_id, name, conversionRate, point, percentage, active);
            }
        }

        public int Insert(seowebappDataContextDataContext db, Nullable<int> webstore_id, string name, string conversionRate, Nullable<int> point, decimal percentage, bool active)
        {
            Nullable<int> points_id = 0;

            db.pointsInsert(ref points_id, webstore_id, name, conversionRate, point, percentage, active);

            return Convert.ToInt32(points_id);
        }

        #endregion Insert

        #region Update

        public bool Update(string connectionString, int points_id, Nullable<int> webstore_id, string name, string conversionRate, Nullable<int> point, decimal percentage, bool active)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Update(db, points_id, webstore_id, name, conversionRate, point, percentage, active);
            }
        }

        public bool Update(seowebappDataContextDataContext db, int points_id, Nullable<int> webstore_id, string name, string conversionRate, Nullable<int> point, decimal percentage, bool active)
        {
            int rowsAffected = db.pointsUpdate(points_id, webstore_id, name, conversionRate, point, percentage, active);
            return rowsAffected == 1;
        }

        #endregion Update

    }
}