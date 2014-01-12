using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class countryData : SEOBaseData<country>
    {
        #region Overrides

        public override List<country> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.countrySelectAll().ToList();
            }
        }

        public override country Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.countrySelectById(id).SingleOrDefault();
            }
        }

        public override void Delete(seowebappDataContextDataContext db, int id)
        {
            db.countryDelete(id);
        }

        #endregion Overrides

        #region Insert

        public int Insert(string connectionString, string countrySname, string countryLname)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Insert(db, countrySname, countryLname);
            }
        }

        public int Insert(seowebappDataContextDataContext db, string countrySname, string countryLname)
        {
            Nullable<int> country_id = 0;

            db.countryInsert(ref country_id, countrySname, countryLname);

            return Convert.ToInt32(country_id);
        }

        #endregion Insert

        #region Update

        public bool Update(string connectionString, int idCountry, string countrySname, string countryLname)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Update(db, idCountry, countrySname, countryLname);
            }
        }

        public bool Update(seowebappDataContextDataContext db, int idCountry, string countrySname, string countryLname)
        {
            int rowsAffected = db.countryUpdate(idCountry, countrySname, countryLname);
            return rowsAffected == 1;
        }

        #endregion Update

    }
}