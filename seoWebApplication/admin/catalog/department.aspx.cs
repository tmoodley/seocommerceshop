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
    public partial class department : BaseEditPage<departmentEO>
    {
        private const string VIEW_STATE_KEY_department = "department";
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SaveButton_Click += new seoWebAppAdminEditPage.ButtonClickedHandler(Master_SaveButton_Click);
            Master.CancelButton_Click += new seoWebAppAdminEditPage.ButtonClickedHandler(Master_CancelButton_Click);
            Master.DeleteButton_Click += new seoWebAppAdminEditPage.ButtonClickedHandler(Master_DeleteButton_Click);

            if (!IsPostBack)
            {
            }
        }

        void Master_DeleteButton_Click(object sender, EventArgs e)
        {
            ENTValidationErrors validationErrors = new ENTValidationErrors();
            departmentEO department = (departmentEO)ViewState[VIEW_STATE_KEY_department];
            LoadObjectFromScreen(department);

            department.DBAction = ENTBaseEO.DBActionEnum.Delete;

            if (!department.Delete(ref validationErrors, 1))
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
            departmentEO department = (departmentEO)ViewState[VIEW_STATE_KEY_department];
            LoadObjectFromScreen(department);
            if (!department.Save(ref validationErrors, 1))
            {
                //Master.ValidationErrors = validationErrors;
            }
            else
            {
                GoToGridPage();
            }
        }

        protected override void LoadObjectFromScreen(departmentEO baseEO)
        {

            baseEO.webstore_id = Convert.ToInt32(txtwebstore_id.Text);

            baseEO.Description = txtDescription.Text;

            baseEO.Name = txtName.Text;

            departmentEO department = (departmentEO)ViewState[VIEW_STATE_KEY_department];

            baseEO.ID = department.department_id;

            if (baseEO.ID == 0)
            {
                baseEO.InsertENTUserAccountId = Convert.ToInt32(Session["AdminUserId"]);
            }
            else
            {
                baseEO.UpdateENTUserAccountId = Convert.ToInt32(Session["AdminUserId"]);
            }
        }

        protected override void LoadScreenFromObject(departmentEO baseEO)
        {

            txtwebstore_id.Text = Convert.ToString(baseEO.webstore_id);

            txtDescription.Text = Convert.ToString(baseEO.Description);

            txtName.Text = Convert.ToString(baseEO.Name);

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
            ViewState[VIEW_STATE_KEY_department] = baseEO;
        }

        protected override void LoadControls()
        {
        }
        protected override void GoToGridPage()
        {
            Response.Redirect("departments.aspx");
        }

        public void ReloadPage()
        {
            departmentEO department = (departmentEO)ViewState[VIEW_STATE_KEY_department];
            Response.Redirect("department.aspx" + EncryptQueryString("id=" + (department.department_id)));
        }

        public override string MenuItemName()
        {
            return "department";
        }
    }
}