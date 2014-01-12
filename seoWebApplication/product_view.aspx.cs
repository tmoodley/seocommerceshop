using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.Framework; 

namespace seoWebApplication
{
    public partial class product_view : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve product_id from the query string
            string product_id = Request.QueryString["product_id"];
            if (product_id == null)
            { 
            product_id = HttpContext.Current.Request.Form["product_id"];
                
            }

            string id = HttpContext.Current.Request.Form["id2"];
            if (id != null)
            { 
             if (id.Equals("add"))
            {
                AddToCartButton_Click();
                Response.Redirect("~/ShoppingCart.aspx");
            }
            }
            else
            {
            // Retrieves product details
            ProductDetails pd = catalogAccesor.GetProductDetails(product_id);
            // Does the product exist?
            if (pd.name != null)
            {
                PopulateControls(pd);
            }
            else
            {
                Server.Transfer("~/NotFound.aspx");
            }
            // 301 redirect to the proper URL if necessary
            //Linkor.CheckProductUrl(Request.QueryString["product_id"]);
            }
           

            
           
            
        }
        // Fill the control with data
        private void PopulateControls(ProductDetails pd)
        {
        // Display product recommendations
        string productId = pd.product_id.ToString();
        //recommendations.LoadProductRecommendations(productId);
    
        //recommendations.LoadProductRecommendations(productId); 
        //load the product attributes
        this.ProductCustomAttributes1.LoadProductAttributes(Convert.ToInt32(productId));
        this.ProductAttributes1.LoadProductAttributes(Convert.ToInt32(productId));
        this.ProductAttributesRadio1.LoadProductAttributesRadio(Convert.ToInt32(productId));
      
        // Display product details
        titleLabel.Text = pd.name;
        descriptionLabel.Text = pd.description;
        priceLabel.Text += String.Format("{0:c}", pd.price);
        productImage.ImageUrl = "ProductImages/" + pd.image;
        // Set the title of the page
        this.Title = seoWebAppConfiguration.SiteName + " " + pd.name;

        using (var dc = new seowebappDataContextDataContext())
        {
          var list =  dc.AttributeSelectByWId(dBHelper.GetWebstoreId());
        }
           

        }

        protected void AddToCartButton2_Click()
        {
            AddToCartButton_Click();
        }

        protected void AddToCartButton_Click()
        {
            // Retrieve ProductID from the query string
            string productId = Request.QueryString["id2"];
            // Retrieves product details
            ProductDetails pd = catalogAccesor.GetProductDetails(productId);
            // Retrieve the selected product options'
            string temp;
            temp = HttpContext.Current.Request.Form["ProductAttributes1$ctl05"];
            string options = "";
            //add dropdown attributes
            foreach (Control cnt in this.ProductAttributes1.Controls)
            {  
                if (cnt is PlaceHolder)
                {
                    PlaceHolder placeHolder1 = (PlaceHolder)ProductAttributes1.FindControl("attrPlaceHolder");

                    foreach (Control cnt2 in placeHolder1.Controls)
                    {
                        if (cnt2 is Literal)
                        {
                            Literal attrLabel = (Literal)cnt2;
                            if (!attrLabel.Text.Contains("<"))
                            { 
                            options += attrLabel.Text;
                            }
                            
                        }
                        if (cnt2 is DropDownList)
                        {
                            DropDownList attrDropDown = (DropDownList)cnt2;
                            options += attrDropDown.Items[attrDropDown.SelectedIndex] + "; ";
                        }
                    }
                
                }
            }

            //add radio attributes
            foreach (Control cnt in this.ProductAttributesRadio1.Controls)
            {
                if (cnt is PlaceHolder)
                {
                    PlaceHolder placeHolder1 = (PlaceHolder)ProductAttributesRadio1.FindControl("attrPlaceHolderRadio");

                    foreach (Control cnt2 in placeHolder1.Controls)
                    {
                        if (cnt2 is Literal)
                        {
                            Literal attrLabel = (Literal)cnt2;
                            if (!attrLabel.Text.Contains("<"))
                            {
                                options += attrLabel.Text;
                            }

                        }
                        if (cnt2 is RadioButtonList)
                        {
                            RadioButtonList attrDropDown = (RadioButtonList)cnt2;
                            options += attrDropDown.Items[attrDropDown.SelectedIndex] + "; ";
                        }
                    }

                }
            }

            //add radio attributes
            foreach (Control cnt in this.ProductCustomAttributes1.Controls)
            {
                if (cnt is PlaceHolder)
                {
                    PlaceHolder placeHolder1 = (PlaceHolder)ProductCustomAttributes1.FindControl("attrPlaceHolder");

                    foreach (Control cnt2 in placeHolder1.Controls)
                    {
                        if (cnt2 is Literal)
                        {
                            Literal attrLabel = (Literal)cnt2;
                            if (!attrLabel.Text.Contains("<"))
                            {
                                options += attrLabel.Text;
                            }

                        }
                        if (cnt2 is DropDownList)
                        {
                            DropDownList attrDropDown = (DropDownList)cnt2;
                            options += attrDropDown.Items[attrDropDown.SelectedIndex] + "; ";
                        }
                    }

                }
            }

            options += temp;
            // The Add to Cart link
            // Add the product to the shopping cart
            ShoppingCartAccess.AddItem(productId, options);
        }

        protected void AddToCartButton2_Click(object sender, EventArgs e)
        {
            // Retrieve product_id from the query string
            string product_id = Request.QueryString["product_id"];
            if (product_id == null)
            {
                product_id = HttpContext.Current.Request.Form["product_id"];
            }
            // Retrieves product details
            ProductDetails pd = catalogAccesor.GetProductDetails(product_id);
            // Retrieve the selected product options'
            string temp;
            temp = HttpContext.Current.Request.Form["ProductAttributes1$ctl05"];
            string options = "";
            //add dropdown attributes
            foreach (Control cnt in this.ProductAttributes1.Controls)
            {
                if (cnt is PlaceHolder)
                {
                    PlaceHolder placeHolder1 = (PlaceHolder)ProductAttributes1.FindControl("attrPlaceHolder");

                    foreach (Control cnt2 in placeHolder1.Controls)
                    {
                        if (cnt2 is Literal)
                        {
                            Literal attrLabel = (Literal)cnt2;
                            if (!attrLabel.Text.Contains("<"))
                            {
                                options += attrLabel.Text;
                            }

                        }
                        if (cnt2 is DropDownList)
                        {
                            DropDownList attrDropDown = (DropDownList)cnt2;
                            options += attrDropDown.Items[attrDropDown.SelectedIndex] + "; ";
                        }
                    }

                }
            }

            //add radio attributes
            foreach (Control cnt in this.ProductAttributesRadio1.Controls)
            {
                if (cnt is PlaceHolder)
                {
                    PlaceHolder placeHolder1 = (PlaceHolder)ProductAttributesRadio1.FindControl("attrPlaceHolderRadio");

                    foreach (Control cnt2 in placeHolder1.Controls)
                    {
                        if (cnt2 is Literal)
                        {
                            Literal attrLabel = (Literal)cnt2;
                            if (!attrLabel.Text.Contains("<"))
                            {
                                options += attrLabel.Text;
                            }

                        }
                        if (cnt2 is RadioButtonList)
                        {
                            RadioButtonList attrDropDown = (RadioButtonList)cnt2;
                            options += attrDropDown.Items[attrDropDown.SelectedIndex] + "; ";
                        }
                    }

                }
            }

            //add radio attributes
            foreach (Control cnt in this.ProductCustomAttributes1.Controls)
            {
                if (cnt is PlaceHolder)
                {
                    PlaceHolder placeHolder1 = (PlaceHolder)ProductCustomAttributes1.FindControl("attrPlaceHolder");

                    foreach (Control cnt2 in placeHolder1.Controls)
                    {
                        if (cnt2 is Literal)
                        {
                            Literal attrLabel = (Literal)cnt2;
                            if (!attrLabel.Text.Contains("<"))
                            {
                                options += attrLabel.Text;
                            }

                        }
                        if (cnt2 is DropDownList)
                        {
                            DropDownList attrDropDown = (DropDownList)cnt2;
                            options += attrDropDown.Items[attrDropDown.SelectedIndex] + "; ";
                        }
                    }

                }
            }

            options += temp;
            // The Add to Cart link
            // Add the product to the shopping cart
            ShoppingCartAccess.AddItem(product_id, options);
        }
}

 
}
   
