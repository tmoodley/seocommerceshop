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
    #region cuisineEO

    [Serializable()]
    public class cuisineEO : SEOBaseEO
    {
        #region Properties

        public string name { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeywords { get; set; }
        public Nullable<int> webstore_id { get; set; }

        #endregion Properties

        #region Overrides

        public override bool Load(int id)
        {            
            //Get the entity object from the DAL.
            cuisine cuisine = new cuisineData().Select(id);
            MapEntityToProperties(cuisine);
            return cuisine != null;        
        }

        protected override void MapEntityToCustomProperties(ISEOBaseEntity entity)
        {
            cuisine cuisine = (cuisine)entity;

            ID = cuisine.cuisine_id;
            name = cuisine.name;
            SeoDescription = cuisine.SeoDescription;
            SeoTitle = cuisine.SeoTitle;
            SeoKeywords = cuisine.SeoKeywords;
            webstore_id = cuisine.webstore_id;
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
                        ID = new cuisineData().Insert(db, name, SeoDescription, SeoTitle, SeoKeywords, webstore_id);

                    }
                    else
                    {
                        //Update
                        if (!new cuisineData().Update(db, ID, name, SeoDescription, SeoTitle, SeoKeywords, webstore_id))
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
            cuisineData cuisineData = new cuisineData();

            //name is required.
            if (name.Trim().Length == 0)
            {
                validationErrors.Add("The Name is required.");
            }
        }

        protected override void DeleteForReal(seowebappDataContextDataContext db)
        {
            if (DBAction == DBActionEnum.Delete)
            {
                new cuisineData().Delete(db, ID);
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

    #endregion cuisineEO

    #region cuisineEOList

    [Serializable()]
    public class cuisineEOList : SEOBaseEOList<cuisineEO>
    {
        #region Overrides

        public override void Load()
        {
            LoadFromList(new cuisineData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<cuisine> cuisines)
        {
            if (cuisines.Count > 0)
            {
                foreach (cuisine cuisine in cuisines)
                {
                    cuisineEO newcuisineEO = new cuisineEO();
                    newcuisineEO.MapEntityToProperties(cuisine);
                    this.Add(newcuisineEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion cuisineEOList
}
