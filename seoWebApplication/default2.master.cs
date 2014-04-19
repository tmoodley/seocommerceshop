using seoWebApplication.Data;
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

namespace seoWebApplication
{
    public partial class _default2 : System.Web.UI.MasterPage
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

        protected void Page_Load(object sender, EventArgs e)
        {  
            webstoreId = seoWebAppConfiguration.IdWebstore;

            SeoWebAppEntities db = new SeoWebAppEntities();
            var store = (from ws in db.webstores where ws.webstore_id == webstoreId select ws).FirstOrDefault();
            var idCity = store.city;
            var city = (from ws in db.cities where ws.idCity == idCity select ws).FirstOrDefault();
            storeName = store.webstoreName;
            seoDesc = store.seoDescription + " at "+ storeName;
            seoKeywords = store.seoKeywords + " at " + storeName;
            seoTitle = store.seoTitle;
            address = store.address;
            city2 = city.city1;
            phone = Convert.ToInt32(store.ownerNumber);
            imgLogo = store.image;
            url = HttpContext.Current.Request.Url.AbsoluteUri;
            host = HttpContext.Current.Request.Url.Host;

            if (imgLogo == null) {
                imgLogo = "";
            }
            if (Session["User"] == null)
            {
                loggedIn = false;
            }
            else
            {
                loggedIn = true;
            }
 
            


        }
    }
}
