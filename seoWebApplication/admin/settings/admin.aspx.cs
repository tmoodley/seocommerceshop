using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.Framework; 

namespace seoWebApplication.admin.settings
{
    public partial class admin : BaseEditPage<UserAccountEO>
    {
        private const string VIEW_STATE_KEY_UserAccount = "UserAccount";
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
            UserAccountEO UserAccountEO = (UserAccountEO)ViewState[VIEW_STATE_KEY_UserAccount];
            LoadObjectFromScreen(UserAccountEO);
            if (!UserAccountEO.Save(ref validationErrors, 1))
            {
                //Master.ValidationErrors = validationErrors;
            }
            else
            {
                GoToGridPage();
            }
        }

        protected override void LoadObjectFromScreen(UserAccountEO baseEO)
        {

            baseEO.UserAccountId = Convert.ToInt32(txtUserAccountId.Text);

            baseEO.IsActive = chkIsActive.Checked;

            baseEO.AccountName = txtAccountName.Text;

            baseEO.FirstName = txtFirstName.Text;

            baseEO.LastName = txtLastName.Text;

            baseEO.Email = txtEmail.Text;

            baseEO.Password = phasher.Hash(txtPassword.Text);  

            baseEO.webstore_id = Convert.ToInt32(txtwebstore_id.Text);

            UserAccountEO UserAccountEO = (UserAccountEO)ViewState[VIEW_STATE_KEY_UserAccount];
            baseEO.ID = UserAccountEO.UserAccountId;

            if (baseEO.ID == 0)
            {
                baseEO.InsertENTUserAccountId = Convert.ToInt32(Session["AdminUserId"]);
            }
            else
            {
                baseEO.UpdateENTUserAccountId = Convert.ToInt32(Session["AdminUserId"]);
            }
        }

        protected override void LoadScreenFromObject(UserAccountEO baseEO)
        {

            txtUserAccountId.Text = Convert.ToString(baseEO.UserAccountId);

            chkIsActive.Checked = baseEO.IsActive;

            txtAccountName.Text = Convert.ToString(baseEO.AccountName);

            txtFirstName.Text = Convert.ToString(baseEO.FirstName);

            txtLastName.Text = Convert.ToString(baseEO.LastName);

            txtEmail.Text = Convert.ToString(baseEO.Email);

            txtPassword.Text = Convert.ToString(baseEO.Password);

            txtwebstore_id.Text = Convert.ToString(dBHelper.GetWebstoreId());

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
            ViewState[VIEW_STATE_KEY_UserAccount] = baseEO;
        }

        protected override void LoadControls()
        {
        }
        protected override void GoToGridPage()
        {
            Response.Redirect("admins.aspx");
        }

        public void ReloadPage()
        {
            UserAccountEO UserAccountEO = (UserAccountEO)ViewState[VIEW_STATE_KEY_UserAccount];
            Response.Redirect("admin.aspx" + EncryptQueryString("id=" + (UserAccountEO.UserAccountId)));
        }

        public override string MenuItemName()
        {
            return "admin";
        }

    }
}