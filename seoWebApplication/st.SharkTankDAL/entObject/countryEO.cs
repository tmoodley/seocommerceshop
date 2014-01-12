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
    #region countryEO

    [Serializable()]
    public class countryEO : SEOBaseEO
    {
        #region Properties

        public int idCountry { get; set; }
        public string countrySname { get; set; }
        public string countryLname { get; set; }

        #endregion Properties

        #region Overrides

        public override bool Load(int id)
        {            
            //Get the entity object from the DAL.
            country country = new countryData().Select(id);
            MapEntityToProperties(country);
            return country != null;        
        }

        protected override void MapEntityToCustomProperties(ISEOBaseEntity entity)
        {
            country country = (country)entity;

            ID = country.idCountry;
            idCountry = country.idCountry;
            countrySname = country.countrySname;
            countryLname = country.countryLname;
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
                        ID = new countryData().Insert(db, countrySname, countryLname);

                    }
                    else
                    {
                        //Update
                        if (!new countryData().Update(db, ID, countrySname, countryLname))
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
            countryData countryData = new countryData();

            //name is required.
            if (countrySname.Trim().Length == 0)
            {
                validationErrors.Add("The Short name is required.");
            }

            if (countryLname.Trim().Length == 0)
            {
                validationErrors.Add("The Long name is required.");
            }
        }

        protected override void DeleteForReal(seowebappDataContextDataContext db)
        {
            if (DBAction == DBActionEnum.Delete)
            {
                new countryData().Delete(db, ID);
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
            countrySname = "";
        }

        protected override string GetDisplayText()
        {
            throw new NotImplementedException();
        }

        #endregion Overrides
    }

    #endregion countryEO

    #region countryEOList

    [Serializable()]
    public class countryEOList : SEOBaseEOList<countryEO>
    {
        #region Overrides

        public override void Load()
        {
            LoadFromList(new countryData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<country> countrys)
        {
            if (countrys.Count > 0)
            {
                foreach (country country in countrys)
                {
                    countryEO newcountryEO = new countryEO();
                    newcountryEO.MapEntityToProperties(country);
                    this.Add(newcountryEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion countryEOList
}
