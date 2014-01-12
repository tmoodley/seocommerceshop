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
    #region AttributeEO

    [Serializable()]
    public class AttributeEO : ENTBaseEO
    {
        #region Properties

        public int AttributeID { get; set; }
        public string Name { get; set; }
        public int controlType_id { get; set; }
        public int webstore_id { get; set; }
        public bool applyToAllProducts { get; set; }
        public bool applyToCategory { get; set; }

        #endregion Properties

        #region Overrides

        public override bool Load(int id)
        {            
            //Get the entity object from the DAL.
            Attribute attribute = new AttributeData().Select(id);            
            MapEntityToProperties(attribute);
            return attribute != null;        
        }

        protected override void MapEntityToCustomProperties(IENTBaseEntity entity)
        {
            Attribute attribute = (Attribute)entity;

            ID = attribute.AttributeID;
            AttributeID = attribute.AttributeID;
            Name = attribute.Name;
            controlType_id = attribute.controlType_id;
            webstore_id = attribute.webstore_id;
            applyToAllProducts = attribute.applyToAllProducts;
            applyToCategory = attribute.applyToCategory;
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
                        ID = new AttributeData().Insert(db, AttributeID, Name, controlType_id, webstore_id, applyToAllProducts, applyToCategory, userAccountId);

                    }
                    else
                    {
                        //Update
                        if (!new AttributeData().Update(db, ID, Name, controlType_id, webstore_id, applyToAllProducts, applyToCategory, userAccountId, Version))
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
            AttributeData attributeData = new AttributeData();

            //name is required.
            if (Name.Trim().Length == 0)
            {
                validationErrors.Add("The name is required.");
            }
        }

        protected override void DeleteForReal(seowebappDataContextDataContext db)
        {
            if (DBAction == DBActionEnum.Delete)
            {
                new AttributeData().Delete(db, ID);
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
            webstore_id = dBHelper.GetWebstoreId();
        }

        protected override string GetDisplayText()
        {
            throw new NotImplementedException();
        }

        #endregion Overrides
    }

    #endregion AttributeEO

    #region AttributeEOList

    [Serializable()]
    public class AttributeEOList : ENTBaseEOList<AttributeEO>
    {
        #region Overrides

        public override void Load()
        {
            LoadFromList(new AttributeData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<Attribute> attributes)
        {
            if (attributes.Count > 0)
            {
                foreach (Attribute attribute in attributes)
                {
                    AttributeEO newAttributeEO = new AttributeEO();
                    newAttributeEO.MapEntityToProperties(attribute);
                    this.Add(newAttributeEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion AttributeEOList
}
