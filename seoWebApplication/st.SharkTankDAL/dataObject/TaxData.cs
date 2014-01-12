using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class TaxData  
    {
        #region Overrides

        public List<Tax> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.TaxSelectAll().ToList();
            }
        }

        public Tax Select(int id, int webstore_id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.TaxSelectById(id, webstore_id).SingleOrDefault();
            }
        }

        public void Delete(int id)
        {
        using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                db.TaxDelete(id);
            }
        }
        

        #endregion Overrides

        #region Insert


        public int Insert(Nullable<int> webstore_id, string taxType, double taxPercentage)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                Nullable<int> taxID = 0;

                db.TaxInsert(ref taxID, webstore_id, taxType, taxPercentage);

                return Convert.ToInt32(taxID);
            }

        }
         
        #endregion Insert

        #region Update

        public bool Update(int tax_id, Nullable<int> webstore_id, string taxType, double taxPercentage)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                int rowsAffected = db.TaxUpdate(tax_id, webstore_id, taxType, taxPercentage);
                return rowsAffected == 1;
            }
        }

       

        #endregion Update

    }
}