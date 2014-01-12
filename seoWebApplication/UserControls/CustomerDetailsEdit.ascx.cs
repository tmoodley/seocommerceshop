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

namespace seoWebApplication.UserControls
{
    public partial class CustomerDetailsEdit : System.Web.UI.UserControl
    {

        public bool Editable
        {
            get
            {
                if (ViewState["editable"] != null)
                {
                    return (bool)ViewState["editable"];
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ViewState["editable"] = value;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            // Find and set edit button visibility
            Button EditButton =
            FormView1.FindControl("EditButton") as Button;
            if (EditButton != null)
            {
                EditButton.Visible = Editable;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}