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
using System.Collections.Specialized;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.Framework; 
using System.Text;
using System.Reflection;
using System.Collections.Generic;

namespace seoWebApplication
{
    public abstract class BasePage : System.Web.UI.Page
    {

        #region Constructor

        public BasePage() { }

        #endregion Constructor

        #region Properities

         

        #endregion Properties

        #region Abstract Methods

        public abstract string MenuItemName();

        #endregion Abstract Methods

        #region Public Methods

        /// <summary>
        /// Method returns the base application path.
        /// </summary>
        /// <param name="context">Context object</param>
        /// <returns>Returns the base application path.</returns>
        public static string RootPath(HttpContext context)
        {
            string urlSuffix = context.Request.Url.Authority + context.Request.ApplicationPath;
            return context.Request.Url.Scheme + @":" + "/";

        }

        public static NameValueCollection DecryptQueryString(string queryString)
        {
            return StringHelpers.DecryptQueryString(queryString);
        }

        public static string EncryptQueryString(NameValueCollection queryString)
        {
            return StringHelpers.EncryptQueryString(queryString);
        }

        /// <summary>
        /// You must pass in a string that uses the QueryStringHelper.DELIMITER as the delimiter.
        /// This will also append the "?" to the beginning of the query string.
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static string EncryptQueryString(string queryString)
        {
            return StringHelpers.EncryptQueryString(queryString);
        }

        #endregion Public Methods

        #region Overrides

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        #endregion Overrides


        #region Private Methods

        private void MakeControlsReadOnly(ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Enabled = false;
                }
                else if (c is RadioButton)
                {
                    ((RadioButton)c).Enabled = false;
                }
                else if (c is DropDownList)
                {
                    ((DropDownList)c).Enabled = false;
                }
                else if (c is CheckBox)
                {
                    ((CheckBox)c).Enabled = false;
                }
                else if (c is RadioButtonList)
                {
                    ((RadioButtonList)c).Enabled = false;
                }

                if (c.HasControls())
                {
                    MakeControlsReadOnly(c.Controls);
                }
            }
        }

          public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others  will follow 

                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

          public string sortingOrder
          {
              get
              {
                  if (ViewState["sortingOrder"].ToString() == "desc")
                      ViewState["sortingOrder"] = "asc";
                  else
                      ViewState["sortingOrder"] = "desc";

                  return ViewState["sortingOrder"].ToString();
              }
              set
              {
                  ViewState["sortingOrder"] = value;
              }
          }
    }

        #endregion Private Methods
    }
 
