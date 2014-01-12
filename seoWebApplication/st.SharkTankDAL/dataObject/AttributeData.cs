using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class AttributeData : ENTBaseData<Attribute>
    {
        #region Overrides

        public override List<Attribute> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.AttributeSelectAll().ToList();
            }
        }

        public override Attribute Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.AttributeSelectById(id).SingleOrDefault();
            }
        }

        public override void Delete(seowebappDataContextDataContext db, int id)
        {
            db.AttributeDelete(id);
        }

        #endregion Overrides

        #region Insert

        public int Insert(string connectionString, int attributeID, string name, int controlType_id, int webstore_id, bool applyToAllProducts, bool applyToCategory, int insertENTUserAccountId)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Insert(db, attributeID, name, controlType_id, webstore_id, applyToAllProducts, applyToCategory, insertENTUserAccountId);
            }
        }

        public int Insert(seowebappDataContextDataContext db, int attributeID, string name, int controlType_id, int webstore_id, bool applyToAllProducts, bool applyToCategory, int insertENTUserAccountId)
        {
            Nullable<int> attribute_id = 0;

            db.AttributeInsert(ref attribute_id, name, controlType_id, webstore_id, applyToAllProducts, applyToCategory, insertENTUserAccountId);

            return Convert.ToInt32(attribute_id);
        }

        #endregion Insert

        #region Update

        public bool Update(string connectionString, int attribute_id, int attributeID, string name, int controlType_id, int webstore_id, bool applyToAllProducts, bool applyToCategory, int updateENTUserAccountId, Binary version)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Update(db, attribute_id, name, controlType_id, webstore_id, applyToAllProducts, applyToCategory, updateENTUserAccountId, version);
            }
        }

        public bool Update(seowebappDataContextDataContext db,int attribute_id, string name, int controlType_id, int webstore_id, bool applyToAllProducts, bool applyToCategory, int updateENTUserAccountId, Binary version)
        {
            int rowsAffected = db.AttributeUpdate(attribute_id, name, controlType_id, webstore_id, applyToAllProducts, applyToCategory, updateENTUserAccountId, version);
            return rowsAffected == 1;
        }

        #endregion Update

    }
}