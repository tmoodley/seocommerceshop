using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class UserAccountData : ENTBaseData<UserAccount>
    {
        #region Overrides

        public override List<UserAccount> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.UserAccountSelectAll().ToList();
            }
        }

        public UserAccount Login(string email)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.UserAccountSelectByWIdEmail(dBHelper.GetWebstoreId(),email).SingleOrDefault();
            }
        }

        public override UserAccount Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.UserAccountSelectById(id,dBHelper.GetWebstoreId()).SingleOrDefault();
            }
        }

        public override void Delete(seowebappDataContextDataContext db, int id)
        {
            db.UserAccountDelete(id);
        }

        #endregion Overrides

        #region Insert

        public int Insert(string connectionString, bool isActive, string accountName, string firstName, string lastName, string email, string password, int webstore_id, int insertENTUserAccountId)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Insert(db, isActive, accountName, firstName, lastName, email, password, webstore_id, insertENTUserAccountId);
            }
        }

        public int Insert(seowebappDataContextDataContext db, bool isActive, string accountName, string firstName, string lastName, string email, string password, int webstore_id, int insertENTUserAccountId)
        {
            Nullable<int> userAccountId = 0;

            db.UserAccountInsert(ref userAccountId, isActive, accountName, firstName, lastName, email, password, webstore_id, insertENTUserAccountId);

            return Convert.ToInt32(userAccountId);
        }

        #endregion Insert

        #region Update

        public bool Update(string connectionString, int userAccountId, bool isActive, string accountName, string firstName, string lastName, string email, string password, int webstore_id, int updateENTUserAccountId, Binary version)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                return Update(db, userAccountId, isActive, accountName, firstName, lastName, email, password, webstore_id, updateENTUserAccountId, version);
            }
        }

        public bool Update(seowebappDataContextDataContext db, int userAccountId, bool isActive, string accountName, string firstName, string lastName, string email, string password, int webstore_id, int updateENTUserAccountId, Binary version)
        {
            int rowsAffected = db.UserAccountUpdate(userAccountId, isActive, accountName, firstName, lastName, email, password, webstore_id, updateENTUserAccountId, version);
            return rowsAffected == 1;
        }

        #endregion Update

    }
}