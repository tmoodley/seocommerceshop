using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class AuditData  
    {
        #region Overrides

        public List<Audit> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.AuditSelectAll().ToList();
            }
        }

        public Audit Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.AuditSelectById(id).SingleOrDefault();
            }
        }

        public void Delete(seowebappDataContextDataContext db, int id)
        {
            db.AuditDelete(id);
        }

        #endregion Overrides

        #region Insert

        public int Insert(int orderID, int webstore_id, DateTime dateStamp, string message, Nullable<int> messageNumber)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                Nullable<int> audit_id = 0;
                db.AuditInsert(ref audit_id, orderID, webstore_id, dateStamp, message, messageNumber);
                return Convert.ToInt32(audit_id);
            }
        } 

        #endregion Insert

        #region Update

        public bool Update(int auditID, int orderID, int webstore_id, DateTime dateStamp, string message, Nullable<int> messageNumber)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                int rowsAffected = db.AuditUpdate(auditID, orderID, webstore_id, dateStamp, message, messageNumber);
                return rowsAffected == 1;
            }
        } 

        #endregion Update

    }
}