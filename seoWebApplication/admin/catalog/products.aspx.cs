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

namespace seoWebApplication.admin
{
    public partial class products : BasePage
    {

        private const int COL_INDEX_ACTION = 0;
        private const int COL_INDEX_NAME = 1;
        private const int COL_INDEX_DESCRIPTION = 2;






        protected void Page_Load(object sender, EventArgs e)
        {

            Master.AddButton_Click += new seoWebAppAdminEditGrid.ButtonClickedHandler(Master_AddButton_Click);
            Master.AddSearch_Click += new seoWebAppAdminEditGrid.ButtonClickedHandler(Master_AddSearchButton_Click);
            Master.ddlClickEvent_Click += new seoWebAppAdminEditGrid.SelectedIndexChanged(Master_AddSearchDdl_Click);
            

            // if (!IsPostBack)
            //{
            //    //Tell the control what class to create and what method to call to load the class.
            //    cgvCharges.ListClassName = typeof(productEOList).AssemblyQualifiedName;
            //    cgvCharges.LoadMethodName = "Load";

            //    //Action column-Contains the Edit link
            //    cgvCharges.AddBoundField("", "Actions", "");

            //    //stateShort
            //    cgvCharges.AddBoundField("name", "name", "name");

            //    //stateLong
            //    cgvCharges.AddBoundField("description", "description", "description");


            //    cgvCharges.DataBind();

            //}
            if (!IsPostBack)
            {
                BindDDlFilter();
                using (var dc = new seowebappDataContextDataContext())
                {

                    BoundField bf2 = new BoundField();
                    bf2.DataField = "name";
                    bf2.HeaderText = "name";

                    BoundField bf3 = new BoundField();
                    bf3.DataField = "description";
                    bf3.HeaderText = "description";

                    BoundField bf4 = new BoundField();
                    bf4.DataField = "price";
                    bf4.HeaderText = "price";

                    BoundField bf5 = new BoundField();
                    bf5.DataField = "promofront";
                    bf5.HeaderText = "promofront";

                    BoundField bf6 = new BoundField();
                    bf6.DataField = "promodept";
                    bf6.HeaderText = "promodept";


                    BoundField bf1 = new BoundField();
                    bf1.DataField = "product_id";
                    bf1.HeaderText = "product_id";



                    cgvProducts.Columns.Add(bf2);
                    cgvProducts.Columns.Add(bf3);
                    cgvProducts.Columns.Add(bf4);
                    cgvProducts.Columns.Add(bf5);
                    cgvProducts.Columns.Add(bf6);
                    cgvProducts.Columns.Add(bf1);


                    cgvProducts.AutoGenerateColumns = false;

                    cgvProducts.DataSource = dc.productSelectByWId(dBHelper.GetWebstoreId());

                    cgvProducts.DataBind();
                }
            }
        }
        void BindGridDynamic(string tblName, string search)
        {
            using (var dc = new seowebappDataContextDataContext())
            {
                //var query = dc.productSelectByWId(dBHelper.GetWebstoreId()).Where("webstore_id = 3");
                //var query = dc.products.Where("webstore_id = 3").OrderBy("product_id");
                var query = from p in dc.products
                            where p.webstore_id == 2 
                            orderby p.name
                            select p;
                BoundField bf2 = new BoundField();
                bf2.DataField = "name";
                bf2.HeaderText = "name";

                BoundField bf3 = new BoundField();
                bf3.DataField = "description";
                bf3.HeaderText = "description";

                BoundField bf4 = new BoundField();
                bf4.DataField = "price";
                bf4.HeaderText = "price";

                BoundField bf5 = new BoundField();
                bf5.DataField = "promofront";
                bf5.HeaderText = "promofront";

                BoundField bf6 = new BoundField();
                bf6.DataField = "promodept";
                bf6.HeaderText = "promodept";


                BoundField bf1 = new BoundField();
                bf1.DataField = "product_id";
                bf1.HeaderText = "product_id";



                cgvProducts.Columns.Add(bf2);
                cgvProducts.Columns.Add(bf3);
                cgvProducts.Columns.Add(bf4);
                cgvProducts.Columns.Add(bf5);
                cgvProducts.Columns.Add(bf6);
                cgvProducts.Columns.Add(bf1);


                cgvProducts.AutoGenerateColumns = false;
                cgvProducts.DataSource = query;
                cgvProducts.DataBind();
            }
        }

        void BindDDlFilter()
        {    
                getSchema gt = new getSchema();
                DataTable dt = gt.GetSchema(dBHelper.GetSeoWebAppConnectionString(), "vw_product");
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

            Response.Redirect("product.aspx" + EncryptQueryString("id=0&newRec=true"));

        }

        void Master_AddSearchButton_Click(object sender, EventArgs e)
        {
            string search = Master.searchBox;
            string tblName = Master.change_ddlArea;
            BindGridDynamic(tblName, search);
             
        }

        public override string MenuItemName()
        {
            return "Product";
        }

        protected void cgvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string pId;
                   productSelectByWIdResult obj = (productSelectByWIdResult)(e.Row.DataItem);
                    pId = obj.product_id.ToString();
                
                   


                //Add the edit link to the action column.
                HyperLink editLink = new HyperLink();

                editLink.Text = "Edit";

                editLink.NavigateUrl = "Product.aspx" + EncryptQueryString("id=" + (pId));

                e.Row.Cells[5].Controls.Add(editLink);

                //Add checkbox to display the isactive field.
                CheckBox chkShowpromodept = new CheckBox();
                chkShowpromodept.Checked = obj.promodept;
                chkShowpromodept.Enabled = false;

                e.Row.Cells[4].Controls.Add(chkShowpromodept);

                //Add checkbox to display the isactive field.
                CheckBox chkShowpromofront = new CheckBox();
                chkShowpromofront.Checked = obj.promofront;
                chkShowpromofront.Enabled = false;

                e.Row.Cells[3].Controls.Add(chkShowpromofront);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("product.aspx" + EncryptQueryString("id=0&newRec=true"));
        }

    }
}