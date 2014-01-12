using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.entObject;
using seoWebApplication.st.SharkTankDAL.Framework;

namespace seoWebApplication
{
    public partial class Checkout : System.Web.UI.Page
    {
        private const string VIEW_STATE_KEY_customer = "customer";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Set the title of the page
            this.Title = seoWebAppConfiguration.SiteName +
            " : Check Out";
            if (!Convert.ToBoolean(Session["User"]))
            {
                Response.Redirect("login.aspx");
            }
            // populate the control only on the initial page load
            if (!IsPostBack)
                // Set the title of the page
                this.Title = seoWebAppConfiguration.SiteName +
                " : Check Out";
            LoadScreenFromObject();
                PopulateControls();
        }

        // fill shopping cart controls with data
        private void PopulateControls()
        {  
            // display the total amount
            decimal amount = ShoppingCartAccess.GetTotalAmount();
            totalAmountLabel.Text = String.Format("{0:c}", amount);    
            // check customer details

           
             
             
 
        }

        protected void LoadScreenFromObject()
        {
            customerEO customer = new customerEO();

            customer.Load(new customerEO().getUserId(Session["UserName"].ToString()));

            txtfname.Text = Convert.ToString(customer.fname + ' ' + Convert.ToString(customer.lname));
  
            txtaddress1.Text = Convert.ToString(customer.address1);

            txtaddress2.Text = Convert.ToString(customer.address2);

            txtcity.Text = Convert.ToString(customer.city);
             
            ddlRegion.Items.Insert(0, new ListItem(customer.region.ToString(), "0"));
            ddlRegion.SelectedIndex = 0;
             

            txtzip.Text = Convert.ToString(customer.zip);

            ddlCountries.Items.Insert(0, new ListItem(customer.country.ToString(), "0"));
            ddlCountries.SelectedIndex = 0; 

            //txtshippingRegion.Text = Convert.ToString(customer.shippingRegion);

            //txtdayPhone.Text = Convert.ToString(customer.dayPhone);

            //txtcellPhone.Text = Convert.ToString(customer.cellPhone);

            //txtevePhone.Text = Convert.ToString(customer.evePhone);

            //txtcreditCard.Text = Convert.ToString(customer.creditCard);

            //string shippingRegion;
            //shippingRegion = new customerEO().getShippingId(Session["UserName"].ToString());

            //int shippingId;
            //shippingId = new ShippingRegionEO().getShippingId(shippingRegion);

            //decimal shippingAmount;
            //shippingAmount = new ShippingEO().GetShippingCost(shippingId, dBHelper.GetWebstoreId());

            //lblShipping.Text = String.Format("{0:c}", shippingAmount);

            lblShipping.Text = String.Format("{0:c}", 0);

            string cartId;
            cartId = new ShoppingCartEO().shoppingCartId;

            // display the total amount
            decimal amount = OrdersEO.getOrderTotal(cartId);

            //amount += shippingAmount;

            lblTotal.Text = String.Format("{0:c}", amount);  
            //Put the object in the view state so it can be attached back to the data context.
            ViewState[VIEW_STATE_KEY_customer] = customer;
        }
         

        protected void placeOrderButton_Click(object sender, EventArgs e)
        { 

            string cartId;
            cartId = new ShoppingCartEO().shoppingCartId;

            // display the total amount
            decimal amount = OrdersEO.getOrderTotal(cartId);
               
            int custId;
            custId = new customerEO().getUserId(Session["UserName"].ToString());

            //string shippingRegion;
            //shippingRegion = new customerEO().getShippingId(Session["UserName"].ToString());
               
            //int shippingId;
            //shippingId = new ShippingRegionEO().getShippingId(shippingRegion);
            
            //decimal shippingAmount;
            //shippingAmount = new ShippingEO().GetShippingCost(shippingId,dBHelper.GetWebstoreId());

            //amount += shippingAmount;

            // Get tax ID or default to "No tax"
            
            //int taxId;
            //switch (shippingRegion)
            //{
            //    case "2":
            //        taxId = 1;
            //        break;
            //    default:
            //        taxId = 2;
            //        break;
            //} 
            // Update Order
            int completed = new OrdersEO().CompleteOrder(cartId, true, txtfname.Text.ToString(), Session["UserName"].ToString(), txtaddress1.Text.ToString(), custId, 1, "1234".ToString(), "good".ToString(), 1, 9, amount);

            decimal newPoints = Convert.ToDecimal(amount * pointsEO.getPointPercentage());

            int nwPnts = Convert.ToInt32(newPoints * pointsEO.getPointMultiplier());

            int orderPoints = OrdersEO.getOrderPoints(cartId);

            nwPnts += orderPoints;
             
            //REMOVE COOKIE
            resetCookie();

            int orderId = new OrdersEO().getOrderIdByCartId(cartId);

            //check if reward points are being used
            if (orderPoints >= 0)
            {
                // Update reward points with new points
                customerEO.updateTotalPoints(custId, nwPnts);
            }
            else
            {
                // Update reward points with actual customer order points
                customerEO.updateTotalPoints(custId, 0);
            }

            // Process order
            OrderProcessor processor = new OrderProcessor(orderId);
            processor.Process();

            // Redirect to the conformation page
            Response.Redirect("OrderPlaced.aspx");

             
        }

        public void resetCookie()
        {
            // get the current HttpContext
            HttpContext context = HttpContext.Current;
            // try to retrieve the cart ID from the user cookie
            //string cart_id = System.Web.HttpContext.Current.Request.Cookies["SeoWebApp_cart_id"].Value;
            string cart_id;
            HttpCookie myCookie = HttpContext.Current.Request.Cookies["SeoWebApp_cart_id"];
            cart_id = "";
            // generate a new GUID
            cart_id = Guid.NewGuid().ToString();
            // create the cookie object and set its value
            HttpCookie cookie = new HttpCookie("SeoWebApp_cart_id", cart_id);
            // set the cookie's expiration date
            int howManyDays = seoWebAppConfiguration.CartPersistDays;
            DateTime currentDate = DateTime.Now;
            TimeSpan timeSpan = new TimeSpan(howManyDays, 0, 0, 0);
            DateTime expirationDate = currentDate.Add(timeSpan);
            cookie.Expires = expirationDate;
            // set the cookie on the client's browser
            context.Response.Cookies.Add(cookie);
        }

         
        }
    }

