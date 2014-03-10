using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Configuration;
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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = seoWebAppConfiguration.SiteName;

            // Retrieve Page from the query string
            string page = Request.QueryString["Page"];
            if (page == null) page = "1";
            // How many pages of products?
            int howManyPages = 1;
            // pager links format
            string firstPageUrl = "";
            string pagerFormat = "";
            // If browsing a category...

            // Retrieve list of products on department promotion             
            list.DataSource = catalogAccesor.GetProductsOnFrontPromo(page, out howManyPages);
            list.DataBind();

            // have the current page as integer
            int currentPage = Int32.Parse(page);
        }


        protected void R1_ItemCreated(Object Sender, RepeaterItemEventArgs e)
        {
            int i = 0;
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                if (e.Item.ItemIndex % 4 == 0)
                {
                    Literal lblDivStart = (Literal)e.Item.FindControl("lblDivStart");
                    Literal lblDivEnd = (Literal)e.Item.FindControl("lblDivEnd");

                    lblDivStart.Text = "<div class='row-fluid'><div class='span12'><ul class='thumbnails product-list-inline-large'>";
                    i++;
                    if (i == 4)
                    {
                        lblDivEnd.Text = "</ul></div></div>";
                        i = 0;
                    }
                }

            }
        }

    }

}