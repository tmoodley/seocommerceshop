using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public class OrdersData  
    {
        #region Overrides

        public List<Order> Select()
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.OrdersSelectAll().ToList();
            }
        }

        public Order Select(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.OrdersSelectById(id).SingleOrDefault();
            }
        }

        public List<Order> SelectVerifiedWid(int Wid)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.OrdersVerifiedSelectByWId(Wid).ToList();
            }
        }

        public List<Order> SelectWid(int Wid)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                return db.OrdersSelectByWId(Wid).ToList();
            }
        }

        public void Delete(int id)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
               
                db.OrdersDelete(id);
            }
         
        }

        #endregion Overrides

        #region Insert


        public int Insert(int webstore_id, DateTime dateCreated, DateTime dateShipped, bool verified, bool completed, bool canceled, string comments, string customerName, string customerEmail, string shippingAddress, int customerID, Nullable<int> status, string authCode, string reference, Nullable<int> taxID, Nullable<int> shippingID, decimal total, string cart_id, int point)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                Nullable<int> orderID = 0;

                db.OrdersInsert(ref orderID, webstore_id, dateCreated, dateShipped, verified, completed, canceled, comments, customerName, customerEmail, shippingAddress, customerID, status, authCode, reference, taxID, shippingID, total, cart_id, point);

                return Convert.ToInt32(orderID);
            }

        }

        #endregion Insert

        #region Update


        public bool Update(int orderID, int webstore_id, DateTime dateCreated, DateTime dateShipped, bool verified, bool completed, bool canceled, string comments, string customerName, string customerEmail, string shippingAddress, int customerID, Nullable<int> status, string authCode, string reference, Nullable<int> taxID, Nullable<int> shippingID, decimal total, string cart_id, int point)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                int rowsAffected = db.OrdersUpdate(orderID, webstore_id, dateCreated, dateShipped, verified, completed, canceled, comments, customerName, customerEmail, shippingAddress, customerID, status, authCode, reference, taxID, shippingID,total,cart_id, point);
                return rowsAffected == 1;
            }
        }

        #endregion Update

        #region CREATEORDER


        public int CREATEORDER(string cartID, int customerID, int taxID, int shippingID, decimal total)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                Nullable<int> orderID = 0;
                db.CreateCustomerOrder(ref orderID, cartID, customerID, shippingID, taxID, total,dBHelper.GetWebstoreId());
                return Convert.ToInt32(orderID);
            }
        }
        
        public int COMPLETEORDER(string cartID, bool completed, string customerName, string customerEmail,string shippingAddress,int customerID, int status, string authCode, string reference, int taxID, int shippingID, decimal total)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            { 
               int rowsAffected = db.UpdateCustomerOrderPaid(cartID, completed, customerName, customerEmail, shippingAddress, customerID, status, authCode, reference, taxID, shippingID, total);
               return rowsAffected;
            }
        }

        public Order getOrderByCartId(string cartID)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            { 
                return db.OrdersSelectByCId(cartID).SingleOrDefault();
            }
        }

        public void updateOrderPoints(int orderId, int points)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                db.OrdersUpdatePoints(orderId,points);
            }
        }
        #endregion CREATEORDER

    }
}