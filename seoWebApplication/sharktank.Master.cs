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
using sharktank.st.SharkTankBLL.Framework;

namespace sharktank
{
    public partial class sharktank : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ENTUserAccountEO currentUser = ((BasePage)Page).CurrentUser;

            //Set the top menu properties
            MenuTabs1.MenuItems = Globals.GetMenuItems(this.Cache);
            MenuTabs1.RootPath = BasePage.RootPath(Context);
            MenuTabs1.CurrentMenuItemName = ((BasePage)Page).MenuItemName();
            MenuTabs1.UserAccount = currentUser;

            //Set the side menu properties
            MenuTree1.MenuItems = Globals.GetMenuItems(this.Cache);
            MenuTree1.RootPath = BasePage.RootPath(Context);
            MenuTree1.CurrentMenuItemName = ((BasePage)Page).MenuItemName();
            MenuTree1.UserAccount = currentUser;

            lblCurrentUser.Text = Page.User.Identity.Name;
            lblCurrentDateTime.Text = DateTime.Now.ToString();

            //Set the version
            lblVersion.Text = ConfigurationManager.AppSettings["version"].ToString();
        }
    }
}
