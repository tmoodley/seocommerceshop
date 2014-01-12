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
    public partial class seowebapp : System.Web.UI.MasterPage
    {
        public bool loggedIn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                loggedIn = false;
            }
            else
            {
                loggedIn = true;
            }

            //if (Convert.ToInt32(Request.QueryString["product_id"]) <= 0)
            //{  
            //    if (LinkMaker.checkDepartment(Request.QueryString["department_id"]) == 0)
            //    { 
            //        Response.Redirect("NotFound.aspx"); 
            //    }
            //}
        }

       
        
        
        //public bool EnforceSSL
        //{
        //    get
        //    {
        //        if (ViewState["enforceSSL"] != null)
        //        {
        //            return (bool)ViewState["enforceSSL"];
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    set
        //    {
        //        ViewState["enforceSSL"] = value;
        //    }
        //}

        //We check on the property this property may be set fairly late in the life cycle of the Master Page, you
        //can’t act on it in OnInit. Instead, you check the value of this property in OnPreRender and redirect
        //protected override void OnPreRender(EventArgs e)
        //{
        //    if (EnforceSSL)
        //    {
        //        if (!Request.IsSecureConnection)
        //        {
        //            Response.Redirect(
        //            Request.Url.AbsoluteUri.ToLower().Replace(
        //            "http://", "https://"), true);
        //        }
        //    }
        //    else if (Request.IsSecureConnection)
        //    {
        //        Response.Redirect(Request.Url.AbsoluteUri.ToLower().Replace(
        //        "https://", "http://"), true);
        //    }
        //}

      
    }
}
