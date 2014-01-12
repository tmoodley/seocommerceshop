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
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication
{
    public partial class adminMstr : System.Web.UI.MasterPage
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Session["AdminUser"]))
            {
                Response.Redirect("Adminlogin.aspx");
            }
            else
            {
                lblCurrentUser.Text = Session["AdminUserName"].ToString();
                lblCurrentDateTime.Text = DateTime.Now.ToString();
                //Set the version
                lblVersion.Text = ConfigurationManager.AppSettings["version"].ToString();
            }
           
        }

        public ENTValidationErrors ValidationErrors
        {
            get
            {
                return ValidationErrorMessages1.ValidationErrors;
            }

            set
            {
                ValidationErrorMessages1.ValidationErrors = value;
            }
        }   
    }
}