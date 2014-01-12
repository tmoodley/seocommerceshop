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
    public partial class addGeoMap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddCord_Click(object sender, EventArgs e)
        {
            ENTValidationErrors validationErrors = new ENTValidationErrors();
            webstoreEO webstore = new webstoreEO();
            webstore.Load(dBHelper.GetWebstoreId());
            webstore.polygonArray = this.txtlocations.Text;
         
            if (!webstore.Save(ref validationErrors, 1))
            {
                
                Master.ValidationErrors = validationErrors;
            }
            else
            {
                GoToGridPage();
            }
        }

        protected void GoToGridPage()
        {
            Response.Redirect("viewDeliveryZone.aspx");
        }
    }
}