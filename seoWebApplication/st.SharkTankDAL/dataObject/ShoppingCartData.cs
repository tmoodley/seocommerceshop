using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class ShoppingCartData  
    {
        #region Overrides

        public List<ShoppingCart> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.ShoppingCartSelectAll().ToList();
            }
        }

        public ShoppingCart Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.ShoppingCartSelectById(id).SingleOrDefault();
            }
        }

        public void Delete(seowebappDataContextDataContext db, int id)
        {
            db.ShoppingCartDelete(id);
        }

        #endregion Overrides

        #region Insert


        public void Insert(string cart_id, int product_id, string attributes, int webstore_id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                db.ShoppingCartInsert(cart_id, product_id, attributes, webstore_id);
            }
            
        }

        #endregion Insert

        #region Update

        public bool Update(string cart_id, int product_id, int webstore_id, string attributes, int quantity, DateTime dateadded)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                int rowsAffected = db.ShoppingCartUpdate(cart_id, product_id, webstore_id, attributes, quantity, dateadded);
                return rowsAffected == 1;
            }
        }
 

        #endregion Update

    }
}