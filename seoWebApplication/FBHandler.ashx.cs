using seoWebApplication.st.SharkTankDAL.entObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seoWebApplication
{
    /// <summary>
    /// Summary description for FBHandler
    /// </summary>
    public class FBHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var accessToken = context.Request["accessToken"];
            context.Session["AccessToken"] = accessToken;
            var uid = context.Request["uid"];
            context.Session["uid"] = uid;

            
            context.Response.Redirect("/Register.aspx");
             
            
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}