using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class webstoreData : SEOBaseData<webstore>
    {
        #region Overrides

        public override List<webstore> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.webstoreSelectAll().ToList();
            }
        }

        public override webstore Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.webstoreSelectById(id).SingleOrDefault();
            }
        }

        public override void Delete(seowebappDataContextDataContext db, int id)
        {
            db.webstoreDelete(id);
        }

        #endregion Overrides

        #region Insert

        public int Insert(string connectionString, string webstoreName, string webstoreUrl, string locationx, string locationy, string polygonArray, string address, Nullable<int> city, Nullable<int> state, Nullable<int> country, string zip, Nullable<int> zone, Nullable<int> parentWebstoreId, string email, string ownerFName, string ownerName, Nullable<int> ownerNumber, string managerFname, string managerLname, Nullable<int> managerNumber, Nullable<int> storeNumber, string apiKey, bool monday, bool monBreakfast, bool monLunch, bool monDinner, string monBreakfastStart, string monBreakfastEnd, string monLunchStart, string monLunchEnd, string monDinnerStart, string monDinnerEnd, bool tuesday, bool tuesBreakfast, bool tuesLunch, bool tuesDinner, string tueBreakfastStart, string tueBreakfastEnd, string tueLunchStart, string tueLunchEnd, string tueDinnerStart, string tueDinnerEnd, bool wednesday, bool wedBreakfast, bool wedLunch, bool wedDinner, string wedBreakfastStart, string wedBreakfastEnd, string wedLunchStart, string wedLunchEnd, string wedDinnerStart, string wedDinnerEnd, bool thursday, bool thrBreakfast, bool thrLunch, bool thrDinner, string thrBreakfastStart, string thrBreakfastEnd, string thrLunchStart, string thrLunchEnd, string thrDinnerStart, string thrDinnerEnd, bool friday, bool friBreakfast, bool friLunch, bool friDinner, string friBreakfastStart, string friBreakfastEnd, string friLunchStart, string friLunchEnd, string friDinnerStart, string friDinnerEnd, bool saturday, bool satBreakfast, bool satLunch, bool satDinner, string satBreakfastStart, string satBreakfastEnd, string satLunchStart, string satLunchEnd, string satDinnerStart, string satDinnerEnd, bool sunday, bool sunBreakfast, bool sunLunch, bool sunDinner, string sunBreakfastStart, string sunBreakfastEnd, string sunLunchStart, string sunLunchEnd, string sunDinnerStart, string sunDinnerEnd, string thumbnail, string image, string seoDescription, string seoTitle, string seoKeywords, string seoMeta)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Insert(db, webstoreName, webstoreUrl, locationx, locationy, polygonArray, address, city, state, country, zip, zone, parentWebstoreId, email, ownerFName, ownerName, ownerNumber, managerFname, managerLname, managerNumber, storeNumber, apiKey, monday, monBreakfast, monLunch, monDinner, monBreakfastStart, monBreakfastEnd, monLunchStart, monLunchEnd, monDinnerStart, monDinnerEnd, tuesday, tuesBreakfast, tuesLunch, tuesDinner, tueBreakfastStart, tueBreakfastEnd, tueLunchStart, tueLunchEnd, tueDinnerStart, tueDinnerEnd, wednesday, wedBreakfast, wedLunch, wedDinner, wedBreakfastStart, wedBreakfastEnd, wedLunchStart, wedLunchEnd, wedDinnerStart, wedDinnerEnd, thursday, thrBreakfast, thrLunch, thrDinner, thrBreakfastStart, thrBreakfastEnd, thrLunchStart, thrLunchEnd, thrDinnerStart, thrDinnerEnd, friday, friBreakfast, friLunch, friDinner, friBreakfastStart, friBreakfastEnd, friLunchStart, friLunchEnd, friDinnerStart, friDinnerEnd, saturday, satBreakfast, satLunch, satDinner, satBreakfastStart, satBreakfastEnd, satLunchStart, satLunchEnd, satDinnerStart, satDinnerEnd, sunday, sunBreakfast, sunLunch, sunDinner, sunBreakfastStart, sunBreakfastEnd, sunLunchStart, sunLunchEnd, sunDinnerStart, sunDinnerEnd, thumbnail, image, seoDescription, seoTitle, seoKeywords, seoMeta);
            }
        }

        public int Insert(seowebappDataContextDataContext db, string webstoreName, string webstoreUrl, string locationx, string locationy, string polygonArray, string address, Nullable<int> city, Nullable<int> state, Nullable<int> country, string zip, Nullable<int> zone, Nullable<int> parentWebstoreId, string email, string ownerFName, string ownerName, Nullable<int> ownerNumber, string managerFname, string managerLname, Nullable<int> managerNumber, Nullable<int> storeNumber, string apiKey, bool monday, bool monBreakfast, bool monLunch, bool monDinner, string monBreakfastStart, string monBreakfastEnd, string monLunchStart, string monLunchEnd, string monDinnerStart, string monDinnerEnd, bool tuesday, bool tuesBreakfast, bool tuesLunch, bool tuesDinner, string tueBreakfastStart, string tueBreakfastEnd, string tueLunchStart, string tueLunchEnd, string tueDinnerStart, string tueDinnerEnd, bool wednesday, bool wedBreakfast, bool wedLunch, bool wedDinner, string wedBreakfastStart, string wedBreakfastEnd, string wedLunchStart, string wedLunchEnd, string wedDinnerStart, string wedDinnerEnd, bool thursday, bool thrBreakfast, bool thrLunch, bool thrDinner, string thrBreakfastStart, string thrBreakfastEnd, string thrLunchStart, string thrLunchEnd, string thrDinnerStart, string thrDinnerEnd, bool friday, bool friBreakfast, bool friLunch, bool friDinner, string friBreakfastStart, string friBreakfastEnd, string friLunchStart, string friLunchEnd, string friDinnerStart, string friDinnerEnd, bool saturday, bool satBreakfast, bool satLunch, bool satDinner, string satBreakfastStart, string satBreakfastEnd, string satLunchStart, string satLunchEnd, string satDinnerStart, string satDinnerEnd, bool sunday, bool sunBreakfast, bool sunLunch, bool sunDinner, string sunBreakfastStart, string sunBreakfastEnd, string sunLunchStart, string sunLunchEnd, string sunDinnerStart, string sunDinnerEnd, string thumbnail, string image, string seoDescription, string seoTitle, string seoKeywords, string seoMeta)
        {
            Nullable<int> webstore_id = 0;

            db.webstoreInsert(ref webstore_id, webstoreName, webstoreUrl, locationx, locationy, polygonArray, address, city, state, country, zip, zone, parentWebstoreId, email, ownerFName, ownerName, ownerNumber, managerFname, managerLname, managerNumber, storeNumber, apiKey, monday, monBreakfast, monLunch, monDinner, monBreakfastStart, monBreakfastEnd, monLunchStart, monLunchEnd, monDinnerStart, monDinnerEnd, tuesday, tuesBreakfast, tuesLunch, tuesDinner, tueBreakfastStart, tueBreakfastEnd, tueLunchStart, tueLunchEnd, tueDinnerStart, tueDinnerEnd, wednesday, wedBreakfast, wedLunch, wedDinner, wedBreakfastStart, wedBreakfastEnd, wedLunchStart, wedLunchEnd, wedDinnerStart, wedDinnerEnd, thursday, thrBreakfast, thrLunch, thrDinner, thrBreakfastStart, thrBreakfastEnd, thrLunchStart, thrLunchEnd, thrDinnerStart, thrDinnerEnd, friday, friBreakfast, friLunch, friDinner, friBreakfastStart, friBreakfastEnd, friLunchStart, friLunchEnd, friDinnerStart, friDinnerEnd, saturday, satBreakfast, satLunch, satDinner, satBreakfastStart, satBreakfastEnd, satLunchStart, satLunchEnd, satDinnerStart, satDinnerEnd, sunday, sunBreakfast, sunLunch, sunDinner, sunBreakfastStart, sunBreakfastEnd, sunLunchStart, sunLunchEnd, sunDinnerStart, sunDinnerEnd, thumbnail, image, seoDescription, seoTitle, seoKeywords, seoMeta);

            return Convert.ToInt32(webstore_id);
        }

        #endregion Insert

        #region Update

        public bool Update(string connectionString, int webstore_id, string webstoreName, string webstoreUrl, string locationx, string locationy, string polygonArray, string address, Nullable<int> city, Nullable<int> state, Nullable<int> country, string zip, Nullable<int> zone, Nullable<int> parentWebstoreId, string email, string ownerFName, string ownerName, Nullable<int> ownerNumber, string managerFname, string managerLname, Nullable<int> managerNumber, Nullable<int> storeNumber, string apiKey, bool monday, bool monBreakfast, bool monLunch, bool monDinner, string monBreakfastStart, string monBreakfastEnd, string monLunchStart, string monLunchEnd, string monDinnerStart, string monDinnerEnd, bool tuesday, bool tuesBreakfast, bool tuesLunch, bool tuesDinner, string tueBreakfastStart, string tueBreakfastEnd, string tueLunchStart, string tueLunchEnd, string tueDinnerStart, string tueDinnerEnd, bool wednesday, bool wedBreakfast, bool wedLunch, bool wedDinner, string wedBreakfastStart, string wedBreakfastEnd, string wedLunchStart, string wedLunchEnd, string wedDinnerStart, string wedDinnerEnd, bool thursday, bool thrBreakfast, bool thrLunch, bool thrDinner, string thrBreakfastStart, string thrBreakfastEnd, string thrLunchStart, string thrLunchEnd, string thrDinnerStart, string thrDinnerEnd, bool friday, bool friBreakfast, bool friLunch, bool friDinner, string friBreakfastStart, string friBreakfastEnd, string friLunchStart, string friLunchEnd, string friDinnerStart, string friDinnerEnd, bool saturday, bool satBreakfast, bool satLunch, bool satDinner, string satBreakfastStart, string satBreakfastEnd, string satLunchStart, string satLunchEnd, string satDinnerStart, string satDinnerEnd, bool sunday, bool sunBreakfast, bool sunLunch, bool sunDinner, string sunBreakfastStart, string sunBreakfastEnd, string sunLunchStart, string sunLunchEnd, string sunDinnerStart, string sunDinnerEnd, string thumbnail, string image, string seoDescription, string seoTitle, string seoKeywords, string seoMeta)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Update(db, webstore_id, webstoreName, webstoreUrl, locationx, locationy, polygonArray, address, city, state, country, zip, zone, parentWebstoreId, email, ownerFName, ownerName, ownerNumber, managerFname, managerLname, managerNumber, storeNumber, apiKey, monday, monBreakfast, monLunch, monDinner, monBreakfastStart, monBreakfastEnd, monLunchStart, monLunchEnd, monDinnerStart, monDinnerEnd, tuesday, tuesBreakfast, tuesLunch, tuesDinner, tueBreakfastStart, tueBreakfastEnd, tueLunchStart, tueLunchEnd, tueDinnerStart, tueDinnerEnd, wednesday, wedBreakfast, wedLunch, wedDinner, wedBreakfastStart, wedBreakfastEnd, wedLunchStart, wedLunchEnd, wedDinnerStart, wedDinnerEnd, thursday, thrBreakfast, thrLunch, thrDinner, thrBreakfastStart, thrBreakfastEnd, thrLunchStart, thrLunchEnd, thrDinnerStart, thrDinnerEnd, friday, friBreakfast, friLunch, friDinner, friBreakfastStart, friBreakfastEnd, friLunchStart, friLunchEnd, friDinnerStart, friDinnerEnd, saturday, satBreakfast, satLunch, satDinner, satBreakfastStart, satBreakfastEnd, satLunchStart, satLunchEnd, satDinnerStart, satDinnerEnd, sunday, sunBreakfast, sunLunch, sunDinner, sunBreakfastStart, sunBreakfastEnd, sunLunchStart, sunLunchEnd, sunDinnerStart, sunDinnerEnd, thumbnail, image, seoDescription, seoTitle, seoKeywords, seoMeta);
            }
        }

        public bool Update(seowebappDataContextDataContext db, int webstore_id, string webstoreName, string webstoreUrl, string locationx, string locationy, string polygonArray, string address, Nullable<int> city, Nullable<int> state, Nullable<int> country, string zip, Nullable<int> zone, Nullable<int> parentWebstoreId, string email, string ownerFName, string ownerName, Nullable<int> ownerNumber, string managerFname, string managerLname, Nullable<int> managerNumber, Nullable<int> storeNumber, string apiKey, bool monday, bool monBreakfast, bool monLunch, bool monDinner, string monBreakfastStart, string monBreakfastEnd, string monLunchStart, string monLunchEnd, string monDinnerStart, string monDinnerEnd, bool tuesday, bool tuesBreakfast, bool tuesLunch, bool tuesDinner, string tueBreakfastStart, string tueBreakfastEnd, string tueLunchStart, string tueLunchEnd, string tueDinnerStart, string tueDinnerEnd, bool wednesday, bool wedBreakfast, bool wedLunch, bool wedDinner, string wedBreakfastStart, string wedBreakfastEnd, string wedLunchStart, string wedLunchEnd, string wedDinnerStart, string wedDinnerEnd, bool thursday, bool thrBreakfast, bool thrLunch, bool thrDinner, string thrBreakfastStart, string thrBreakfastEnd, string thrLunchStart, string thrLunchEnd, string thrDinnerStart, string thrDinnerEnd, bool friday, bool friBreakfast, bool friLunch, bool friDinner, string friBreakfastStart, string friBreakfastEnd, string friLunchStart, string friLunchEnd, string friDinnerStart, string friDinnerEnd, bool saturday, bool satBreakfast, bool satLunch, bool satDinner, string satBreakfastStart, string satBreakfastEnd, string satLunchStart, string satLunchEnd, string satDinnerStart, string satDinnerEnd, bool sunday, bool sunBreakfast, bool sunLunch, bool sunDinner, string sunBreakfastStart, string sunBreakfastEnd, string sunLunchStart, string sunLunchEnd, string sunDinnerStart, string sunDinnerEnd, string thumbnail, string image, string seoDescription, string seoTitle, string seoKeywords, string seoMeta)
        {
            int rowsAffected = db.webstoreUpdate(webstore_id, webstoreName, webstoreUrl, locationx, locationy, polygonArray, address, city, state, country, zip, zone, parentWebstoreId, email, ownerFName, ownerName, ownerNumber, managerFname, managerLname, managerNumber, storeNumber, apiKey, monday, monBreakfast, monLunch, monDinner, monBreakfastStart, monBreakfastEnd, monLunchStart, monLunchEnd, monDinnerStart, monDinnerEnd, tuesday, tuesBreakfast, tuesLunch, tuesDinner, tueBreakfastStart, tueBreakfastEnd, tueLunchStart, tueLunchEnd, tueDinnerStart, tueDinnerEnd, wednesday, wedBreakfast, wedLunch, wedDinner, wedBreakfastStart, wedBreakfastEnd, wedLunchStart, wedLunchEnd, wedDinnerStart, wedDinnerEnd, thursday, thrBreakfast, thrLunch, thrDinner, thrBreakfastStart, thrBreakfastEnd, thrLunchStart, thrLunchEnd, thrDinnerStart, thrDinnerEnd, friday, friBreakfast, friLunch, friDinner, friBreakfastStart, friBreakfastEnd, friLunchStart, friLunchEnd, friDinnerStart, friDinnerEnd, saturday, satBreakfast, satLunch, satDinner, satBreakfastStart, satBreakfastEnd, satLunchStart, satLunchEnd, satDinnerStart, satDinnerEnd, sunday, sunBreakfast, sunLunch, sunDinner, sunBreakfastStart, sunBreakfastEnd, sunLunchStart, sunLunchEnd, sunDinnerStart, sunDinnerEnd, thumbnail, image, seoDescription, seoTitle, seoKeywords, seoMeta);
            return rowsAffected == 1;
        }

        #endregion Update

    }
}