using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.Framework; 

namespace seoWebApplication.admin
{
    public partial class product : BaseEditPage<productEO>
    {
        private const string VIEW_STATE_KEY_product = "product";
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SaveButton_Click += new seoWebAppAdminEditPage.ButtonClickedHandler(Master_SaveButton_Click);
            Master.CancelButton_Click += new seoWebAppAdminEditPage.ButtonClickedHandler(Master_CancelButton_Click);
            Master.DeleteButton_Click += new seoWebAppAdminEditPage.ButtonClickedHandler(Master_DeleteButton_Click);

            if (IsPostBack)
            {
                loadGrid();
                loadCatGrid();
            }
        }

        void Master_CancelButton_Click(object sender, EventArgs e)
        {
            GoToGridPage();
        }

        void Master_DeleteButton_Click(object sender, EventArgs e)
        {
            ENTValidationErrors validationErrors = new ENTValidationErrors();
            productEO product = (productEO)ViewState[VIEW_STATE_KEY_product];
            LoadObjectFromScreen(product);

            product.DBAction = ENTBaseEO.DBActionEnum.Delete; 

            if (!product.Delete(ref validationErrors, 1))
            {
                
                Master.ValidationErrors = validationErrors;
            }
            else
            {
                GoToGridPage();
            }
        }

        void Master_SaveButton_Click(object sender, EventArgs e)
        {
            ENTValidationErrors validationErrors = new ENTValidationErrors();
            productEO product = (productEO)ViewState[VIEW_STATE_KEY_product];
            LoadObjectFromScreen(product);
            if (!product.Save(ref validationErrors, 1))
            {
                Master.ValidationErrors = validationErrors;
            }
            else
            {
                GoToGridPage();
            }
        }

        protected override void LoadObjectFromScreen(productEO baseEO)
        {

            baseEO.webstore_id = Convert.ToInt32(txtwebstore_id.Text);

            baseEO.name = txtname.Text;

            baseEO.description = txtdescription.Text;

            baseEO.price = Convert.ToDecimal(txtprice.Text);

            baseEO.thumbnail = txtthumbnail.Text;

            baseEO.image = txtimage.Text;

            baseEO.promofront = chkpromofront.Checked;

            baseEO.promodept = chkpromodept.Checked;

            productEO product = (productEO)ViewState[VIEW_STATE_KEY_product];

            baseEO.ID = product.product_id;

            baseEO.defaultAttribute = chkdefaultAttribute.Checked;

            baseEO.defaultAttCat = chkdefaultAttCat.Checked;
        }

        protected override void LoadScreenFromObject(productEO baseEO)
        {

            txtwebstore_id.Text = Convert.ToString(dBHelper.GetWebstoreId());

            txtname.Text = Convert.ToString(baseEO.name);

            txtdescription.Text = Convert.ToString(baseEO.description);

            txtprice.Text = Convert.ToString(baseEO.price);

            txtthumbnail.Text = Convert.ToString(baseEO.thumbnail);

            txtimage.Text = Convert.ToString(baseEO.image);

            chkpromofront.Checked = baseEO.promofront;

            chkdefaultAttribute.Checked = baseEO.defaultAttribute;

            chkdefaultAttCat.Checked = baseEO.defaultAttCat;

            chkpromodept.Checked = baseEO.promodept;
            //Put the object in the view state so it can be attached back to the data context.
            ViewState[VIEW_STATE_KEY_product] = baseEO;

            loadGrid();
            loadDdlCat(ddlCategory, 0);
            loadCatGrid();
        }

        protected override void LoadControls()
        {
        }
        protected override void GoToGridPage()
        {
            Response.Redirect("products.aspx");
        }

        public void ReloadPage()
        {
            productEO product = (productEO)ViewState[VIEW_STATE_KEY_product];
            Response.Redirect("Product.aspx" + EncryptQueryString("id=" + (product.product_id)));
        }

        public override string MenuItemName()
        {
            return "product";
        }

        protected void menuTabs_MenuItemClick(object sender, MenuEventArgs e)
        {
            multiTabs.ActiveViewIndex = Int32.Parse(menuTabs.SelectedValue);

        }

        protected void upload1Button_Click(object sender, EventArgs e)
        {
            // proceed with uploading only if the user selected a file
            if (image1FileUpload.HasFile)
            {
                try
                {
                    string fileName = image1FileUpload.FileName;
                    string location = Server.MapPath("~/ProductImages/") + fileName;
                    // save image to server
                    image1FileUpload.SaveAs(location);

                    productEO product = (productEO)ViewState[VIEW_STATE_KEY_product]; 
                     
                    // update database with new product details
                    using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
                    {
                        db.productImageUpdate(product.product_id, product.webstore_id, fileName, "", 1, 1);
                    }
                    // reload the page
                    ReloadPage();
                     
                }
                catch
                {
                    statusLabel.Text = "Uploading image 1 failed";
                }
            }
        }

        protected void upload2Button_Click(object sender, EventArgs e)
        {
            // proceed with uploading only if the user selected a file
            if (image2FileUpload.HasFile)
            {
                try
                {
                    string fileName = image2FileUpload.FileName;
                    string location = Server.MapPath("~/ProductImages/") + fileName;
                    // save image to server
                    image2FileUpload.SaveAs(location);
                    // update database with new product details 

                    productEO product = (productEO)ViewState[VIEW_STATE_KEY_product];

                    using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
                    {
                        db.productImageUpdate(product.product_id, product.webstore_id, "", fileName, 2, 1);
                    }
                    // reload the page
                    ReloadPage();
                }
                catch
                {
                    statusLabel.Text = "Uploading image 2 failed";
                }
            }
        }



        protected void cgvCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string cId, pid;
                productcategorySelectResult obj = (productcategorySelectResult)(e.Row.DataItem);
                cId = obj.category_id.ToString();
                pid = obj.product_id.ToString();
                //Add the edit link to the action column.
                HyperLink editLink = new HyperLink();

                editLink.Text = "DEL";

                editLink.NavigateUrl = "deleteProductCategory.aspx" + EncryptQueryString("id=" + (pid) + "&p_order_id=" + (cId));

                e.Row.Cells[2].Controls.Add(editLink);

            }

        }

        protected void cgvAttributeValues_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string aId;
                vw_product_attributeSelectByPIdResult obj = (vw_product_attributeSelectByPIdResult)(e.Row.DataItem);
                aId = obj.ProductAttributeValueId.ToString();

                //Add the edit link to the action column.
                HyperLink editLink = new HyperLink();

                editLink.Text = "Edit";

                editLink.NavigateUrl = "productAttributeValue.aspx" + EncryptQueryString("id=" + (aId));

                e.Row.Cells[3].Controls.Add(editLink);

            }

        }

        public void loadGrid()
        {
            using (var dc = new seowebappDataContextDataContext())
            {

                BoundField bf1 = new BoundField();
                bf1.DataField = "Value";
                bf1.HeaderText = "Value";

                BoundField bf2 = new BoundField();
                bf2.DataField = "Name";
                bf2.HeaderText = "Name";

                BoundField bf3 = new BoundField();
                bf3.DataField = "AttName";
                bf3.HeaderText = "AttName";

                BoundField bf4 = new BoundField();
                bf4.DataField = "ProductAttributeValueId";
                bf4.HeaderText = "Action";

                

                if (IsPostBack)
                {
                    cgvAttributeValues.Columns.Clear();
                }


                cgvAttributeValues.Columns.Add(bf1);
                cgvAttributeValues.Columns.Add(bf2);
                cgvAttributeValues.Columns.Add(bf3);
                cgvAttributeValues.Columns.Add(bf4);


                cgvAttributeValues.AutoGenerateColumns = false;

                cgvAttributeValues.DataSource = dc.vw_product_attributeSelectByPId(Convert.ToInt32(GetId()));

                cgvAttributeValues.DataBind();
            }
        }

        public void loadCatGrid()
        {
            using (var dc = new seowebappDataContextDataContext())
            {

                BoundField bf1 = new BoundField();
                bf1.DataField = "name";
                bf1.HeaderText = "Name";

                BoundField bf2 = new BoundField();
                bf2.DataField = "description";
                bf2.HeaderText = "Description";

                BoundField bf3 = new BoundField();
                bf3.DataField = "category_id";
                bf3.HeaderText = "Action";
  

                if (IsPostBack)
                {
                    cgvCategory.Columns.Clear();
                }


                cgvCategory.Columns.Add(bf1);
                cgvCategory.Columns.Add(bf2);
                cgvCategory.Columns.Add(bf3);


                cgvCategory.AutoGenerateColumns = false;

                cgvCategory.DataSource = dc.productcategorySelect(Convert.ToInt32(GetId()));

                cgvCategory.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("productAttributeValue.aspx" + EncryptQueryString("id=0&newRec=true&p_order_id=" + GetId()));
        
        }

        protected void btnDeleteProductScart_Click(object sender, EventArgs e)
        {
            productEO product = (productEO)ViewState[VIEW_STATE_KEY_product];
            LoadObjectFromScreen(product);
            product.removeProductId(product.ID);
        }

        protected void btnCat_Click(object sender, EventArgs e)
        {
            categoryEO.addProductToCategory(GetId(), Convert.ToInt32(ddlCategory.SelectedValue.ToString()));
            ReloadPage();
        }

       

         
    }
}