using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.Framework;
using System.Data; 

namespace seoWebApplication.admin
{
    public partial class attribute : BaseEditPage<AttributeEO>
    {
        private const string VIEW_STATE_KEY_Attribute = "Attribute";
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SaveButton_Click += new seoWebAppAdminEditPage.ButtonClickedHandler(Master_SaveButton_Click);
            Master.CancelButton_Click += new seoWebAppAdminEditPage.ButtonClickedHandler(Master_CancelButton_Click);
            if (IsPostBack)
            {
                loadGrid();
            }
        }

        void Master_CancelButton_Click(object sender, EventArgs e)
        {
            GoToGridPage();
        }

        void Master_SaveButton_Click(object sender, EventArgs e)
        {
            ENTValidationErrors validationErrors = new ENTValidationErrors();
            AttributeEO Attribute = (AttributeEO)ViewState[VIEW_STATE_KEY_Attribute];
            LoadObjectFromScreen(Attribute);
            if (!Attribute.Save(ref validationErrors, 1))
            {
                //Master.ValidationErrors = validationErrors;
            }
            else
            {
                GoToGridPage();
            }
        }

        protected override void LoadObjectFromScreen(AttributeEO baseEO)
        {

            baseEO.AttributeID = Convert.ToInt32(txtAttributeID.Text);

            baseEO.Name = txtName.Text;

            baseEO.controlType_id = Convert.ToInt32(ddlControl.SelectedValue);

            baseEO.webstore_id = Convert.ToInt32(txtwebstore_id.Text);

            baseEO.applyToAllProducts = chkapplyToAllProducts.Checked;

            baseEO.applyToCategory = chkapplyToCategory.Checked;
        }

        protected override void LoadScreenFromObject(AttributeEO baseEO)
        {

            txtAttributeID.Text = Convert.ToString(baseEO.AttributeID);

            txtName.Text = Convert.ToString(baseEO.Name);
              
            loadDdlControlType(ddlControl, baseEO.controlType_id); 

            txtwebstore_id.Text = Convert.ToString(baseEO.webstore_id);

            chkapplyToAllProducts.Checked = baseEO.applyToAllProducts;

            chkapplyToCategory.Checked = baseEO.applyToCategory;

            txtInsertENTUserAccountId.Text = Convert.ToString(baseEO.InsertENTUserAccountId);

            //Put the object in the view state so it can be attached back to the data context.
            ViewState[VIEW_STATE_KEY_Attribute] = baseEO;

            loadGrid();
        }

        protected override void LoadControls()
        {
            

        }

        public void loadGrid()
        {
            using (var dc = new seowebappDataContextDataContext())
            {

                BoundField bf2 = new BoundField();
                bf2.DataField = "AttributeValueID";
                bf2.HeaderText = "AttributeValueID";

                BoundField bf3 = new BoundField();
                bf3.DataField = "Value";
                bf3.HeaderText = "Value";

                if (IsPostBack)
                {
                    cgvAttributeValues.Columns.Clear();
                }
               

                cgvAttributeValues.Columns.Add(bf3);
                cgvAttributeValues.Columns.Add(bf2);

              

                cgvAttributeValues.AutoGenerateColumns = false;

                cgvAttributeValues.DataSource = dc.AttributeValueSelectByAId(Convert.ToInt32(this.txtAttributeID.Text));

                cgvAttributeValues.DataBind();
            }
        }

       
        protected override void GoToGridPage()
        {
            Response.Redirect("attributes.aspx");
        }

        public void ReloadPage()
        {
            AttributeEO Attribute = (AttributeEO)ViewState[VIEW_STATE_KEY_Attribute];
            Response.Redirect("attribute.aspx" + EncryptQueryString("id=" + (Attribute.AttributeID)));
        }

        public override string MenuItemName()
        {
            return "product";
        }

        protected void menuTabs_MenuItemClick(object sender, MenuEventArgs e)
        {
            multiTabs.ActiveViewIndex = Int32.Parse(menuTabs.SelectedValue);

        }

        protected void cgvAttributeValues_RowDataBound(object sender, GridViewRowEventArgs e)
        {
             if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string aId;
                AttributeValueSelectByAIdResult obj = (AttributeValueSelectByAIdResult)(e.Row.DataItem);
                aId = obj.AttributeValueID.ToString(); 

                //Add the edit link to the action column.
                HyperLink editLink = new HyperLink();

                editLink.Text = "Edit";

                editLink.NavigateUrl = "attributeValue.aspx" + EncryptQueryString("id=" + (aId));

                e.Row.Cells[1].Controls.Add(editLink);

            }
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("attributeValue.aspx" + EncryptQueryString("id=0&newRec=true&p_order_id=" + txtAttributeID.Text));
        }

        
    }
}