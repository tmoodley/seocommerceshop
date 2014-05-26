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
using seoWebApplication.Data;
using System.Collections.Generic;


namespace seoWebApplication
{
    public partial class _Default : System.Web.UI.Page
    {
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
        public string fbUrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = seoWebAppConfiguration.SiteName;

            webstoreId = seoWebAppConfiguration.IdWebstore;

            try
            {
                SeoWebAppEntities db = new SeoWebAppEntities();
                var store = (from ws in db.webstores where ws.webstore_id == webstoreId select ws).FirstOrDefault();
                var idCity = store.city;
                var city = (from ws in db.cities where ws.idCity == idCity select ws).FirstOrDefault();
                storeName = store.webstoreName;
                var socialMedia = (from ws in db.SocialMedias where ws.WebstoreId == webstoreId select ws).FirstOrDefault();
                fbUrl = socialMedia.Facebook;
                storeName = store.webstoreName;
                seoDesc = store.seoDescription + " at " + storeName;
                seoKeywords = store.seoKeywords + " at " + storeName;
                seoTitle = store.seoTitle;
                address = store.address;
                city2 = city.city1;
                phone = Convert.ToInt32(store.ownerNumber);
                imgLogo = store.image;
                url = HttpContext.Current.Request.Url.AbsoluteUri;
                host = HttpContext.Current.Request.Url.Host;

            }
            catch { 
            
            }
            // Retrieve Page from the query string
            string page = Request.QueryString["Page"];
            if (page == null) page = "1";
            // How many pages of products?
            int howManyPages = 1;
            // pager links format
            string firstPageUrl = "";
            string pagerFormat = "";
            // If browsing a category...

            List<seoWebApplication.Data.product> products;
            int wid = dBHelper.GetWebstoreId();
            using (var dc = new SeoWebAppEntities())
            {
                products = (from p in dc.products where p.webstore_id == wid && p.promofront == true select p).Take(4).ToList();
            }
           

            // Retrieve list of products on department promotion             
            list.DataSource = products;
            list.DataBind();

            // have the current page as integer
            int currentPage = Int32.Parse(page);
        }


        protected void R1_ItemCreated(Object Sender, RepeaterItemEventArgs e)
        {
            int i = 0;
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                if (e.Item.ItemIndex % 5 == 0)
                {
                    Literal lblDivStart = (Literal)e.Item.FindControl("lblDivStart");
                    Literal lblDivEnd = (Literal)e.Item.FindControl("lblDivEnd");

                    lblDivStart.Text = "<div class='row-fluid'><div class='span12'><ul class='thumbnails product-list-inline-large'>" + i.ToString();
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