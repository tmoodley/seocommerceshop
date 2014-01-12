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
            
 

            

            // CatalogAccess.GetDepartments returns a DataTable object containing
            // department data, which is read in the ItemTemplate of the DataList
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

                Label lblTop = (Label)e.Item.FindControl("lblTop");
                Label lblBottom = (Label)e.Item.FindControl("lblBottom");

                requestId = Convert.ToInt32(Request.QueryString["MenuItemId"]);

                if (obj.Url == null)
                {
                    deptHyper.NavigateUrl = LinkMaker.ToParentMenu(obj.MenuItemId.ToString());
                }
                else
                {
                    deptHyper.NavigateUrl = LinkMaker.ToLink(obj.Url.ToString());
                }




                if (obj.MenuItemId == Convert.ToInt32(Session["MenuItemId"]))
                {
                    lblTop.Text = "<li class=\"current\">"; 
                }
                else
                {
                    lblTop.Text = "<li>"; 
                }

                if (obj.Url != null)
                {
                    if (LinkMaker.ToLink(obj.Url) == Request.Url.ToString())
                    {
                        lblTop.Text = "<li class=\"current\">";
                    }
                }
                deptHyper.Text += "<b>";  
                deptHyper.Text += HttpUtility.HtmlEncode(obj.MenuItemName.ToString());
                deptHyper.Text += "</b>";
                lblBottom.Text = "</li>"; 
                deptHyper.ToolTip = HttpUtility.HtmlEncode(obj.Description.ToString());

               
                if (obj.MenuItemId == requestId)
                {
                    deptHyper.CssClass = "current";
                    //this.showCurrent = true;
                }
                else
                {
                    deptHyper.CssClass = "";
                }

            }
        }


    }
}