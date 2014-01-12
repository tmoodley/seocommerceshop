using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class OrderDetailData  
    {
        #region Overrides

        public List<OrderDetail> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.OrderDetailSelectAll().ToList();
            }
        }

        public OrderDetail Select(int Oid, int Pid)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.OrderDetailSelectByPId(Oid, Pid).SingleOrDefault();
            }
        }

        public List<OrderDetail> SelectByOid(int Oid)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.OrderDetailSelectByWId(Oid).ToList();
            }
        }

        public void Delete(int Oid, int Pid)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                db.OrderDetailDelete(Oid, Pid);
            }
        }

        

        #endregion Overrides

        #region Insert


        public void Insert(int orderID, int product_id, string productName, int quantity, decimal unitCost)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            { 
                db.OrderDetailInsert(orderID, product_id, productName, quantity, unitCost);
                 
            }

        }

      

        #endregion Insert

        #region Update 

        public bool Update(int orderID, int product_id, string productName, int quantity, decimal unitCost)
        { 
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                int rowsAffected = db.OrderDetailUpdate(orderID, product_id, productName, quantity, unitCost);
                return rowsAffected == 1;
            }
        }

       
        #endregion Update

    }
}