using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq; 
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.Framework;

namespace seoWebApplication
{
    public partial class seoWebAppAdminEditPage : System.Web.UI.MasterPage
    {
        public delegate void ButtonClickedHandler(object sender, EventArgs e);

        public event ButtonClickedHandler DeleteButton_Click;
        public event ButtonClickedHandler SaveButton_Click;
        public event ButtonClickedHandler CancelButton_Click;

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteButton_Click != null)
            {
                DeleteButton_Click(sender, e);
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveButton_Click != null)
            {
                SaveButton_Click(sender, e);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (CancelButton_Click != null)
            {
                CancelButton_Click(sender, e);
            }
        }

        public ENTValidationErrors ValidationErrors
        {
            get
            {
                return ValidationErrorMessages1.ValidationErrors;
            }

            set
            {
                ValidationErrorMessages1.ValidationErrors = value;
            }
        }   

        
    }
}
