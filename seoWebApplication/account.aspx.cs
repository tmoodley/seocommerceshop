using ComputerBeacon.Facebook;
using ComputerBeacon.Facebook.Server;
using Facebook;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace seoWebApplication
{
    public partial class account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string accessToken = Session["AccessToken"].ToString();
            //lblToken.Text = accessToken;
            //try
            //{
            //    // Using IDictionary<string, object> (.Net 3.5, .Net 4.0, WP7)
            //    var client = new FacebookClient(accessToken);
            //    var me = (IDictionary<string, object>)client.Get("me");
            //    string firstName = (string)me["first_name"];
            //    string lastName = (string)me["last_name"];
            //    string email = (string)me["email"];
            //    lblToken.Text = email + " " + lastName + " " + firstName;

            //}
            //catch
            //{

            //}

           
        }
    }
}