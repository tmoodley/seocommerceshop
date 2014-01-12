using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.entObject;
using seoWebApplication.st.SharkTankDAL.dataObject;

namespace seoWebApplication
{
    public partial class OrderTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void goButton_Click(object sender, EventArgs e)
        {
            try
            {
                OrdersEO order = new OrdersEO();
                order.Load(Convert.ToInt32(orderIDBox.Text));
                //CommerceLibOrderInfo orderInfo = CommerceLibAccess.GetOrder(orderIDBox.Text);
                resultLabel.Text = "Order found.";
                addressLabel.Text = order.webstore_id.ToString();
                creditCardLabel.Text = order.Status.ToString();
                orderLabel.Text = order.Verified.ToString();
                
            }
            catch
            {
                resultLabel.Text = "No order found, or order is in old format.";
                addressLabel.Text = "";
                creditCardLabel.Text = "";
                orderLabel.Text = "";
            }
        }
    }
}