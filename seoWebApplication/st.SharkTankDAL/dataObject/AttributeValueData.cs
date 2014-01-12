using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class AttributeValueData : ENTBaseData<AttributeValue>
    {
        #region Overrides

        public override List<AttributeValue> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.AttributeValueSelectAll().ToList();
            }
        }

        public override AttributeValue Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.AttributeValueSelectById(id).SingleOrDefault();
            }
        }

        public override void Delete(seowebappDataContextDataContext db, int id)
        {
            db.AttributeValueDelete(id);
        }

        #endregion Overrides

        #region Insert

        public int Insert(string connectionString, int attributeID, string value, int webstore_id, int insertENTUserAccountId)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Insert(db, attributeID, value, webstore_id, insertENTUserAccountId);
            }
        }

        public int Insert(seowebappDataContextDataContext db, int attributeID, string value, int webstore_id, int insertENTUserAccountId)
        {
            Nullable<int> attributeValue_id = 0;

            db.AttributeValueInsert(ref attributeValue_id, attributeID, value, webstore_id, insertENTUserAccountId);

            return Convert.ToInt32(attributeValue_id);
        }

        #endregion Insert

        #region Update

        public bool Update(string connectionString, int attributeValueID, int attributeID, string value, int webstore_id, int updateENTUserAccountId, Binary version)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Update(db, attributeValueID, attributeID, value, webstore_id, updateENTUserAccountId, version);
            }
        }

        public bool Update(seowebappDataContextDataContext db, int attributeValueID, int attributeID, string value, int webstore_id, int updateENTUserAccountId, Binary version)
        {
            int rowsAffected = db.AttributeValueUpdate(attributeValueID, attributeID, value, webstore_id, updateENTUserAccountId, version);
            return rowsAffected == 1;
        }

        #endregion Update

    }
}