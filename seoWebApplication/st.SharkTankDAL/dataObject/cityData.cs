using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class cityData : SEOBaseData<city>
    {
        #region Overrides

        public override List<city> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.citySelectAll().ToList();
            }
        }

        public override city Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.citySelectById(id).SingleOrDefault();
            }
        }

        public override void Delete(seowebappDataContextDataContext db, int id)
        {
            db.cityDelete(id);
        }

        #endregion Overrides

        #region Insert

        public int Insert(string connectionString, int idState, string city)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Insert(db, idState, city);
            }
        }

        public int Insert(seowebappDataContextDataContext db, int idState, string city)
        {
            Nullable<int> city_id = 0;

            db.cityInsert(ref city_id, idState, city);

            return Convert.ToInt32(city_id);
        }

        #endregion Insert

        #region Update

        public bool Update(string connectionString, int idCity, int idState, string city)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Update(db, idCity, idState, city);
            }
        }

        public bool Update(seowebappDataContextDataContext db, int idCity, int idState, string city)
        {
            int rowsAffected = db.cityUpdate(idCity, idState, city);
            return rowsAffected == 1;
        }

        #endregion Update

    }
}