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
    #region productEO
    
    [Serializable()]
    public class productEO : ENTBaseEO
    {
        #region Properties

        public int product_id { get; set; }
        public int webstore_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string thumbnail { get; set; }
        public string image { get; set; }
        public bool promofront { get; set; }
        public bool promodept { get; set; }
        public bool defaultAttribute { get; set; }
        public bool defaultAttCat { get; set; }

        #endregion Properties

        #region Overrides

        public override bool Load(int id)
        {            
            //Get the entity object from the DAL.
            product product = new productData().Select(id);
            MapEntityToProperties(product);
            return product != null;        
        }

        //public void MapEntityToProperties(product entity)
        protected override void MapEntityToCustomProperties(IENTBaseEntity entity)
        {
            product product = (product)entity;

            product_id = product.product_id;
            webstore_id = product.webstore_id;
            name = product.name;
            description = product.description;
            price = product.price;
            thumbnail = product.thumbnail;
            image = product.image;
            promofront = product.promofront;
            promodept = product.promodept;
            defaultAttribute = product.defaultAttribute;
            defaultAttCat = product.defaultAttCat;
        }

        //public bool Save(bool newrec)
        //{
        //    if (newrec)
        //    { 
        //        //Add
        //        product_id = new productData().Insert(webstore_id, name, description, price, thumbnail, image, promofront, promodept);
 
        //    }
        //    else
        //    { 
        //        //Update
        //        if (!new productData().Update(product_id, webstore_id, name, description, price, thumbnail, image, promofront, promodept)) ;
        //        {

        //            return false;
        //        }
        //    }

        //    return true;


        //}

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
                        product_id = new productData().Insert(webstore_id, name, description, price, thumbnail, image, promofront, promodept, defaultAttribute, defaultAttCat, userAccountId);
 
                    }
                    else
                    {
                        //Update
                        if (!new productData().Update(product_id, webstore_id, name, description, price, thumbnail, image, promofront, promodept, defaultAttribute, defaultAttCat, userAccountId, Version)) 
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

        public bool SaveWs(int userAccountId, bool newRec)
        {
            
                if (newRec)
                {
                    //Add
                    product_id = new productData().Insert(webstore_id, name, description, price, thumbnail, image, promofront, promodept, defaultAttribute, defaultAttCat, userAccountId);

                }
                else
                {
                    //Update
                    if (!new productData().Update(product_id, webstore_id, name, description, price, thumbnail, image, promofront, promodept, defaultAttribute, defaultAttCat, userAccountId, Version))
                    { 
                        return false;
                    }
                }

                return true;
             
        }
             

        protected override void Validate(seowebappDataContextDataContext db, ref ENTValidationErrors validationErrors)
        {
            productData productData = new productData();
             
            //name is required.
            if (name.Trim().Length == 0)
            {
                validationErrors.Add("The name is required.");
            }

            if (DBAction == DBActionEnum.Delete)
            {
                if (db.ShoppingCartSelectByPId(ID) > 0)
                {
                    validationErrors.Add("There are products in the shopping cart.");
                }

                if (db.ProductAttributeValueCountByPId(ID) > 0)
                {
                    validationErrors.Add("There are Product Attributes associated to this product.");
                }
            }


        }

        protected override void DeleteForReal(seowebappDataContextDataContext db)
        {
            if (DBAction == DBActionEnum.Delete)
            {
                new productData().Delete(db,product_id);
            }
            else
            {
                throw new Exception("DBAction not delete.");
            }
        }

        protected override void ValidateDelete(seowebappDataContextDataContext db, ref ENTValidationErrors validationErrors)
        {
            //Validate the object
            Validate(db, ref validationErrors);

            

            //Check if there were any validation errors
            if (validationErrors.Count == 0)
            {

            }
        }

        public void removeProductId(int pid)
        {
            new productData().RemoveProductScart(pid);           
        }

        public override void Init()
        {
            promofront = true;
        }

        protected override string GetDisplayText()
        {
            return description;
        }

         
 

         

        #endregion Overrides
    }

    #endregion productEO

    #region productEOList

    [Serializable()]
    public class productEOList : List<productEO>
    {
        #region Overrides

        public void Load()
        {
            LoadFromList(new productData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<product> products)
        {
            if (products.Count > 0)
            {
                foreach (product product in products)
                {
                    productEO newproductEO = new productEO();
                    newproductEO.MapEntityToProperties(product);
                    this.Add(newproductEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        //public List<product> SortByPropertyName(string propertyName, bool ascending)
        //{
        //    //Create a Lambda expression to dynamically sort the data.
        //    var param = Expression.Parameter(typeof(product), "N");

        //    var sortExpresseion = Expression.Lambda<Func<product, object>>
        //        (Expression.Convert(Expression.Property(param, propertyName), typeof(object)), param);

        //    if (ascending)
        //    {
        //        return this.AsQueryable<product>().OrderBy<product, object>(sortExpresseion).ToList<T>();
        //    }
        //    else
        //    {
        //        return this.AsQueryable<product>().OrderByDescending<product, object>(sortExpresseion).ToList<product>();
        //    }
        //}

        #endregion Internal Methods
    }

    #endregion productEOList
}
