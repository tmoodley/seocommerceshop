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
using seoWebApplication.Data;
namespace seoWebApplication.UserControls
{
    public partial class MenuTab : System.Web.UI.UserControl
    {
        public bool showCurrent;
        public int showDeptId;
        public int requestId;
        // Load department details into the DataList
        protected void Page_Load(object sender, EventArgs e)
        {
            this.showCurrent = false;

            if (Request.QueryString["MenuItemId"] != "" && Request.QueryString["MenuItemId"] != null)
            {
                Session["MenuItemId"] = Request.QueryString["MenuItemId"];
            }

             

            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                list.DataSource = db.MenuItemSelectAll();
                list.DataBind();
            }
        }

        protected void list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                MenuItemSelectAllResult obj = (MenuItemSelectAllResult)(e.Item.DataItem);

                HyperLink deptHyper = (HyperLink)e.Item.FindControl("deptHyperLink");
 
                requestId = Convert.ToInt32(Request.QueryString["MenuItemId"]);

                if (obj.Url == null)
                {
                    deptHyper.NavigateUrl = LinkMaker.ToParentMenu(obj.MenuItemId.ToString());
                    deptHyper.Text = obj.MenuItemName.ToString();
                }
                else
                {
                    deptHyper.NavigateUrl = LinkMaker.ToLink(obj.Url.ToString());
                    deptHyper.Text = obj.MenuItemName.ToString();
                }
                 

            }
        }


    }
}