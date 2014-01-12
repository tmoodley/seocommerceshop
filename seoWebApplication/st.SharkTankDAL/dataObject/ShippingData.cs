using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class ShippingData  
    {
        #region Overrides

        public List<Shipping> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.ShippingSelectAll().ToList();
            }
        }

        public Shipping Select(int id, int webstore_id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.ShippingSelectById(id, webstore_id).SingleOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                db.ShippingDelete(id);
            }
        }
         
  

        #endregion Overrides

        #region Insert

        public int Insert(Nullable<int> webstore_id, string shippingType, decimal shippingCost, Nullable<int> shippingRegionID)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                Nullable<int> shippingID = 0;

                db.ShippingInsert(ref shippingID, webstore_id, shippingType, shippingCost, shippingRegionID);

                return Convert.ToInt32(shippingID);
            }

        }

        

        #endregion Insert

        #region Update

        public bool Update(int shippingID, Nullable<int> webstore_id, string shippingType, decimal shippingCost, Nullable<int> shippingRegionID)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            { 
                int rowsAffected = db.ShippingUpdate(shippingID, webstore_id, shippingType, shippingCost, shippingRegionID);
                return rowsAffected == 1;
            }
        }

         

        #endregion Update

    }
}