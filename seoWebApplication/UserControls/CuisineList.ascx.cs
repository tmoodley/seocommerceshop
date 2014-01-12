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
    public partial class CuisineList : System.Web.UI.UserControl
    {
        public bool showCategory;
        public int showDeptId;
        public int requestCuisineId;
        // Load department details into the DataList
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                requestCuisineId = Convert.ToInt32(Request.QueryString["department_id"]);
                showDeptId = 0;
                this.showCategory = true;
            }
            catch
            {
               
                showCategory = false;
            }
           
            

            // CatalogAccess.GetDepartments returns a DataTable object containing
                // department data, which is read in the ItemTemplate of the DataList
            using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
            { 
                list.DataSource = db.cuisineSelectByWId(dBHelper.GetWebstoreId());
                list.DataBind();
            } 
             
        
        }

        protected void list_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                cuisineSelectByWIdResult obj = (cuisineSelectByWIdResult)(e.Item.DataItem);

                HyperLink cuisineHyper = (HyperLink)e.Item.FindControl("cuisineHyperLink");

                cuisineHyper.CssClass = "class_menuitem_categorytype";
                cuisineHyper.NavigateUrl = LinkMaker.ToCuisine(obj.cuisine_id.ToString());
                cuisineHyper.Text = HttpUtility.HtmlEncode(obj.name.ToString());
                cuisineHyper.ToolTip = HttpUtility.HtmlEncode(obj.SeoDescription.ToString());


                if (obj.cuisine_id == requestCuisineId)
                {
                    cuisineHyper.CssClass = "DepartmentSelected";
                } 
                else
                {
                    cuisineHyper.CssClass = "DepartmentUnselected";
                }
                    
            }
        }
    }
}