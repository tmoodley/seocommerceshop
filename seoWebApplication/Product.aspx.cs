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
using seoWebApplication.Data; 

namespace seoWebApplication
{
    public partial class Product : System.Web.UI.Page
    {
        public bool loggedIn;
        public string storeName;
        public string seoDesc;
        public string seoKeywords;
        public string seoTitle;
        public string imgLogo;
        public int webstoreId;

        public string address;
        public string city2;
        public int phone;
        public string url;
        public string host;
        public string price;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve product_id from the query string
            string product_id = Request.QueryString["product_id"];
            webstoreId = seoWebAppConfiguration.IdWebstore;
            url = seoWebApplication.Linkor.ToProduct(product_id).ToString();
            host = HttpContext.Current.Request.Url.Host;

            SeoWebAppEntities db = new SeoWebAppEntities();
            var store = (from ws in db.webstores where ws.webstore_id == webstoreId select ws).FirstOrDefault();
            var idCity = store.city;
            var city = (from ws in db.cities where ws.idCity == idCity select ws).FirstOrDefault();
            storeName = store.webstoreName;
           
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
        // Fill the control with data
        private void PopulateControls(ProductDetails pd)
        {
        // Display product recommendations
        string productId = pd.product_id.ToString();
        ////recommendations.LoadProductRecommendations(productId);
        //this.ProductRecommendations1.LoadProductRecommendations(productId);
        //load the product attributes
        this.ProductCustomAttributes1.LoadProductAttributes(Convert.ToInt32(productId));
        this.ProductAttributes1.LoadProductAttributes(Convert.ToInt32(productId));
        this.ProductAttributesRadio1.LoadProductAttributesRadio(Convert.ToInt32(productId));
        // Display product details
        titleLabel.Text = pd.name;
        descriptionLabel.Text = pd.description;
        priceLabel.Text += String.Format("{0:c}", pd.price);
        price = String.Format("{0:c}", pd.price);

        string fileName = pd.image;
        if (fileName.Length <= 0)
        {
            fileName = "Coming-Soon.gif";
        }

        productImage.ImageUrl = "ProductImages/" + fileName;
        // Set the title of the page
        this.Title = seoWebAppConfiguration.SiteName + " " + pd.name;
             
        seoDesc = seoWebAppConfiguration.SiteName + " " + pd.name;
        seoKeywords = seoWebAppConfiguration.SiteName + " " + pd.name;
        seoTitle = seoWebAppConfiguration.SiteName + " " + pd.name;
        imgLogo = "/ProductImages/" + fileName; 

        using (var dc = new seowebappDataContextDataContext())
        {
          var list =  dc.AttributeSelectByWId(dBHelper.GetWebstoreId());
        }
           

        }

        protected void AddToCartButton_Click(object sender, EventArgs e)
        {
            // Retrieve ProductID from the query string
            string productId = Request.QueryString["Product_id"];
            // Retrieves product details
            ProductDetails pd = catalogAccesor.GetProductDetails(productId);
            // Retrieve the selected product options
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
            // The Add to Cart link
            // Add the product to the shopping cart
            ShoppingCartAccess.AddItem(productId, options);
            Response.Redirect("/shoppingcart.aspx");
        }
}

 
}
   
