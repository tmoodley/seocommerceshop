using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class productData : ENTBaseData<product>
    {
        #region Overrides

        public override List<product> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.productSelectAll().ToList();
            }
        }

        public override product Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.productSelectById(id).SingleOrDefault();
            }
        }

        public void RemoveProductScart(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                db.ShoppingCartRemoveProductById(id);
            }
        }

        public override void Delete(seowebappDataContextDataContext db, int id)
        {
             
                db.productDelete(id);
            
        }

        

        #endregion Overrides

        #region Insert

        public int Insert(int webstore_id, string name, string description, decimal price, string thumbnail, string image, bool promofront, bool promodept, bool defaultAttribute, bool defaultAttCat, int insertENTUserAccountId)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                Nullable<int> product_id = 0;

                db.productInsert(ref product_id, webstore_id, name, description, price, thumbnail, image, promofront, promodept, defaultAttribute, defaultAttCat, insertENTUserAccountId);

                return Convert.ToInt32(product_id);
            } 
             
        }

        

        #endregion Insert

        #region Update


        public bool Update(int product_id, int webstore_id, string name, string description, decimal price, string thumbnail, string image, bool promofront, bool promodept, bool defaultAttribute, bool defaultAttCat, int updateENTUserAccountId, Binary version)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                int rowsAffected = db.productUpdate(product_id, webstore_id, name, description, price, thumbnail, image, promofront, promodept, defaultAttribute, defaultAttCat, updateENTUserAccountId, version);
                return rowsAffected == 1;
            }
        }

         
        #endregion Update

    }
}