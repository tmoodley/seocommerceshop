using Facebook;
using FBConnectAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace seoWebApplication
{
    public partial class myaccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string apiKey = "221557484648265";
            string appSecret = "8ac6218fe86a9bcd78ccb8ac4ba09e6c";
            FBConnectAuthentication auth = new FBConnectAuthentication(apiKey, appSecret);
            if (auth.Validate() != ValidationState.Valid)
            {
                // The request does not contain the details of a valid Facebook connect session - you'll probably want to throw an error here.

            }
            else
            {
                FBConnectSession fbSession = auth.GetSession();
                string userId = fbSession.UserID;
                string sessionKey = fbSession.SessionKey;
                Session["sessionKey"] = sessionKey;
                Session["userId"] = userId;

                lblMessage.Text = userId;

                // These values can now be used to communicate with Facebook on behalf of your user - perhaps using the Facebook Developer Toolkit
                // The expiry time and session secret is also available.
            }
        }
    }
}