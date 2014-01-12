using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class departmentData : ENTBaseData<department> 
    {
        #region Overrides

        public override List<department> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.departmentSelectAll().ToList();
            }
        }

        public List<department> SelectWid()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.departmentSelectByWIdWs(dBHelper.GetWebstoreId()).ToList();
            }
        }

        public override department Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.departmentSelectById(id, dBHelper.GetWebstoreId()).SingleOrDefault();
            }
        }

        public override void Delete(seowebappDataContextDataContext db, int id)
        {
             
                db.departmentDelete(id);
             
        }
         

        #endregion Overrides

        #region Insert

        public int Insert(int webstore_id, string description, string name, int insertUser)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                Nullable<int> department_id = 0;

                db.departmentInsert(ref department_id, webstore_id, description, name, insertUser);

                return Convert.ToInt32(department_id);
            } 
             
        }

        #endregion Insert

        #region Update

        public bool Update(int department_id, int webstore_id, string description, string name,int updateUser, Binary version)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                int rowsAffected = db.departmentUpdate(department_id, webstore_id, description, name, updateUser, version);
                return rowsAffected == 1;
            }
        }

   
        #endregion Update

    }
}