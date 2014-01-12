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

namespace seoWebApplication
{
    public partial class OrderVerify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Set the title of the page
            this.Title = seoWebAppConfiguration.SiteName +
            " : Verify Order";
            if (!Convert.ToBoolean(Session["User"]))
            {
                Response.Redirect("login.aspx");
            }
            // populate the control only on the initial page load
            if (!IsPostBack)
                PopulateControls(0);
        }

        // fill shopping cart controls with data
        private void PopulateControls(int points)
        {
            // get the items in the shopping cart
            DataTable dt = ShoppingCartAccess.GetItems();
            // populate the list with the shopping cart contents
            grid.DataSource = dt;
            grid.DataBind();
            grid.Visible = true;
            // display the total amount
            decimal amount = ShoppingCartAccess.GetTotalAmount();
            totalAmountLabel.Text = String.Format("{0:c}", amount);    
            // check customer details

          

              //get customer id
            int custId;
            custId = new customerEO().getUserId(Session["UserName"].ToString());

            int pointsAvail = customerEO.getTotalPoints(custId);
            //load total customer points
            lblPoints.Text = pointsAvail.ToString();

            int nwPnts = Convert.ToInt32(0);
            decimal newPoints = Convert.ToDecimal(0);

            decimal appliedPoints = Convert.ToDecimal(0);
            decimal pointMultiplier = Decimal.Round(pointsEO.getPointMultiplier(), 2);
            if (points > 0)
            {
                //check if points to apply is less than points available
                if (points > pointsAvail)
                {
                    points = pointsAvail;
                    txtPoints.Text = points.ToString();
                    
                }
                
                appliedPoints = points / pointMultiplier;
                lblPointsApplied.Text = Decimal.Round(appliedPoints, 2).ToString();
                lblNewTotal.Text = Decimal.Round((amount -appliedPoints), 2).ToString();
                  
            }
            else
            {
                lblPointsApplied.Text = Decimal.Round(0, 2).ToString();
                lblNewTotal.Text = Decimal.Round((amount), 2).ToString();

                newPoints = Convert.ToDecimal(amount * pointsEO.getPointPercentage()); 
                nwPnts = Convert.ToInt32(newPoints * pointsEO.getPointMultiplier()); 
            }

            if(appliedPoints>0)
            {
                nwPnts = 0;
            }

            

            //load Points Name Message
            lblOrderPointsMsg.Text = "This order will get " + nwPnts.ToString() + " " + pointsEO.getPointName();

            //load points name 
            lblPointName.Text = pointsEO.getPointName() + ": ";
  
          

            // Populate shipping selection

            //using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            //{
            //    this.ddlShippingDetails.DataSource = db.getShippingRegionByUsername(Session["UserName"].ToString(), Convert.ToInt32(dBHelper.GetWebstoreId()));
            //    this.ddlShippingDetails.DataTextField = "ShippingType";
            //    this.ddlShippingDetails.DataValueField = "ShippingID";
            //    this.ddlShippingDetails.DataBind();
            //}  
             
        }
 

        protected void updateButton_Click(object sender, EventArgs e)
        {
            // Number of rows in the GridView
            int rowsCount = grid.Rows.Count;
            // Will store a row of the GridView
            GridViewRow gridRow;
            // Will reference a quantity TextBox in the GridView
            TextBox quantityTextBox;
            // Variables to store product ID and quantity
            string productId;
            int quantity;
            // Was the update successful?
            bool success = true;
            // Go through the rows of the GridView
            for (int i = 0; i < rowsCount; i++)
            {
            // Get a row
            gridRow = grid.Rows[i];
            // The ID of the product being deleted
            productId = grid.DataKeys[i].Value.ToString();
            // Get the quantity TextBox in the Row
            quantityTextBox = (TextBox)gridRow.FindControl("editQuantity");
            // Get the quantity, guarding against bogus values
            if (Int32.TryParse(quantityTextBox.Text, out quantity))
            {
                // Update product quantity
                success = success && ShoppingCartAccess.UpdateItem(productId, quantity);
            }
            else
            {
                // if TryParse didn't succeed
                success = false;
            }
            // Display status message
            statusLabel.Text = success ?
            "Your shopping cart was successfully updated!" :
            "Some quantity updates failed! Please verify your cart!";
            }
            // Repopulate the control
            PopulateControls(0);
        }

        protected void placeOrderButton_Click(object sender, EventArgs e)
        {
            string cartId;
            cartId = new ShoppingCartEO().shoppingCartId;

            int custId;
            custId = new customerEO().getUserId(Session["UserName"].ToString());

            //string shippingRegion;
            //shippingRegion = new customerEO().getShippingId(Session["UserName"].ToString());

            //int shippingId;
            //shippingId = new ShippingRegionEO().getShippingId(shippingRegion);

            decimal shippingAmount;
            shippingAmount = Convert.ToDecimal(ddlShippingDetails.SelectedValue.ToString());
           
            // display the total amount
            
             decimal amount = Convert.ToDecimal(lblPointsApplied.Text);
            //decimal amount = ShoppingCartAccess.GetTotalAmount();

            

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

            amount += shippingAmount;

            // Create the order and store the order ID
            int orderId = new OrdersEO().CreateOrder(cartId, custId, 9, 1, amount);

            //update cart total
            OrdersEO.updateOrderTotal(cartId, Convert.ToDecimal(lblNewTotal.Text), Convert.ToInt32(txtPoints.Text));
           
            // Redirect to the conformation page
            Response.Redirect("Checkout.aspx");

             
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //get points to use and update order total
            int pointsToUse = Convert.ToInt32(txtPoints.Text);

            //update controls
            PopulateControls(pointsToUse);
        }

         
        }
    }

