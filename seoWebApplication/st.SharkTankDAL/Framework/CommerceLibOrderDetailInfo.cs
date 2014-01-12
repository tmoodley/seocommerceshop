using System;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Collections.Generic;
using System.Web.Profile;
using System.Web.Security;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.entObject;
using seoWebApplication.st.SharkTankDAL.Framework;
using seoWebApplication.st.SharkTankDAL.dataObject;
using System.Linq;
using System.Web;

namespace seoWebApplication.st.SharkTankDAL.Framework
{
    public class CommerceLibOrderDetailInfo
    {
        public int OrderID;
        public int ProductID;
        public string ProductName;
        public int Quantity;
        public double UnitCost;
        public string ItemAsString;

        public double Subtotal
        {
            get
            {
                return Quantity * UnitCost;
            }
        }
        public CommerceLibOrderDetailInfo(DataRow orderDetailRow)
        {
            OrderID = Int32.Parse(orderDetailRow["OrderID"].ToString());
            ProductID = Int32.Parse(orderDetailRow["product_id"].ToString());
            ProductName = orderDetailRow["ProductName"].ToString();
            Quantity = Int32.Parse(orderDetailRow["Quantity"].ToString());
            UnitCost = Double.Parse(orderDetailRow["UnitCost"].ToString());
            // set info property
            Refresh();
        }
        public void Refresh()
        {
            ItemAsString = Quantity.ToString() + " " + ProductName + ", $" +
            UnitCost.ToString() + " each, total cost $" + Subtotal.ToString();
        }


      public static List<CommerceLibOrderDetailInfo> GetOrderDetails(string orderId)
        {
            // use existing method for DataTable
            DataTable orderDetailsData = OrdersAccessor.GetDetails(orderId);

            // create List<>
            List<CommerceLibOrderDetailInfo> orderDetails =
            new List<CommerceLibOrderDetailInfo>(
            orderDetailsData.Rows.Count);
            foreach (DataRow orderDetail in orderDetailsData.Rows)
            {
                orderDetails.Add(
                new CommerceLibOrderDetailInfo(orderDetail));
            }
            return orderDetails;
        }
    }

}