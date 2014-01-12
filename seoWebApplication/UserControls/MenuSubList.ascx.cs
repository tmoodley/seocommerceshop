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
    public partial class MenuSubList : System.Web.UI.UserControl
    {
        public bool showCategory;
        public int showDeptId;
        public int SubMenuItemId;
      
        // Load department details into the DataList
        protected void Page_Load(object sender, EventArgs e)
        {
               

                if (Request.QueryString["SubMenuItemId"] != "" && Request.QueryString["SubMenuItemId"] != null)
                {
                    Session["SubMenuItemId"] = Request.QueryString["SubMenuItemId"];
                    SubMenuItemId = Convert.ToInt32(Session["SubMenuItemId"]);
                }
                else
                {
                    SubMenuItemId = Convert.ToInt32(Session["SubMenuItemId"]);
                }
                
                // Continue only if department_id exists in the query string
                if (SubMenuItemId > 0)
                {
                    try
                    {  
                         
                        // department data, which is read in the ItemTemplate of the DataList
                        using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
                        {
                            list.DataSource = db.MenuItemSelectByPWId(Convert.ToInt32(Session["SubMenuItemId"]));
                            list.DataBind();
                        } 
                    }
                    catch
                    {

                        showCategory = false;
                    }
                }
            

             
        
        }

        protected void list_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                MenuItemSelectByPWIdResult obj = (MenuItemSelectByPWIdResult)(e.Item.DataItem);

                HyperLink catHyper = (HyperLink)e.Item.FindControl("catHyperLink");

                catHyper.CssClass = "mainmenu";
                catHyper.NavigateUrl = HttpUtility.HtmlEncode("~/admin/"+obj.Url.ToString());
                //catHyper.NavigateUrl = LinkMaker.ToSubMenu(obj.ParentMenuItemId.ToString(), obj.MenuItemId.ToString());
                catHyper.Text = HttpUtility.HtmlEncode(obj.MenuItemName.ToString());
                catHyper.ToolTip = HttpUtility.HtmlEncode(obj.Description.ToString());

                //if (this.MenuItemName.ToString() == obj.MenuItemName.ToString())
                //{
                //    catHyper.CssClass = "DepartmentSelected";
                //}
                //if (obj.MenuItemId == Convert.ToInt32(Session["SubMenuItemId"]))
                if (obj.MenuItemId == Convert.ToInt32(Session["SubMenuItemId"]))
                { 
                    catHyper.CssClass = "DepartmentSelected";
                } 
                else
                {
                    catHyper.CssClass = "DepartmentUnselected";
                }
                    
            }
        }
    }
}