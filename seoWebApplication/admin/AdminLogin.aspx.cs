using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Configuration;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.Framework;
using System.Text;
using seoWebApplication.st.SharkTankDAL.dataObject; 

namespace seoWebApplication 
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
         
        protected bool AuthenticateUser(String strUserName, String strPassword)
        {

            try
            {
                UserAccountEO userAccount = new UserAccountEO();
                return userAccount.Login(strUserName, strPassword);
            }
            catch
            {
                // Handle an error by displaying the information.
                return false;
            }
             

        }

        public void OnLogin(Object src, EventArgs e)
        {
            if (AuthenticateUser(m_textboxUserName.Text, m_textboxPassword.Text))
            {
                Session["AdminUser"] = "true";
                Session["webstore_id"] = dBHelper.GetWebstoreId();
                Session["AdminUserName"] = m_textboxUserName.Text;
                Session["AdminUserId"] = dBHelper.GetUserId(m_textboxUserName.Text);
                Response.Redirect("default.aspx");
            }
            else
            {
                Response.Write("Invalid login: You don't belong here...");
            }
        }

       

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
