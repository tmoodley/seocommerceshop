using System;
using System.Data;
using System.Configuration;
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
using System.Collections.Specialized;

namespace seoWebApplication.st.SharkTankDAL
{
    public class commonClasses 
    {
        public static int GetId()
        {
            //Decrypt the query string
            
            NameValueCollection queryString = DecryptQueryString(System.Web.HttpContext.Current.Request.QueryString.ToString());

            if (queryString == null)
            {
                return 0;
            }
            else
            {
                //Check if the id was passed in.
                string id = queryString["id"];

                if ((id == null) || (id == "0"))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(id);
                }
            }
        }

        public bool GetNewPage()
        {
            //Decrypt the query string
            NameValueCollection queryString = DecryptQueryString(System.Web.HttpContext.Current.Request.QueryString.ToString());

            if (queryString == null)
            {
                return false;
            }
            else
            {
                //Check if the id was passed in.
                string value = queryString["newRec"];

                if ((value == null) || (value == "0"))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static int GetP_order_id()
        {
            //Decrypt the query string
            NameValueCollection queryString = DecryptQueryString(System.Web.HttpContext.Current.Request.QueryString.ToString());

            if (queryString == null)
            {
                return 0;
            }
            else
            {
                //Check if the id was passed in.
                string value = queryString["p_order_id"];

                if ((value == null) || (value == "0"))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(value);
                }
            }
        }

        public static NameValueCollection DecryptQueryString(string queryString)
        {
            return StringHelpers.DecryptQueryString(queryString);
        }

        public static string EncryptQueryString(NameValueCollection queryString)
        {
            return StringHelpers.EncryptQueryString(queryString);
        }

        
    }
}