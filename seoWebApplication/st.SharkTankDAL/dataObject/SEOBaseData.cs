using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Configuration;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public abstract class SEOBaseData<T> where T : ISEOBaseEntity
    {
        private const string CONNECTION_STRING_KEY = "SeoWebAppConnString";
        
        public abstract List<T> Select();

        public abstract T Select(int id);



        public abstract void Delete(seowebappDataContextDataContext db, int id);

        public void Delete(string connectionString, int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(connectionString))
            {
                Delete(db, id);
            }
        }

        #region Common Functions

        //protected static bool IsDuplicate(seowebappDataContextDataContext db, string tableName, string fieldName,
        //    string fieldNameId, string value, int id)
        //{            
        //    string sql =
        //        "SELECT COUNT(" + fieldNameId + ") AS DuplicateCount " +
        //          "FROM " + tableName +
        //        " WHERE " + fieldName + " = {0}" +
        //          " AND " + fieldNameId + " <> {1}";

        //    var result = db.ExecuteQuery<DuplicateCheck>(sql, new object[] { value, id });

        //    List<DuplicateCheck> list = result.ToList();

        //    return (list[0].DuplicateCount > 0);
        //}

        //protected static bool IsDuplicate(seowebappDataContextDataContext db, string tableName, string fieldName,
        //    string fieldNameId, DateTime value, int id)
        //{
        //    string sql =
        //        "SELECT COUNT(" + fieldNameId + ") AS DuplicateCount " +
        //          "FROM " + tableName +
        //        " WHERE " + fieldName + " = {0}" +
        //          " AND " + fieldNameId + " <> {1}";

        //    var result = db.ExecuteQuery<DuplicateCheck>(sql, new object[] { value, id });

        //    List<DuplicateCheck> list = result.ToList();

        //    return (list[0].DuplicateCount > 0);
        }

        #endregion Common Functions

    
}
