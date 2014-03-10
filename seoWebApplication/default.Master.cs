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
    public partial class _default : System.Web.UI.MasterPage
    {
        public bool loggedIn;
        public string storeName;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            storeName = seoWebAppConfiguration.SiteName;
            
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
