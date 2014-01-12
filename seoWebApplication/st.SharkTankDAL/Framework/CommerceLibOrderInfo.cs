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
    public class CommerceLibOrderInfo
    {
        public int OrderID;
        public string DateCreated;
        public string DateShipped;
        public string Comments;
        public int Status;
        public string AuthCode;
        public string Reference;
        public int Customer; 
        public SecureCard CreditCard;
        public double TotalCost;
        public string OrderAsString;
        public string CustomerAddressAsString;
        public List<CommerceLibOrderDetailInfo> OrderDetails;
        public CommerceLibOrderInfo(DataRow orderRow)
        {
            OrderID = Int32.Parse(orderRow["OrderID"].ToString());
            DateCreated = orderRow["DateCreated"].ToString();
            DateShipped = orderRow["DateShipped"].ToString();
            Comments = orderRow["Comments"].ToString();
            Status = Int32.Parse(orderRow["Status"].ToString());
            AuthCode = orderRow["AuthCode"].ToString();
            Reference = orderRow["Reference"].ToString();
            Customer = new ShoppingCartAccess().getUserId();
            // CreditCard = new SecureCard(CustomerProfile.CreditCard);
            OrderDetails = CommerceLibOrderDetailInfo.GetOrderDetails(orderRow["OrderID"].ToString());
            // set info properties
            Refresh();
        }

        public void Refresh()
        {
            // calculate total cost and set data
            StringBuilder sb = new StringBuilder();
            TotalCost = 0.0;
            foreach (CommerceLibOrderDetailInfo item in OrderDetails)
            {
                sb.AppendLine(item.ItemAsString);
                TotalCost += item.Subtotal;
            }
            sb.AppendLine();
            sb.Append("Total order cost: $");
            sb.Append(TotalCost.ToString());
            OrderAsString = sb.ToString();
            // get customer address string
            sb = new StringBuilder();
            int custId;
            custId = new ShoppingCartAccess().getUserId();
            customerEO customer = new customerEO();

            sb.AppendLine(customer.username);
            sb.AppendLine(customer.address1);
            if (customer.address2 != "")
            {
                sb.AppendLine(customer.address2);
            }
            sb.AppendLine(customer.city);
            sb.AppendLine(customer.region);
            sb.AppendLine(customer.zip);
            sb.AppendLine(customer.country);
            CustomerAddressAsString = sb.ToString();
        }

        public static CommerceLibOrderInfo GetOrder(int orderID)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CommerceLibOrderGetInfo";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@OrderID";
            param.Value = orderID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@webstore_id";
            param.Value = dBHelper.GetWebstoreId();
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // obtain the results
            DataTable table = GenericDataAccessor.ExecuteSelectCommand(comm);
            DataRow orderRow = table.Rows[0];
            // save the results into an CommerceLibOrderInfo object
            CommerceLibOrderInfo orderInfo =
            new CommerceLibOrderInfo(orderRow);
            return orderInfo;
        }
    }
}