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
using seoWebApplication.st.SharkTankDAL.entObject;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.Framework;
using System.Data.SqlClient;

namespace seoWebApplication.admin.settings
{
    public partial class attributes : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.AddButton_Click += new seoWebAppAdminEditGrid.ButtonClickedHandler(Master_AddButton_Click);
            Master.AddSearch_Click += new seoWebAppAdminEditGrid.ButtonClickedHandler(Master_AddSearchButton_Click);
            Master.ddlClickEvent_Click += new seoWebAppAdminEditGrid.SelectedIndexChanged(Master_AddSearchDdl_Click);
            if (!IsPostBack)
            {
                BindDDlFilter();
                using (var dc = new seowebappDataContextDataContext())
                {

                    BoundField bf2 = new BoundField();
                    bf2.DataField = "Name";
                    bf2.HeaderText = "Name";

                    BoundField bf3 = new BoundField();
                    bf3.DataField = "controlName";
                    bf3.HeaderText = "Control Type";
  
                    BoundField bf5 = new BoundField();
                    bf5.DataField = "AttributeID";
                    bf5.HeaderText = "Attribute ID";

                    BoundField bf1 = new BoundField();
                    bf1.DataField = "applyToAllProducts";
                    bf1.HeaderText = "All Products";

                    BoundField bf6 = new BoundField();
                    bf6.DataField = "applyToCategory";
                    bf6.HeaderText = "Category";


                    cgvAttributes.Columns.Add(bf2);
                    cgvAttributes.Columns.Add(bf3);  
                    cgvAttributes.Columns.Add(bf1);
                    cgvAttributes.Columns.Add(bf6);
                    cgvAttributes.Columns.Add(bf5);

                    cgvAttributes.AutoGenerateColumns = false;

                    cgvAttributes.DataSource = dc.AttributeSelectByWId(dBHelper.GetWebstoreId());

                    cgvAttributes.DataBind();
                }
            }

        }

        void BindGridDynamic(string tblName, string search)
        {
            using (var dc = new seowebappDataContextDataContext())
            {
                //var query = dc.productSelectByWId(dBHelper.GetWebstoreId()).Where("webstore_id = 3");
                //var query = dc.products.Where("webstore_id = 3").OrderBy("product_id");
                var query = from d in dc.departments
                            where d.webstore_id == dBHelper.GetWebstoreId()
                            orderby d.Name
                            select d;
                BoundField bf2 = new BoundField();
                bf2.DataField = "Name";
                bf2.HeaderText = "Name";

                BoundField bf3 = new BoundField();
                bf3.DataField = "Description";
                bf3.HeaderText = "Description";


                BoundField bf1 = new BoundField();
                bf1.DataField = "department_id";
                bf1.HeaderText = "department_id";



                cgvAttributes.Columns.Add(bf2);
                cgvAttributes.Columns.Add(bf3);
                cgvAttributes.Columns.Add(bf1);


                cgvAttributes.AutoGenerateColumns = false;
                cgvAttributes.DataSource = query;
                cgvAttributes.DataBind();
            }
        }

        void BindDDlFilter()
        {
            getSchema gt = new getSchema();
            DataTable dt = gt.GetSchema(dBHelper.GetSeoWebAppConnectionString(), "vw_attributes");
            Master.SearchList.DataSource = dt;
            Master.SearchList.DataTextField = "ColumnName";
            Master.SearchList.DataValueField = "ColumnName";
            Master.SearchList.DataBind();

        }

        void Master_AddSearchDdl_Click(object sender, EventArgs e)
        {
            string name = Master.change_ddlArea;
            if (name == "name")
            {
                Master.displayBox = "textbox";
            }
        }

        void Master_AddButton_Click(object sender, EventArgs e)
        {

            Response.Redirect("attribute.aspx" + EncryptQueryString("id=0&newRec=true"));

        }

        void Master_AddSearchButton_Click(object sender, EventArgs e)
        {
            string search = Master.searchBox;
            string tblName = Master.change_ddlArea;
            BindGridDynamic(tblName, search);

        }

        public override string MenuItemName()
        {
            return "Admin";
        }

        protected void cgvAttributes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string cId;
                AttributeSelectByWIdResult obj = (AttributeSelectByWIdResult)(e.Row.DataItem);
                cId = obj.AttributeID.ToString();

                bool allProducts = obj.applyToAllProducts;
                bool allCategory = obj.applyToCategory;




                //Add the edit link to the action column.
                HyperLink editLink = new HyperLink();

                editLink.Text = "Edit";

                editLink.NavigateUrl = "attribute.aspx" + EncryptQueryString("id=" + (cId));

                e.Row.Cells[4].Controls.Add(editLink);

                //Add checkbox to display the isactive field.
                CheckBox chkProducts = new CheckBox();
                chkProducts.Checked = allProducts;
                chkProducts.Enabled = false;

                e.Row.Cells[2].Controls.Add(chkProducts);

                //Add checkbox to display the isactive field.
                CheckBox chkCategory = new CheckBox();
                chkCategory.Checked = allCategory;
                chkCategory.Enabled = false;

                e.Row.Cells[3].Controls.Add(chkCategory);
            }
        }
    }
}