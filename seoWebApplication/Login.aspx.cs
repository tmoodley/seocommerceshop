using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections; 
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL; 
using seoWebApplication.st.SharkTankDAL.entObject;
using Facebook; 
using System.Collections.Generic;

namespace seoWebApplication
{
    public partial class Login : System.Web.UI.Page 
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            
            // set the page title
            this.Title = seoWebAppConfiguration.SiteName + ": Login";

             
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

        }

        //add this to any page that needs ssl...

        //protected override void OnInit(EventArgs e)
        //{
        //    (Master as seowebapp).EnforceSSL = true;
        //    base.OnInit(e);
        //}

        protected bool AuthenticateUser(String strUserName, String strPassword)
        {
  
            try
            {
                 customerEO customer = new customerEO();
                 return customer.Login(strUserName, strPassword);
            }
            catch  
            {
                // Handle an error by displaying the information.
                lblInfo.Text = "Please check the username and password.<br/>";
                //lblInfo.Text += err.Message;
            }

            return false;



        }

        public void OnLogin(Object src, EventArgs e)
        {
            if (AuthenticateUser(m_textboxUserName.Text,
                                 m_textboxPassword.Text))
            {
                Session["User"] = "true";
                Session["UserName"] = m_textboxUserName.Text;
                Response.Redirect("default.aspx");
            }
            else
            {
             
                Session["User"] = "false";
                Response.Write("Invalid login: You don't belong here...");
            }
        }

         

       
    }
}
