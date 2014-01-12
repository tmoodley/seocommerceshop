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
    public partial class deleteProductCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = commonClasses.GetId();
            int pid = commonClasses.GetP_order_id();
            categoryEO.delProductToCategory(id, pid);
            string qryStr = StringHelpers.EncryptQueryString("id=" + id);
            Response.Redirect("product.aspx" + qryStr);
        
        }
    }
}