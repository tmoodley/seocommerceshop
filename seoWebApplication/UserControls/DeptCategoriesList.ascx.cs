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
using System.IO;
 

namespace seoWebApplication.UserControls
{
    public partial class DeptCategoriesList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                // Obtain the ID of the selected department
                string department_id = Request.QueryString["department_id"];
                
                // Continue only if department_id exists in the query string
                if (department_id != null)
                {
                    try
                    {
                        // CatalogAccess.GetDepartments returns a DataTable object containing
                        // department data, which is read in the ItemTemplate of the DataList
                        
                        using (var dc = new seowebappDataContext())
                        {
                            outerRep.DataSource = dc.CatalogGetCategoriesIndepartment(Convert.ToInt32(department_id));
                            outerRep.DataBind();

                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Exception Occured:   " + ex);
                    }

                     
            }
 
        }

        protected void outerRep_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                CatalogGetCategoriesIndepartmentResult obj = (CatalogGetCategoriesIndepartmentResult)(e.Item.DataItem);
                DataRowView drv = e.Item.DataItem as DataRowView;
                Repeater innerRep = e.Item.FindControl("innerRep") as Repeater;

                string department_id = Request.QueryString["department_id"];
                string category_id = obj.category_id.ToString();

                using (var dc = new seowebappDataContextDataContext())
                {
                    innerRep.DataSource = dc.CatalogGetAllproductsInCategory(Convert.ToInt32(category_id));
                    innerRep.DataBind();

                }

                 
            }
        }

        protected void innerRep_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                // Obtain the ID of the selected department
            
                CatalogGetAllproductsInCategoryResult obj = (CatalogGetAllproductsInCategoryResult)(e.Item.DataItem);
                string department_id = Request.QueryString["department_id"];
                string category_id = obj.category_id.ToString();

                  
                Label catHyper = (Label)e.Item.FindControl("hlProductName");
                catHyper.CssClass = "class_menuitem_categorytype"; 
                catHyper.Text = HttpUtility.HtmlEncode(obj.name.ToString());
                catHyper.ToolTip = HttpUtility.HtmlEncode(obj.description.ToString());

                Label lblPrice = (Label)e.Item.FindControl("lblPrice");

                lblPrice.CssClass = "class_menuitem_categorytype";
                lblPrice.Text = HttpUtility.HtmlEncode("Price: $" + Convert.ToDecimal(obj.price.ToString("#,##0.00")));
                lblPrice.ToolTip = HttpUtility.HtmlEncode(obj.description.ToString());

                 Label lblDesc = (Label)e.Item.FindControl("lblDesc");

                lblDesc.CssClass = "class_menuitem_categorytype";
                lblDesc.Text = HttpUtility.HtmlEncode(obj.description.ToString());
                lblDesc.ToolTip = HttpUtility.HtmlEncode(obj.description.ToString());

                 

               
            }
        }
    }
}