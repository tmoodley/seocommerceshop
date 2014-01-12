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
    public partial class category : BaseEditPage<categoryEO>
    {
        private const string VIEW_STATE_KEY_category = "category";
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SaveButton_Click += new seoWebAppAdminEditPage.ButtonClickedHandler(Master_SaveButton_Click);
            Master.CancelButton_Click += new seoWebAppAdminEditPage.ButtonClickedHandler(Master_CancelButton_Click);
            Master.DeleteButton_Click += new seoWebAppAdminEditPage.ButtonClickedHandler(Master_DeleteButton_Click);

        }

        void Master_DeleteButton_Click(object sender, EventArgs e)
        {
            ENTValidationErrors validationErrors = new ENTValidationErrors();
            categoryEO category = (categoryEO)ViewState[VIEW_STATE_KEY_category];
            LoadObjectFromScreen(category);

            category.DBAction = ENTBaseEO.DBActionEnum.Delete;

            if (!category.Delete(ref validationErrors, 1))
            { 
                Master.ValidationErrors = validationErrors;
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
            categoryEO category = (categoryEO)ViewState[VIEW_STATE_KEY_category];
            LoadObjectFromScreen(category);
            if (!category.Save(ref validationErrors, 1))
            {
                //Master.ValidationErrors = validationErrors;
            }
            else
            {
                GoToGridPage();
            }
        }

        protected override void LoadObjectFromScreen(categoryEO baseEO)
        {

            baseEO.department_id = Convert.ToInt32(this.ddlDepartments.SelectedValue);

            baseEO.webstore_id = Convert.ToInt32(txtwebstore_id.Text);

            baseEO.name = txtname.Text;

            baseEO.description = txtdescription.Text;

            categoryEO category = (categoryEO)ViewState[VIEW_STATE_KEY_category];

            baseEO.ID = category.category_id;

            if (baseEO.ID == 0)
            {
                baseEO.InsertENTUserAccountId = Convert.ToInt32(Session["AdminUserId"]);
            }
            else
            {
                baseEO.UpdateENTUserAccountId = Convert.ToInt32(Session["AdminUserId"]);
            }
             
        }

        protected override void LoadScreenFromObject(categoryEO baseEO)
        { 

            loadDdlDept(ddlDepartments, baseEO.department_id);

            txtwebstore_id.Text = Convert.ToString(dBHelper.GetWebstoreId());

            txtname.Text = Convert.ToString(baseEO.name);

            txtdescription.Text = Convert.ToString(baseEO.description);

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
            ViewState[VIEW_STATE_KEY_category] = baseEO;
        }

        protected override void LoadControls()
        {
        }
        protected override void GoToGridPage()
        {
            Response.Redirect("categories.aspx");
        }

        public void ReloadPage()
        {
            categoryEO category = (categoryEO)ViewState[VIEW_STATE_KEY_category];
            Response.Redirect("category.aspx" + EncryptQueryString("id=" + (category.category_id)));
        }

        public override string MenuItemName()
        {
            return "category";
        }
    }
}