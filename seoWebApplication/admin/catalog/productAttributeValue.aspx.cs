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
    public partial class productAttributeValue : BaseEditPage<ProductAttributeValueEO>
    {
        private bool isSave = false;
        
        
        private const string VIEW_STATE_KEY_ProductAttributeValue = "ProductAttributeValue";
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SaveButton_Click += new seoWebAppAdminEditPage.ButtonClickedHandler(Master_SaveButton_Click);
            Master.CancelButton_Click += new seoWebAppAdminEditPage.ButtonClickedHandler(Master_CancelButton_Click); 
            Master.DeleteButton_Click += new seoWebAppAdminEditPage.ButtonClickedHandler(Master_DeleteButton_Click);
            
            int attId = 0;
            if (!IsPostBack)
            {
                loadDdlAtt();
            }
            else
            {
                attId = Convert.ToInt32(this.ddlAttributes.SelectedValue);
                loadDdlAttribute(ddlAttributes, attId, Convert.ToInt32(ddlAtt.SelectedValue));            
            }

            if (!isSave)
            {
               
            } 
           
            
        }

        void Master_DeleteButton_Click(object sender, EventArgs e)
        {
            
            ENTValidationErrors validationErrors = new ENTValidationErrors(); 
            ProductAttributeValueEO ProductAttributeValue = (ProductAttributeValueEO)ViewState[VIEW_STATE_KEY_ProductAttributeValue];
            LoadObjectFromScreen(ProductAttributeValue);

            ProductAttributeValue.DBAction = ENTBaseEO.DBActionEnum.Delete;
            
            
            if (!ProductAttributeValue.Delete(ref validationErrors, 1))
            {
                //Master.ValidationErrors = validationErrors;
            }
            else
            {
                GoToGridPage();
            }
        }
        

        void Master_CancelButton_Click(object sender, EventArgs e)
        {
            GoToGridPage();
        }

        void Master_SaveButton_Click(object sender, EventArgs e)
        {
           
            ENTValidationErrors validationErrors = new ENTValidationErrors();
            ProductAttributeValueEO ProductAttributeValue = (ProductAttributeValueEO)ViewState[VIEW_STATE_KEY_ProductAttributeValue];
            LoadObjectFromScreen(ProductAttributeValue);
            if (!ProductAttributeValue.Save(ref validationErrors, 1))
            {
                //Master.ValidationErrors = validationErrors;
            }
            else
            {
                GoToGridPage();
            }
        }

        protected override void LoadObjectFromScreen(ProductAttributeValueEO baseEO)
        {

            baseEO.ProductAttributeValueId = Convert.ToInt32(txtProductAttributeValueId.Text);

            baseEO.product_id = Convert.ToInt32(txtproduct_id.Text);

            baseEO.AttributeValueID = Convert.ToInt32(ddlAttributes.SelectedValue);

            baseEO.webstore_id = Convert.ToInt32(txtwebstore_id.Text);

            baseEO.Value = Convert.ToDecimal(txtValue.Text);
        }

        protected override void LoadScreenFromObject(ProductAttributeValueEO baseEO)
        {

            txtProductAttributeValueId.Text = Convert.ToString(baseEO.ProductAttributeValueId);

            if (GetId().Equals(0))
            {
            txtproduct_id.Text = Convert.ToString(GetP_order_id());
            }
            else
            { 
            txtproduct_id.Text = Convert.ToString(baseEO.product_id);
            }

            loadDdlAttribute(ddlAttributes, baseEO.AttributeValueID, Convert.ToInt32(ddlAtt.SelectedValue)); 

            txtwebstore_id.Text = Convert.ToString(baseEO.webstore_id);

            txtValue.Text = Convert.ToString(baseEO.Value);

            txtInsertENTUserAccountId.Text = Convert.ToString(baseEO.InsertENTUserAccountId);
            //Put the object in the view state so it can be attached back to the data context.
            ViewState[VIEW_STATE_KEY_ProductAttributeValue] = baseEO;


           
          
             
        }

        protected override void LoadControls()
        {

           
            
        }

        public void loadDdlAtt()
        {
            loadDdlAttr(ddlAtt, dBHelper.GetWebstoreId());
        }

        

       
       
        protected override void GoToGridPage()
        {
            Response.Redirect("product.aspx" + EncryptQueryString("id=" + (txtproduct_id.Text)));
        }

         

        public override string MenuItemName()
        {
            return "product";
        }

         
         

         

        
    }
}