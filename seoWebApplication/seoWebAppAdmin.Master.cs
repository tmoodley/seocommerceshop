using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using seoWebApplication.st.SharkTankDAL.Framework;

namespace seoWebApplication
{
    public partial class seoWebAppAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ENTUserAccountEO currentUser = ((BasePage)Page).CurrentUser;

            

            //lblCurrentUser.Text = Page.User.Identity.Name;
            lblCurrentDateTime.Text = DateTime.Now.ToString();
           
            //Set the version
            lblVersion.Text = ConfigurationManager.AppSettings["version"].ToString();
        }
    }
}
