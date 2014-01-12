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
    #region webstoreEO

    [Serializable()]
    public class webstoreEO : SEOBaseEO
    {
        #region Properties

        public string webstoreName { get; set; }
        public string webstoreUrl { get; set; }
        public string locationx { get; set; }
        public string locationy { get; set; }
        public string polygonArray { get; set; }
        public string address { get; set; }
        public Nullable<int> city { get; set; }
        public Nullable<int> state { get; set; }
        public Nullable<int> country { get; set; }
        public string zip { get; set; }
        public Nullable<int> zone { get; set; }
        public Nullable<int> parentWebstoreId { get; set; }
        public string email { get; set; }
        public string ownerFName { get; set; }
        public string ownerName { get; set; }
        public Nullable<int> ownerNumber { get; set; }
        public string managerFname { get; set; }
        public string managerLname { get; set; }
        public Nullable<int> managerNumber { get; set; }
        public Nullable<int> storeNumber { get; set; }
        public string apiKey { get; set; }
        public bool monday { get; set; }
        public bool monBreakfast { get; set; }
        public bool monLunch { get; set; }
        public bool monDinner { get; set; }
        public string monBreakfastStart { get; set; }
        public string monBreakfastEnd { get; set; }
        public string monLunchStart { get; set; }
        public string monLunchEnd { get; set; }
        public string monDinnerStart { get; set; }
        public string monDinnerEnd { get; set; }
        public bool tuesday { get; set; }
        public bool tuesBreakfast { get; set; }
        public bool tuesLunch { get; set; }
        public bool tuesDinner { get; set; }
        public string tueBreakfastStart { get; set; }
        public string tueBreakfastEnd { get; set; }
        public string tueLunchStart { get; set; }
        public string tueLunchEnd { get; set; }
        public string tueDinnerStart { get; set; }
        public string tueDinnerEnd { get; set; }
        public bool wednesday { get; set; }
        public bool wedBreakfast { get; set; }
        public bool wedLunch { get; set; }
        public bool wedDinner { get; set; }
        public string wedBreakfastStart { get; set; }
        public string wedBreakfastEnd { get; set; }
        public string wedLunchStart { get; set; }
        public string wedLunchEnd { get; set; }
        public string wedDinnerStart { get; set; }
        public string wedDinnerEnd { get; set; }
        public bool thursday { get; set; }
        public bool thrBreakfast { get; set; }
        public bool thrLunch { get; set; }
        public bool thrDinner { get; set; }
        public string thrBreakfastStart { get; set; }
        public string thrBreakfastEnd { get; set; }
        public string thrLunchStart { get; set; }
        public string thrLunchEnd { get; set; }
        public string thrDinnerStart { get; set; }
        public string thrDinnerEnd { get; set; }
        public bool friday { get; set; }
        public bool friBreakfast { get; set; }
        public bool friLunch { get; set; }
        public bool friDinner { get; set; }
        public string friBreakfastStart { get; set; }
        public string friBreakfastEnd { get; set; }
        public string friLunchStart { get; set; }
        public string friLunchEnd { get; set; }
        public string friDinnerStart { get; set; }
        public string friDinnerEnd { get; set; }
        public bool saturday { get; set; }
        public bool satBreakfast { get; set; }
        public bool satLunch { get; set; }
        public bool satDinner { get; set; }
        public string satBreakfastStart { get; set; }
        public string satBreakfastEnd { get; set; }
        public string satLunchStart { get; set; }
        public string satLunchEnd { get; set; }
        public string satDinnerStart { get; set; }
        public string satDinnerEnd { get; set; }
        public bool sunday { get; set; }
        public bool sunBreakfast { get; set; }
        public bool sunLunch { get; set; }
        public bool sunDinner { get; set; }
        public string sunBreakfastStart { get; set; }
        public string sunBreakfastEnd { get; set; }
        public string sunLunchStart { get; set; }
        public string sunLunchEnd { get; set; }
        public string sunDinnerStart { get; set; }
        public string sunDinnerEnd { get; set; }
        public string thumbnail { get; set; }
        public string image { get; set; }
        public string seoDescription { get; set; }
        public string seoTitle { get; set; }
        public string seoKeywords { get; set; }
        public string seoMeta { get; set; }

        #endregion Properties

        #region Overrides

        public override bool Load(int id)
        {            
            //Get the entity object from the DAL.
            webstore webstore = new webstoreData().Select(id);
            MapEntityToProperties(webstore);
            return webstore != null;        
        }

        protected override void MapEntityToCustomProperties(ISEOBaseEntity entity)
        {
            webstore webstore = (webstore)entity;

            ID = webstore.webstore_id;
            webstoreName = webstore.webstoreName;
            webstoreUrl = webstore.webstoreUrl;
            locationx = webstore.locationx;
            locationy = webstore.locationy;
            polygonArray = webstore.polygonArray;
            address = webstore.address;
            city = webstore.city;
            state = webstore.state;
            country = webstore.country;
            zip = webstore.zip;
            zone = webstore.zone;
            parentWebstoreId = webstore.parentWebstoreId;
            email = webstore.email;
            ownerFName = webstore.ownerFName;
            ownerName = webstore.ownerName;
            ownerNumber = webstore.ownerNumber;
            managerFname = webstore.managerFname;
            managerLname = webstore.managerLname;
            managerNumber = webstore.managerNumber;
            storeNumber = webstore.storeNumber;
            apiKey = webstore.apiKey;
            monday = Convert.ToBoolean(webstore.monday);
            monBreakfast = Convert.ToBoolean(webstore.monBreakfast);
            monLunch = Convert.ToBoolean(webstore.monLunch);
            monDinner = Convert.ToBoolean(webstore.monDinner);
            monBreakfastStart = webstore.monBreakfastStart;
            monBreakfastEnd = webstore.monBreakfastEnd;
            monLunchStart = webstore.monLunchStart;
            monLunchEnd = webstore.monLunchEnd;
            monDinnerStart = webstore.monDinnerStart;
            monDinnerEnd = webstore.monDinnerEnd;
            tuesday = Convert.ToBoolean(webstore.tuesday);
            tuesBreakfast = Convert.ToBoolean(webstore.tuesBreakfast);
            tuesLunch = Convert.ToBoolean(webstore.tuesLunch);
            tuesDinner = Convert.ToBoolean(webstore.tuesDinner);
            tueBreakfastStart = webstore.tueBreakfastStart;
            tueBreakfastEnd = webstore.tueBreakfastEnd;
            tueLunchStart = webstore.tueLunchStart;
            tueLunchEnd = webstore.tueLunchEnd;
            tueDinnerStart = webstore.tueDinnerStart;
            tueDinnerEnd = webstore.tueDinnerEnd;
            wednesday = Convert.ToBoolean(webstore.wednesday);
            wedBreakfast = Convert.ToBoolean(webstore.wedBreakfast);
            wedLunch = Convert.ToBoolean(webstore.wedLunch);
            wedDinner = Convert.ToBoolean(webstore.wedDinner);
            wedBreakfastStart = webstore.wedBreakfastStart;
            wedBreakfastEnd = webstore.wedBreakfastEnd;
            wedLunchStart = webstore.wedLunchStart;
            wedLunchEnd = webstore.wedLunchEnd;
            wedDinnerStart = webstore.wedDinnerStart;
            wedDinnerEnd = webstore.wedDinnerEnd;
            thursday = Convert.ToBoolean(webstore.thursday);
            thrBreakfast = Convert.ToBoolean(webstore.thrBreakfast);
            thrLunch = Convert.ToBoolean(webstore.thrLunch);
            thrDinner = Convert.ToBoolean(webstore.thrDinner);
            thrBreakfastStart = webstore.thrBreakfastStart;
            thrBreakfastEnd = webstore.thrBreakfastEnd;
            thrLunchStart = webstore.thrLunchStart;
            thrLunchEnd = webstore.thrLunchEnd;
            thrDinnerStart = webstore.thrDinnerStart;
            thrDinnerEnd = webstore.thrDinnerEnd;
            friday = Convert.ToBoolean(webstore.friday);
            friBreakfast = Convert.ToBoolean(webstore.friBreakfast);
            friLunch = Convert.ToBoolean(webstore.friLunch);
            friDinner = Convert.ToBoolean(webstore.friDinner);
            friBreakfastStart = webstore.friBreakfastStart;
            friBreakfastEnd = webstore.friBreakfastEnd;
            friLunchStart = webstore.friLunchStart;
            friLunchEnd = webstore.friLunchEnd;
            friDinnerStart = webstore.friDinnerStart;
            friDinnerEnd = webstore.friDinnerEnd;
            saturday = Convert.ToBoolean(webstore.saturday);
            satBreakfast = Convert.ToBoolean(webstore.satBreakfast);
            satLunch = Convert.ToBoolean(webstore.satLunch);
            satDinner = Convert.ToBoolean(webstore.satDinner);
            satBreakfastStart = webstore.satBreakfastStart;
            satBreakfastEnd = webstore.satBreakfastEnd;
            satLunchStart = webstore.satLunchStart;
            satLunchEnd = webstore.satLunchEnd;
            satDinnerStart = webstore.satDinnerStart;
            satDinnerEnd = webstore.satDinnerEnd;
            sunday = Convert.ToBoolean(webstore.sunday);
            sunBreakfast = Convert.ToBoolean(webstore.sunBreakfast);
            sunLunch = Convert.ToBoolean(webstore.sunLunch);
            sunDinner = Convert.ToBoolean(webstore.sunDinner);
            sunBreakfastStart = webstore.sunBreakfastStart;
            sunBreakfastEnd = webstore.sunBreakfastEnd;
            sunLunchStart = webstore.sunLunchStart;
            sunLunchEnd = webstore.sunLunchEnd;
            sunDinnerStart = webstore.sunDinnerStart;
            sunDinnerEnd = webstore.sunDinnerEnd;
            thumbnail = webstore.thumbnail;
            image = webstore.image;
            seoDescription = webstore.seoDescription;
            seoTitle = webstore.seoTitle;
            seoKeywords = webstore.seoKeywords;
            seoMeta = webstore.seoMeta;
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
                        ID = new webstoreData().Insert(db, webstoreName, webstoreUrl, locationx, locationy, polygonArray, address, city, state, country, zip, zone, parentWebstoreId, email, ownerFName, ownerName, ownerNumber, managerFname, managerLname, managerNumber, storeNumber, apiKey, monday, monBreakfast, monLunch, monDinner, monBreakfastStart, monBreakfastEnd, monLunchStart, monLunchEnd, monDinnerStart, monDinnerEnd, tuesday, tuesBreakfast, tuesLunch, tuesDinner, tueBreakfastStart, tueBreakfastEnd, tueLunchStart, tueLunchEnd, tueDinnerStart, tueDinnerEnd, wednesday, wedBreakfast, wedLunch, wedDinner, wedBreakfastStart, wedBreakfastEnd, wedLunchStart, wedLunchEnd, wedDinnerStart, wedDinnerEnd, thursday, thrBreakfast, thrLunch, thrDinner, thrBreakfastStart, thrBreakfastEnd, thrLunchStart, thrLunchEnd, thrDinnerStart, thrDinnerEnd, friday, friBreakfast, friLunch, friDinner, friBreakfastStart, friBreakfastEnd, friLunchStart, friLunchEnd, friDinnerStart, friDinnerEnd, saturday, satBreakfast, satLunch, satDinner, satBreakfastStart, satBreakfastEnd, satLunchStart, satLunchEnd, satDinnerStart, satDinnerEnd, sunday, sunBreakfast, sunLunch, sunDinner, sunBreakfastStart, sunBreakfastEnd, sunLunchStart, sunLunchEnd, sunDinnerStart, sunDinnerEnd, thumbnail, image, seoDescription, seoTitle, seoKeywords, seoMeta);

                    }
                    else
                    {
                        //Update
                        if (!new webstoreData().Update(db, ID, webstoreName, webstoreUrl, locationx, locationy, polygonArray, address, city, state, country, zip, zone, parentWebstoreId, email, ownerFName, ownerName, ownerNumber, managerFname, managerLname, managerNumber, storeNumber, apiKey, monday, monBreakfast, monLunch, monDinner, monBreakfastStart, monBreakfastEnd, monLunchStart, monLunchEnd, monDinnerStart, monDinnerEnd, tuesday, tuesBreakfast, tuesLunch, tuesDinner, tueBreakfastStart, tueBreakfastEnd, tueLunchStart, tueLunchEnd, tueDinnerStart, tueDinnerEnd, wednesday, wedBreakfast, wedLunch, wedDinner, wedBreakfastStart, wedBreakfastEnd, wedLunchStart, wedLunchEnd, wedDinnerStart, wedDinnerEnd, thursday, thrBreakfast, thrLunch, thrDinner, thrBreakfastStart, thrBreakfastEnd, thrLunchStart, thrLunchEnd, thrDinnerStart, thrDinnerEnd, friday, friBreakfast, friLunch, friDinner, friBreakfastStart, friBreakfastEnd, friLunchStart, friLunchEnd, friDinnerStart, friDinnerEnd, saturday, satBreakfast, satLunch, satDinner, satBreakfastStart, satBreakfastEnd, satLunchStart, satLunchEnd, satDinnerStart, satDinnerEnd, sunday, sunBreakfast, sunLunch, sunDinner, sunBreakfastStart, sunBreakfastEnd, sunLunchStart, sunLunchEnd, sunDinnerStart, sunDinnerEnd, thumbnail, image, seoDescription, seoTitle, seoKeywords, seoMeta))
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
            webstoreData webstoreData = new webstoreData();

            //name is required.
            if (webstoreName.Trim().Length == 0)
            {
                validationErrors.Add("The name is required.");
            }

            //name is required.
            if (storeNumber == null)
            {
                validationErrors.Add("The name is required.");
            }
        }

        protected override void DeleteForReal(seowebappDataContextDataContext db)
        {
            if (DBAction == DBActionEnum.Delete)
            {
                new webstoreData().Delete(db, ID);
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
            parentWebstoreId = dBHelper.GetWebstoreId();
        }

        protected override string GetDisplayText()
        {
            throw new NotImplementedException();
        }

        #endregion Overrides
    }

    #endregion webstoreEO

    #region webstoreEOList

    [Serializable()]
    public class webstoreEOList : SEOBaseEOList<webstoreEO>
    {
        #region Overrides

        public override void Load()
        {
            LoadFromList(new webstoreData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<webstore> webstores)
        {
            if (webstores.Count > 0)
            {
                foreach (webstore webstore in webstores)
                {
                    webstoreEO newwebstoreEO = new webstoreEO();
                    newwebstoreEO.MapEntityToProperties(webstore);
                    this.Add(newwebstoreEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion webstoreEOList
}
