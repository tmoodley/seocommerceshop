using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    #region OrderDetailEO

    [Serializable()]
    public class OrderDetailEO 
    {
        #region Properties

        public int OrderID { get; set; }
        public int product_id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; } 

        #endregion Properties

        #region Overrides

        public bool Load(int Oid, int Pid)
        {            
            //Get the entity object from the DAL.
            OrderDetail orderDetail = new OrderDetailData().Select(Oid, Pid);
            MapEntityToProperties(orderDetail);
            return orderDetail != null;        
        }
         

        public void MapEntityToProperties(OrderDetail entity)
        {
            OrderDetail orderDetail = (OrderDetail)entity;
             
            OrderID = orderDetail.OrderID;
            product_id = orderDetail.product_id;
            ProductName = orderDetail.ProductName;
            Quantity = orderDetail.Quantity;
            UnitCost = orderDetail.UnitCost;
             
        }

        public bool Save(bool newrec)
        {
            if (newrec)
            {  
                //Add
                 new OrderDetailData().Insert(OrderID, product_id, ProductName, Quantity, UnitCost);
                 
            }
            else
            {

                //Update
                if (!new OrderDetailData().Update(OrderID, product_id, ProductName, Quantity, UnitCost))
                { 
                    return false;
                }
            }

            return true;


        }
        
 

        
        

        #endregion Overrides
    }

    #endregion OrderDetailEO

    #region OrderDetailEOList

    [Serializable()]
    public class OrderDetailEOList : List<OrderDetailEO>
    {
        #region Overrides

        public void Load(int idOrder)
        {
            LoadFromList(new OrderDetailData().SelectByOid(idOrder));
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<OrderDetail> orderDetails)
        {
            if (orderDetails.Count > 0)
            {
                foreach (OrderDetail orderDetail in orderDetails)
                {
                    OrderDetailEO newOrderDetailEO = new OrderDetailEO();
                    newOrderDetailEO.MapEntityToProperties(orderDetail);
                    this.Add(newOrderDetailEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion OrderDetailEOList
}
