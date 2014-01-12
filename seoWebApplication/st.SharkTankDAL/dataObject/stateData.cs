using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class stateData : SEOBaseData<state>
    {
        #region Overrides

        public override List<state> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.stateSelectAll().ToList();
            }
        }

        public override state Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.stateSelectById(id).SingleOrDefault();
            }
        }

        public override void Delete(seowebappDataContextDataContext db, int id)
        {
            db.stateDelete(id);
        }

        #endregion Overrides

        #region Insert

        public int Insert(string connectionString, int idState, string stateSname, string stateLname)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Insert(db, idState, stateSname, stateLname);
            }
        }

        public int Insert(seowebappDataContextDataContext db, int idState, string stateSname, string stateLname)
        {
            Nullable<int> state_id = 0;

            db.stateInsert(ref state_id, stateSname, stateLname);

            return Convert.ToInt32(state_id);
        }

        #endregion Insert

        #region Update

        public bool Update(string connectionString, int idState, string stateSname, string stateLname)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Update(db, idState, stateSname, stateLname);
            }
        }

        public bool Update(seowebappDataContextDataContext db, int idState, string stateSname, string stateLname)
        {
            int rowsAffected = db.stateUpdate(idState, stateSname, stateLname);
            return rowsAffected == 1;
        }

        #endregion Update

    }
}