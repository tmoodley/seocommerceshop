using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class zoneData : SEOBaseData<zone>
    {
        #region Overrides

        public override List<zone> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.zoneSelectAll().ToList();
            }
        }

        public override zone Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.zoneSelectById(id).SingleOrDefault();
            }
        }

        public override void Delete(seowebappDataContextDataContext db, int id)
        {
            db.zoneDelete(id);
        }

        #endregion Overrides

        #region Insert

        public int Insert(string connectionString, int idCity, string zoneName)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Insert(db, idCity, zoneName);
            }
        }

        public int Insert(seowebappDataContextDataContext db, int idCity, string zoneName)
        {
            Nullable<int> zone_id = 0;

            db.zoneInsert(ref zone_id, idCity, zoneName);

            return Convert.ToInt32(zone_id);
        }

        #endregion Insert

        #region Update

        public bool Update(string connectionString, int idZone, int idCity, string zoneName)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Update(db, idZone, idCity, zoneName);
            }
        }

        public bool Update(seowebappDataContextDataContext db, int idZone, int idCity, string zoneName)
        {
            int rowsAffected = db.zoneUpdate(idZone, idCity, zoneName);
            return rowsAffected == 1;
        }

        #endregion Update

    }
}