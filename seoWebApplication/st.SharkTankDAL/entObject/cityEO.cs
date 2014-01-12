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
    #region cityEO

    [Serializable()]
    public class cityEO : SEOBaseEO
    {
        #region Properties

        public int idCity { get; set; }
        public int idState { get; set; }
        public string city1 { get; set; }

        #endregion Properties

        #region Overrides

        public override bool Load(int id)
        {            
            //Get the entity object from the DAL.
            city city = new cityData().Select(id);
            MapEntityToProperties(city);
            return city != null;        
        }

        protected override void MapEntityToCustomProperties(ISEOBaseEntity entity)
        {
            city city = (city)entity;

            ID = city.idCity;
            idCity = city.idCity;
            idState = city.idState;
            city1 = city.city1;
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
                        ID = new cityData().Insert(db, idState, city1);

                    }
                    else
                    {
                        //Update
                        if (!new cityData().Update(db, ID, idState, city1))
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
            cityData cityData = new cityData();

            //name is required.
            if (city1.Trim().Length == 0)
            {
                validationErrors.Add("The City name is required.");
            }

            
        }

        protected override void DeleteForReal(seowebappDataContextDataContext db)
        {
            if (DBAction == DBActionEnum.Delete)
            {
                new cityData().Delete(db, ID);
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
            city1 = "";
        }

        protected override string GetDisplayText()
        {
            throw new NotImplementedException();
        }

        #endregion Overrides
    }

    #endregion cityEO

    #region cityEOList

    [Serializable()]
    public class cityEOList : SEOBaseEOList<cityEO>
    {
        #region Overrides

        public override void Load()
        {
            LoadFromList(new cityData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<city> citys)
        {
            if (citys.Count > 0)
            {
                foreach (city city in citys)
                {
                    cityEO newcityEO = new cityEO();
                    newcityEO.MapEntityToProperties(city);
                    this.Add(newcityEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion cityEOList
}
