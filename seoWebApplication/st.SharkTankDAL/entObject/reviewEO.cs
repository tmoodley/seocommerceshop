using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.entObject;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.Framework;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    #region reviewEO

    [Serializable()]
    public class reviewEO : SEOBaseEO
    {
        #region Properties

        public bool active { get; set; }
        public string ipaddress { get; set; }
        public DateTime dateAdded { get; set; }
        public Nullable<int> MainRate { get; set; }
        public Nullable<int> product_id { get; set; }
        public Nullable<int> webstore_id { get; set; }

        #endregion Properties

        #region Overrides

        public override bool Load(int id)
        {            
            //Get the entity object from the DAL.
            review review = new reviewData().Select(id);
            MapEntityToProperties(review);
            return review != null;        
        }

        protected override void MapEntityToCustomProperties(ISEOBaseEntity entity)
        {
            review review = (review)entity;

            ID = review.review_id;
            active = Convert.ToBoolean(review.active);
            ipaddress = review.ipaddress;
            dateAdded = Convert.ToDateTime(review.dateAdded);
            MainRate = review.MainRate;
            product_id = review.product_id;
            webstore_id = review.webstore_id;
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
                        ID = new reviewData().Insert(db, active, ipaddress, dateAdded, MainRate, product_id, webstore_id);

                    }
                    else
                    {
                        //Update
                        if (!new reviewData().Update(db, ID, active, ipaddress, dateAdded, MainRate, product_id, webstore_id))
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
            reviewData reviewdata = new reviewData();
            //name is required.
            if (ipaddress.Trim().Length == 0)
            {
                validationErrors.Add("The ipaddress is required.");
            }
        }

        protected override void DeleteForReal(seowebappDataContextDataContext db)
        {
            if (DBAction == DBActionEnum.Delete)
            {
                new reviewData().Delete(db, ID);
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
            dateAdded = DateTime.Now;

            active = true;


        }

        protected override string GetDisplayText()
        {
            throw new NotImplementedException();
        }

        #endregion Overrides
    }

    #endregion reviewEO

    #region reviewEOList

    [Serializable()]
    public class reviewEOList : SEOBaseEOList<reviewEO>
    {
        #region Overrides

        public override void Load()
        {
            LoadFromList(new reviewData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<review> reviews)
        {
            if (reviews.Count > 0)
            {
                foreach (review review in reviews)
                {
                    reviewEO newreviewEO = new reviewEO();
                    newreviewEO.MapEntityToProperties(review);
                    this.Add(newreviewEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion reviewEOList
}
