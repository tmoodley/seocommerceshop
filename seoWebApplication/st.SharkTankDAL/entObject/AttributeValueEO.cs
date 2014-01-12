using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Linq.Expressions;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.entObject;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.Framework;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    #region AttributeValueEO

    [Serializable()]
    public class AttributeValueEO : ENTBaseEO
    {
        #region Properties

        public int AttributeValueID { get; set; }
        public int AttributeID { get; set; }
        public string Value { get; set; }
        public int webstore_id { get; set; }

        #endregion Properties

        #region Overrides

        public override bool Load(int id)
        {            
            //Get the entity object from the DAL.
            AttributeValue attributeValue = new AttributeValueData().Select(id);
            MapEntityToProperties(attributeValue);
            return attributeValue != null;        
        }

        protected override void MapEntityToCustomProperties(IENTBaseEntity entity)
        {
            AttributeValue attributeValue = (AttributeValue)entity;

            ID = attributeValue.AttributeValueID;
            AttributeValueID = attributeValue.AttributeValueID;
            AttributeID = attributeValue.AttributeID;
            Value = attributeValue.Value;
            webstore_id = attributeValue.webstore_id;
        }

        public override bool Save(seowebappDataContextDataContext db, ref ENTValidationErrors validationErrors, int userAccountId)
        {
            if (DBAction == DBActionEnum.Save)
            {
                //Validate the object
                Validate(db, ref validationErrors);

                //Check if there were any validation errors
                if (validationErrors.Count == 0)
                {
                    if (IsNewRecord())
                    {
                        //Add
                        ID = new AttributeValueData().Insert(db, AttributeID, Value, webstore_id, userAccountId);

                    }
                    else
                    {
                        //Update
                        if (!new AttributeValueData().Update(db, ID, AttributeID, Value, webstore_id, userAccountId, Version))
                        {
                            UpdateFailed(ref validationErrors);
                            return false;
                        }
                    }

                    return true;

                }
                else
                {
                    //Didn't pass validation.
                    return false;
                }
            }
            else
            {
                throw new Exception("DBAction not Save.");
            }
        }

        protected override void Validate(seowebappDataContextDataContext db, ref ENTValidationErrors validationErrors)
        {
            AttributeValueData attributeValueData = new AttributeValueData();

            //name is required.
            if (Value.Trim().Length == 0)
            {
                validationErrors.Add("The Value is required.");
            }
        }

        protected override void DeleteForReal(seowebappDataContextDataContext db)
        {
            if (DBAction == DBActionEnum.Delete)
            {
                new AttributeValueData().Delete(db, ID);
            }
            else
            {
                throw new Exception("DBAction not delete.");
            }
        }

        protected override void ValidateDelete(seowebappDataContextDataContext db, ref ENTValidationErrors validationErrors)
        {
            throw new NotImplementedException();
        }

        public override void Init()
        {
            this.webstore_id = dBHelper.GetWebstoreId();
           
        }

        protected override string GetDisplayText()
        {
            throw new NotImplementedException();
        }

        #endregion Overrides
    }

    #endregion AttributeValueEO

    #region AttributeValueEOList

    [Serializable()]
    public class AttributeValueEOList : ENTBaseEOList<AttributeValueEO>
    {
        #region Overrides

        public override void Load()
        {
            LoadFromList(new AttributeValueData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<AttributeValue> attributeValues)
        {
            if (attributeValues.Count > 0)
            {
                foreach (AttributeValue attributeValue in attributeValues)
                {
                    AttributeValueEO newAttributeValueEO = new AttributeValueEO();
                    newAttributeValueEO.MapEntityToProperties(attributeValue);
                    this.Add(newAttributeValueEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion AttributeValueEOList
}
