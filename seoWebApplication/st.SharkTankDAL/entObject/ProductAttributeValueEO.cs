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
    #region ProductAttributeValueEO

    [Serializable()]
    public class ProductAttributeValueEO : ENTBaseEO
    {
        #region Properties

        public int ProductAttributeValueId { get; set; }
        public int product_id { get; set; }
        public int AttributeValueID { get; set; }
        public int webstore_id { get; set; }
        public decimal Value { get; set; }

        #endregion Properties

        #region Overrides

        public override bool Load(int id)
        {            
            //Get the entity object from the DAL.
            ProductAttributeValue productAttributeValue = new ProductAttributeValueData().Select(id);
            MapEntityToProperties(productAttributeValue);
            return productAttributeValue != null;        
        }

        protected override void MapEntityToCustomProperties(IENTBaseEntity entity)
        {
            ProductAttributeValue productAttributeValue = (ProductAttributeValue)entity;

            ID = productAttributeValue.ProductAttributeValueId;
            ProductAttributeValueId = productAttributeValue.ProductAttributeValueId;
            product_id = productAttributeValue.product_id;
            AttributeValueID = productAttributeValue.AttributeValueID;
            webstore_id = productAttributeValue.webstore_id;
            Value = productAttributeValue.Value;
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
                        ID = new ProductAttributeValueData().Insert(db, ProductAttributeValueId, product_id, AttributeValueID, webstore_id, Value, userAccountId);

                    }
                    else
                    {
                        //Update
                        if (!new ProductAttributeValueData().Update(db, ID, product_id, AttributeValueID, webstore_id, Value, userAccountId, Version))
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
            ProductAttributeValueData ProductAttributeValueData = new ProductAttributeValueData();

            //name is required.
            if (Value == 0)
            {
                validationErrors.Add("The Value is required.");
            }
        }

        protected override void DeleteForReal(seowebappDataContextDataContext db)
        {
         
            if (DBAction == DBActionEnum.Delete)
            {
                new ProductAttributeValueData().Delete(db, ID);
            }
            else
            {
                throw new Exception("DBAction not delete.");
            }
        }

        protected override void ValidateDelete(seowebappDataContextDataContext db, ref ENTValidationErrors validationErrors)
        {
            //throw new NotImplementedException();
             //Validate the object
                Validate(db, ref validationErrors);

                //Check if there were any validation errors
                if (validationErrors.Count == 0)
                {
                   
                }

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

    #endregion ProductAttributeValueEO

    #region ProductAttributeValueEOList

    [Serializable()]
    public class ProductAttributeValueEOList : ENTBaseEOList<ProductAttributeValueEO>
    {
        #region Overrides

        public override void Load()
        {
            LoadFromList(new ProductAttributeValueData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<ProductAttributeValue> productAttributeValues)
        {
            if (productAttributeValues.Count > 0)
            {
                foreach (ProductAttributeValue productAttributeValue in productAttributeValues)
                {
                    ProductAttributeValueEO newProductAttributeValueEO = new ProductAttributeValueEO();
                    newProductAttributeValueEO.MapEntityToProperties(productAttributeValue);
                    this.Add(newProductAttributeValueEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion ProductAttributeValueEOList
}
