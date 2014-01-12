using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class ShippingRegionData 
    {
        #region Overrides

        public List<ShippingRegion> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.ShippingRegionSelectAll().ToList();
            }
        }

        public ShippingRegion Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.ShippingRegionSelectById(id).SingleOrDefault();
            }
        }

        public ShippingRegion SelectByDesc(string id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.ShippingRegionSelectByDesc(id).SingleOrDefault();
            }
        }

        public void Delete(seowebappDataContextDataContext db, int id)
        {
            db.ShippingRegionDelete(id);
        }

        #endregion Overrides

        #region Insert

        public int Insert(string shippingRegion, string shippingRegionSmall)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                Nullable<int> shippingRegion_id = 0;

                db.ShippingRegionInsert(ref shippingRegion_id, shippingRegion, shippingRegionSmall);

                return Convert.ToInt32(shippingRegion_id);
            }
        }

         
        #endregion Insert

        #region Update

        public bool Update(int shippingRegion_id, string shippingRegion, string shippingRegionSmall)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                int rowsAffected = db.ShippingRegionUpdate(shippingRegion_id, shippingRegion, shippingRegionSmall);
                return rowsAffected == 1;
            }
        }

        

        #endregion Update

    }
}