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


namespace seoWebApplication
{
    public abstract class BaseEditPage<T> : BasePage
    where T : ENTBaseEO, new()
    {
        #region Constructor

        public BaseEditPage() { }

        #endregion Constructor

        #region Properties
        public bool newPage { get; set; }
        #endregion Properties

        #region Virtual Methods

        /// <summary>
        /// Initializes a new edit object and then calls load object from screen.
        /// </summary>
        protected virtual void LoadNew()
        {
            T baseEO = new T();
            baseEO.Init();
            LoadScreenFromObject(baseEO);
        }

        #endregion Methods

        #region Abstract Methods

        /// <summary>
        /// Scrapes the screen and loads the edit object.
        /// </summary>
        /// <param name="baseEO"></param>
        protected abstract void LoadObjectFromScreen(T baseEO);

        /// <summary>
        /// Load the controls on the screen from the object's properties.
        /// </summary>
        /// <param name="baseEO"></param>
        protected abstract void LoadScreenFromObject(T baseEO);

        /// <summary>
        /// Preload the controls such as drop down lists and listboxes.
        /// </summary>
        protected abstract void LoadControls();

        /// <summary>
        /// Navigate the user back the list page.  The cancel button and a successful save should both call this.
        /// </summary>
        protected abstract void GoToGridPage();

        #endregion Abstract Methods

        #region Overrides

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack)
            {
                //Load any list boxes, drop downs, etc.
                LoadControls();

                int id = GetId();

                if (id == 0)
                {
                    LoadNew();
                }
                else
                {
                    T baseEO = new T();
                    baseEO.Load(Convert.ToInt32(id));
                    LoadScreenFromObject(baseEO);
                }

            }
        }

        #endregion Overrides

        #region Methods

        public int GetId()
        {
            //Decrypt the query string
            NameValueCollection queryString = DecryptQueryString(Request.QueryString.ToString());

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
            NameValueCollection queryString = DecryptQueryString(Request.QueryString.ToString());

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

        public int GetP_order_id()
        {
            //Decrypt the query string
            NameValueCollection queryString = DecryptQueryString(Request.QueryString.ToString());

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

        public void loadDdlCat(DropDownList ddl, int Id)
        {

            using (var dc = new seowebappDataContextDataContext())
            {
                ddl.DataSource = dc.categorySelectByWId(dBHelper.GetWebstoreId());
                ddl.DataTextField = "name";
                ddl.DataValueField = "category_id";
                ddl.DataBind();
                if (Id>0)
                {
                    ddl.SelectedValue = Id.ToString();
                }
                
            }
        }

        public void loadDdlDept(DropDownList ddl, int Id)
        {

            using (var dc = new seowebappDataContextDataContext())
            {
                ddl.DataSource = dc.departmentSelectByWId(dBHelper.GetWebstoreId());
                ddl.DataTextField = "name";
                ddl.DataValueField = "department_id";
                ddl.DataBind(); 
                ddl.SelectedValue = Id.ToString();
            }
        }

        public void loadDdlControlType(DropDownList ddl, int Id)
        {

            using (var dc = new seowebappDataContextDataContext())
            {
                ddl.DataSource = dc.controlTypeSelectAll();
                ddl.DataTextField = "controlName";
                ddl.DataValueField = "controlType_id";                
                ddl.DataBind();
                ddl.SelectedValue = Id.ToString();
            }
        }

        public void loadDdlAttribute(DropDownList ddl, int Id, int idAtt)
        { 
            ddl.Items.Clear();

            using (var dc = new seowebappDataContextDataContext())
            {
             
                try
                {
                    ddl.DataSource = dc.AttributeValueSelectByAId(idAtt);
                    ddl.DataTextField = "Value";
                    ddl.DataValueField = "AttributeValueID";
                    ddl.DataBind();
                    if (Id > 0)
                    {
                        ddl.SelectedValue = Id.ToString();
                    }
                }
                catch
                {
                    ddl.DataSource = dc.AttributeValueSelectByAId(idAtt);
                    ddl.DataTextField = "Value";
                    ddl.DataValueField = "AttributeValueID";
                    ddl.DataBind();
                }
                
                
            }
        }

        public void loadDdlAttr(DropDownList ddl, int Id)
        {

            using (var dc = new seowebappDataContextDataContext())
            {
                ddl.DataSource = dc.AttributeSelectByWId(Id);
                ddl.DataTextField = "Name";
                ddl.DataValueField = "AttributeID";
                ddl.DataBind(); 
            }
        }
      

        #endregion Methods

    }
}
