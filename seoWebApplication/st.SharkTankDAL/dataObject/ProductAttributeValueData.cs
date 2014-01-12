using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class ProductAttributeValueData : ENTBaseData<ProductAttributeValue>
    {
        #region Overrides

        public override List<ProductAttributeValue> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.ProductAttributeValueSelectAll().ToList();
            }
        }

        public override ProductAttributeValue Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.ProductAttributeValueSelectById(id).SingleOrDefault();
            }
        }

        public override void Delete(seowebappDataContextDataContext db, int id)
        {
            db.ProductAttributeValueDelete(id);
        }

        #endregion Overrides

        #region Insert

        public int Insert(string connectionString, int productAttributeValueId, int product_id, int attributeValueID, int webstore_id, decimal value, int insertENTUserAccountId)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Insert(db, productAttributeValueId, product_id, attributeValueID, webstore_id, value, insertENTUserAccountId);
            }
        }

        public int Insert(seowebappDataContextDataContext db, int productAttributeValueId, int product_id, int attributeValueID, int webstore_id, decimal value, int insertENTUserAccountId)
        {
            Nullable<int> productAttributeValue_id = 0;

            db.ProductAttributeValueInsert(ref productAttributeValue_id, product_id, attributeValueID, webstore_id, value, insertENTUserAccountId);

            return Convert.ToInt32(productAttributeValue_id);
        }

        #endregion Insert

        #region Update

        public bool Update(string connectionString, int productAttributeValueId, int product_id, int attributeValueID, int webstore_id, decimal value, int updateENTUserAccountId, Binary version)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Update(db, productAttributeValueId, product_id, attributeValueID, webstore_id, value, updateENTUserAccountId, version);
            }
        }

        public bool Update(seowebappDataContextDataContext db, int productAttributeValueId, int product_id, int attributeValueID, int webstore_id, decimal value, int updateENTUserAccountId, Binary version)
        {
            int rowsAffected = db.ProductAttributeValueUpdate(productAttributeValueId, product_id, attributeValueID, webstore_id, value, updateENTUserAccountId, version);
            return rowsAffected == 1;
        }

        #endregion Update

    }
}