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

namespace seoWebApplication.UserControls
{
    public partial class MenuParentList : System.Web.UI.UserControl
    {
        public bool showCategory;
        public int showDeptId;
        public int requestDeptId;
        public int MenuItemId;
        
        // Load department details into the DataList
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                if (Request.QueryString["MenuItemId"] != "" && Request.QueryString["MenuItemId"] != null)
                {
                    Session["MenuItemId"] = Request.QueryString["MenuItemId"];
                }
                else
                {
                    Session["MenuItemId"] = Session["MenuItemId"];
                }

               
                showDeptId = 0;
                this.showCategory = true;
            }
            catch
            {
                MenuItemId = 0;
                showCategory = false;
            }

             

            // CatalogAccess.GetDepartments returns a DataTable object containing
                // department data, which is read in the ItemTemplate of the DataList
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            {
                list.DataSource = db.MenuItemSelectByPWId(Convert.ToInt32(Session["MenuItemId"]));
                list.DataBind();
            } 
             
         
        }

        protected void list_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                MenuItemSelectByPWIdResult obj = (MenuItemSelectByPWIdResult)(e.Item.DataItem);

                HyperLink deptHyper = (HyperLink)e.Item.FindControl("deptHyperLink");

                deptHyper.CssClass = "mainmenu";
                if (obj.Url == null)
                {
                    deptHyper.NavigateUrl = LinkMaker.ToSubMenu(obj.ParentMenuItemId.ToString(), obj.MenuItemId.ToString());
                }
                else
                {
                    deptHyper.NavigateUrl = LinkMaker.ToLink(obj.Url);
                }
                deptHyper.Text = HttpUtility.HtmlEncode(obj.MenuItemName.ToString()); 
                deptHyper.ToolTip= HttpUtility.HtmlEncode(obj.Description.ToString());


                if (obj.MenuItemId == Convert.ToInt32(Session["MenuItemId"]))
                {
                    deptHyper.CssClass = "selectedmenu";
                } 
                else
                {
                    deptHyper.CssClass = "nosubmenu";
                }
                    
            }
        }
    }
}