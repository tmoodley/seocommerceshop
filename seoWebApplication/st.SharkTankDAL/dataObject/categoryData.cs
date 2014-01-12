using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class categoryData  
    {
        #region Overrides

        public List<category> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.categorySelectAll().ToList();
            }
        }

        public category Select(int id, int webstore_id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.categorySelectById(id,webstore_id).SingleOrDefault();
            }
        }

        public static void addProductToCategory(int pid, int cid)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                db.productcategoryInsert(pid, cid);
            }
        }

        public static void delProductToCategory(int pid, int cid)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                db.productcategoryDelete(pid, cid);
            }
        }

        public List<category> SelectByWid(int webstore_id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {  
                return db.categorySelectByWIdws(webstore_id).ToList();
            }
        }

        public void Delete(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                db.categoryDelete(id);
            }
        }
 

        #endregion Overrides

        #region Insert
         

        public int Insert(int department_id, int webstore_id, string name, string description, int insertUser)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                Nullable<int> category_id = 0;

                db.categoryInsert(ref category_id, department_id, webstore_id, name, description, insertUser);

                return Convert.ToInt32(category_id);
            }
        }

        #endregion Insert

        #region Update


        public bool Update(int category_id, int department_id, int webstore_id, string name, string description, int updateUser, Binary version)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                int rowsAffected = db.categoryUpdate(category_id, department_id, webstore_id, name, description, updateUser, version);
                return rowsAffected == 1;
            }
        }

        #endregion Update

    }
}