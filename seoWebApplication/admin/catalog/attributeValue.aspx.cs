using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.Framework; 

namespace seoWebApplication.admin.catalog
{
    public partial class attributeValue : BaseEditPage<AttributeValueEO>
    {
        private const string VIEW_STATE_KEY_AttributeValue = "AttributeValue";
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SaveButton_Click += new seoWebAppAdminEditPage.ButtonClickedHandler(Master_SaveButton_Click);
            Master.CancelButton_Click += new seoWebAppAdminEditPage.ButtonClickedHandler(Master_CancelButton_Click);

        }

        void Master_CancelButton_Click(object sender, EventArgs e)
        {
            GoToGridPage();
        }

        void Master_SaveButton_Click(object sender, EventArgs e)
        {
            ENTValidationErrors validationErrors = new ENTValidationErrors();
            AttributeValueEO AttributeValue = (AttributeValueEO)ViewState[VIEW_STATE_KEY_AttributeValue];
            LoadObjectFromScreen(AttributeValue);
            if (!AttributeValue.Save(ref validationErrors, 1))
            {
                //Master.ValidationErrors = validationErrors;
            }
            else
            {
                GoToGridPage();
            }
        }

        protected override void LoadObjectFromScreen(AttributeValueEO baseEO)
        {

            baseEO.AttributeValueID = Convert.ToInt32(txtAttributeValueID.Text);

            baseEO.AttributeID = Convert.ToInt32(txtAttributeID.Text);

            baseEO.Value = txtValue.Text;

            baseEO.webstore_id = Convert.ToInt32(txtwebstore_id.Text); 
             

            if (baseEO.ID == 0)
            {
                baseEO.InsertENTUserAccountId = Convert.ToInt32(Session["AdminUserId"]);
            }
            else
            {
                baseEO.UpdateENTUserAccountId = Convert.ToInt32(Session["AdminUserId"]);
            }
             
        }

        protected override void LoadScreenFromObject(AttributeValueEO baseEO)
        {

            txtAttributeValueID.Text = Convert.ToString(baseEO.AttributeValueID);

            if (GetId().Equals(0))
            {
            txtAttributeID.Text = Convert.ToString(GetP_order_id());
            }
            else
            { 
            txtAttributeID.Text = Convert.ToString(baseEO.AttributeID);
            }
            

            txtValue.Text = Convert.ToString(baseEO.Value);

            txtwebstore_id.Text = Convert.ToString(baseEO.webstore_id);

            if (baseEO.ID == 0)
            {
                baseEO.InsertENTUserAccountId = Convert.ToInt32(Session["AdminUserId"]);
            }
            else
            {
                baseEO.UpdateENTUserAccountId = Convert.ToInt32(Session["AdminUserId"]);
            }

            txtInsertENTUserAccountId.Text = Convert.ToString(baseEO.InsertENTUserAccountId);
            //Put the object in the view state so it can be attached back to the data context.
            ViewState[VIEW_STATE_KEY_AttributeValue] = baseEO;
        }

        protected override void LoadControls()
        {
        }
        protected override void GoToGridPage()
        {
            Response.Redirect("attribute.aspx" + EncryptQueryString("id=" + (txtAttributeID.Text)));
        } 
        public override string MenuItemName()
        {
            return "category";
        }
    }
}