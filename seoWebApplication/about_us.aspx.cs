using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace seoWebApplication
{
    public partial class about_us : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Set the title of the page
            this.Title = "About" + seoWebAppConfiguration.SiteName;
            this.lblSiteName.Text = seoWebAppConfiguration.SiteName;
        }
    }
}