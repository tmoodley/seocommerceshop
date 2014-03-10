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
    public partial class MenuList : System.Web.UI.UserControl
    {
        public bool showCategory;
        public int showDeptId;
        public int requestDeptId;
        public int MenuItemId;
        public bool hasInner;
        
        
        // Load department details into the DataList
        protected void Page_Load(object sender, EventArgs e)
        {
              
            try
            {
                hasInner = false;
                if (Request.QueryString["MenuItemId"] != "" && Request.QueryString["MenuItemId"] != null)
                {
                    Session["MenuItemId"] = Request.QueryString["MenuItemId"];
                }
                else
                {
                    Session["MenuItemId"] = Session["MenuItemId"];
                }
                using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
                {
                    outerRep.DataSource = db.MenuItemSelectByPWId(Convert.ToInt32(Session["MenuItemId"]));
                    outerRep.DataBind();
                }

                  

                  
 
              
            }
            catch (Exception ex)
            {
                Response.Write("Exception Occured:   " + ex);
            }

             

            // CatalogAccess.GetDepartments returns a DataTable object containing
                // department data, which is read in the ItemTemplate of the DataList
           
             
         
        }
       
        protected void outerRep_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                MenuItemSelectByPWIdResult obj = (MenuItemSelectByPWIdResult)(e.Item.DataItem);

                Literal litText = (Literal)e.Item.FindControl("litText");
                 
                if (obj.Url == null)
                { 
                    litText.Text = obj.MenuItemName.ToString();
                }
                else
                {
                     litText.Text = obj.MenuItemName.ToString();
                }
                litText.Text = HttpUtility.HtmlEncode(obj.MenuItemName.ToString()); 
                


             

               
                    Repeater innerRep = e.Item.FindControl("innerRep") as Repeater;
             

                    using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
                    {
                        innerRep.DataSource = db.MenuItemSelectByPWId(Convert.ToInt32(obj.MenuItemId));
                        innerRep.DataBind();

                       
                    }
                 
 
                    
            }
            
        }

        protected void innerRep_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                MenuItemSelectByPWIdResult obj = (MenuItemSelectByPWIdResult)(e.Item.DataItem);

                HyperLink catHyper = (HyperLink)e.Item.FindControl("catHyperLink");

                catHyper.CssClass = "mainmenu";
                catHyper.NavigateUrl = HttpUtility.HtmlEncode("~/admin/" + obj.Url.ToString());
                //catHyper.NavigateUrl = LinkMaker.ToSubMenu(obj.ParentMenuItemId.ToString(), obj.MenuItemId.ToString());
                catHyper.Text = HttpUtility.HtmlEncode(obj.MenuItemName.ToString());
                catHyper.ToolTip = HttpUtility.HtmlEncode(obj.Description.ToString());

                if (obj.MenuItemId == Convert.ToInt32(Request.QueryString["SubMenuItemId"]))
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