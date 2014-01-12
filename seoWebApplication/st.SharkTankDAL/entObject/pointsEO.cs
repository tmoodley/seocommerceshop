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
    #region pointsEO

    [Serializable()]
    public class pointsEO : SEOBaseEO
    {
        #region Properties

        public Nullable<int> webstore_id { get; set; }
        public string Name { get; set; }
        public string ConversionRate { get; set; }
        public Nullable<int> Point { get; set; }
        public decimal Percentage { get; set; }
        public bool Active { get; set; }

        #endregion Properties

        #region Overrides

        public override bool Load(int id)
        {            
            //Get the entity object from the DAL.
           
            points points = new pointsData().Select(dBHelper.GetWebstoreId());
            MapEntityToProperties(points);
            return points != null;        
        }

        protected override void MapEntityToCustomProperties(ISEOBaseEntity entity)
        {
            points points = (points)entity;

            ID = points.points_id;
            webstore_id = points.webstore_id;
            Name = points.Name;
            ConversionRate = points.ConversionRate;
            Point = Convert.ToInt32(points.Point1);
            Percentage = Convert.ToDecimal(points.Percentage);
            Active = Convert.ToBoolean(points.Active);
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
                        ID = new pointsData().Insert(db, webstore_id, Name, ConversionRate, Point, Percentage, Active);

                    }
                    else
                    {
                        //Update
                        if (!new pointsData().Update(db, ID, webstore_id, Name, ConversionRate, Point, Percentage, Active))
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
            pointsData pointsData = new pointsData();

            //name is required.
            if (Name.Trim().Length == 0)
            {
                validationErrors.Add("The Name is required.");
            }

            
        }

        protected override void DeleteForReal(seowebappDataContextDataContext db)
        {
            if (DBAction == DBActionEnum.Delete)
            {
                new pointsData().Delete(db, ID);
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
            Active = true;
            webstore_id = dBHelper.GetWebstoreId();
        }

        protected override string GetDisplayText()
        {
            throw new NotImplementedException();
        }

        #endregion Overrides

        internal static int checkEntry()
        {
            try
            {
                points points = new pointsData().Select(dBHelper.GetWebstoreId());
                return points.points_id;
            }
            catch
            {
                return 0;
            }
                   
        }

        internal static decimal getPointPercentage()
        {
            try
            {
                points points = new pointsData().Select(dBHelper.GetWebstoreId());
                return Convert.ToDecimal(points.Percentage);
            }
            catch
            {
                return Convert.ToInt32(0);
            }
           
        }

        internal static string getPointName()
        {
            try
            {
                points points = new pointsData().Select(dBHelper.GetWebstoreId());
                return Convert.ToString(points.Name);
            }
            catch
            {
                return null;
            }
           
        }

        internal static int getPointMultiplier()
        {
            try
            {
                points points = new pointsData().Select(dBHelper.GetWebstoreId());
                return Convert.ToInt32(points.Point1);
            }
            catch
            {
                return Convert.ToInt32(0);
            }
            
           
        } 
        
    }

    #endregion pointsEO

    #region pointsEOList

    [Serializable()]
    public class pointsEOList : SEOBaseEOList<pointsEO>
    {
        #region Overrides

        public override void Load()
        {
            LoadFromList(new pointsData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<points> pointss)
        {
            if (pointss.Count > 0)
            {
                foreach (points points in pointss)
                {
                    pointsEO newpointsEO = new pointsEO();
                    newpointsEO.MapEntityToProperties(points);
                    this.Add(newpointsEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion pointsEOList
}
