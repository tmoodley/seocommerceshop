using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text; 
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    #region OrdersEO

    [Serializable()]
    public class OrdersEO  
    {
        #region Properties

        public int OrderID { get; set; }
        public int webstore_id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateShipped { get; set; }
        public bool Verified { get; set; }
        public bool Completed { get; set; }
        public bool Canceled { get; set; }
        public string Comments { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string ShippingAddress { get; set; }
        public int CustomerID { get; set; }
        public Nullable<int> Status { get; set; }
        public string AuthCode { get; set; }
        public string Reference { get; set; }
        public Nullable<int> TaxID { get; set; }
        public Nullable<int> ShippingID { get; set; }
        public decimal total { get; set; }
        public string cart_id { get; set; }
        public int point { get; set; }
        #endregion Properties

        #region Overrides

        public bool Load(int id)
        {            
            //Get the entity object from the DAL.
            Order orders = new OrdersData().Select(id);
            MapEntityToProperties(orders);
            return orders != null;        
        }

        private bool LoadByCartId(string cartID)
        {
            //Get the entity object from the DAL.
            Order orders = new OrdersData().getOrderByCartId(cartID);
            MapEntityToProperties(orders);
            return orders != null;  
        }

        public void MapEntityToProperties(Order entity)
        {
            Order orders = (Order)entity;
             
            OrderID = orders.OrderID;
            webstore_id = orders.webstore_id;
            DateCreated = Convert.ToDateTime(orders.DateCreated);
            DateShipped = Convert.ToDateTime(orders.DateShipped);
            Verified = orders.Verified;
            Completed = orders.Completed;
            Canceled = orders.Canceled;
            Comments = orders.Comments;
            CustomerName = orders.CustomerName;
            CustomerEmail = orders.CustomerEmail;
            ShippingAddress = orders.ShippingAddress;
            CustomerID = Convert.ToInt32(orders.CustomerID);
            Status = orders.Status;
            AuthCode = orders.AuthCode;
            Reference = orders.Reference;
            TaxID = orders.TaxID;
            ShippingID = orders.ShippingID;
            total = Convert.ToDecimal(orders.total);
            cart_id = orders.cart_id;
            point = Convert.ToInt32(orders.points);
        }

        public bool Save(bool newrec)
        {
            if (newrec)
            {
              
                //Add
                OrderID = new OrdersData().Insert(webstore_id, DateCreated, DateShipped, Verified, Completed, Canceled, Comments, CustomerName, CustomerEmail, ShippingAddress, CustomerID, Status, AuthCode, Reference, TaxID, ShippingID, total, cart_id, point);
                  
            }
            else
            {

                if (!new OrdersData().Update(OrderID, webstore_id, DateCreated, DateShipped, Verified, Completed, Canceled, Comments, CustomerName, CustomerEmail, ShippingAddress, CustomerID, Status, AuthCode, Reference, TaxID, ShippingID,total,cart_id, point))
                        {
                            
                            return false;
                        }
                   
            }

            return true;


        }

        public int CreateOrder(string cartID, int CustomerID, int shippingId, int taxId, decimal total)
        { 
            return new OrdersData().CREATEORDER(cartID, CustomerID, taxId, shippingId, total);
        }

        public int CompleteOrder(string cartID, bool completed, string customerName, string customerEmail, string shippingAddress, int customerID, int status, string authCode, string reference, int taxID, int shippingID, decimal total)
        {
            return new OrdersData().COMPLETEORDER(cartID, completed, customerName, customerEmail, shippingAddress, customerID, status, authCode, reference, taxID, shippingID, total);
        }

        public int getOrderIdByCartId(string cartID)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                Order order = new OrdersData().getOrderByCartId(cartID);
                return Convert.ToInt32(order.OrderID);
            }
        }

        public void updateOrderPoints(int orderId, int points)
        {
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                new OrdersData().updateOrderPoints(orderId, points); 
            }
        }

        public double CalculateTax(int orderId)
        {
            int taxId;

            //Get the entity object from the DAL.
            Order orders = new OrdersData().Select(orderId);
            taxId = Convert.ToInt32(orders.TaxID);

            double taxPer;
            
            Tax tax = new TaxData().Select(taxId, dBHelper.GetWebstoreId());
            taxPer = tax.TaxPercentage;

            //get total cost
            List<OrderDetail> orderDetails = new OrderDetailData().SelectByOid(orderId);

            // calculate shipping costs???
            double TotalCost;
            TotalCost = 0.0;
            if (orderDetails.Count > 0)
            {
               
                foreach (OrderDetail OrderDetail in orderDetails)
                {
                    TotalCost +=  Convert.ToDouble(OrderDetail.Subtotal);
                }
                double taxAmount = Math.Round(Convert.ToDouble(TotalCost) * taxPer, MidpointRounding.AwayFromZero) / 100.0;
                return taxAmount;
            }
            else
            { 
            return 0;
            }


            
            
        }

        public double getTotal(int orderId)
        {  
            //Get the entity object from the DAL.
            Order orders = new OrdersData().Select(orderId); 
             
            //get total cost
            List<OrderDetail> orderDetails = new OrderDetailData().SelectByOid(orderId);

            // calculate shipping costs???
            double TotalCost;
            TotalCost = 0.0;
            if (orderDetails.Count > 0)
            { 
                foreach (OrderDetail OrderDetail in orderDetails)
                {
                    TotalCost += Convert.ToDouble(OrderDetail.Subtotal);
                }

                return TotalCost;
            }
            else
            {
                return 0;
            }
        }

        internal static void updateOrderTotal(string cartID, decimal orderTotal, int orderPoints)
        {
            OrdersEO orders = new OrdersEO();
            orders.LoadByCartId(cartID);
            orders.total = orderTotal;
            orders.point = orderPoints*-1;
            orders.DateShipped = DateTime.Now;
            orders.Save(false);
        }

        internal static int getOrderPoints(string cartID)
        {
            OrdersEO orders = new OrdersEO();
            orders.LoadByCartId(cartID);
            return orders.point; 
        }

        internal static decimal getOrderTotal(string cartID)
        {
            OrdersEO orders = new OrdersEO();
            orders.LoadByCartId(cartID);
            return orders.total;
        }

       
  
         
         

        #endregion Overrides
    }

    #endregion OrdersEO

    #region OrdersEOList

    [Serializable()]
    public class OrdersEOList : List<OrdersEO>
    {
        #region Overrides

        public void LoadVerified()
        {
            LoadFromList(new OrdersData().SelectVerifiedWid(dBHelper.GetWebstoreId()));
        }   

        public void Load()
        {
            LoadFromList(new OrdersData().SelectWid(dBHelper.GetWebstoreId()));
        }   

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<Order> orderss)
        {
            if (orderss.Count > 0)
            {
                foreach (Order orders in orderss)
                {
                    OrdersEO newOrdersEO = new OrdersEO();
                    newOrdersEO.MapEntityToProperties(orders);
                    this.Add(newOrdersEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion OrdersEOList
}
