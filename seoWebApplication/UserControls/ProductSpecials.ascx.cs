using seoWebApplication.Data;
using seoWebApplication.st.SharkTankDAL;
using System;
using System.Collections;
using System.Collections.Generic;
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
    public partial class ProductSpecials : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            LoadProductSpecials(); 
        }

        public void LoadProductSpecials()
        {
            // display product recommendations
            SeoWebAppEntities db = new SeoWebAppEntities();
            int webId = dBHelper.GetWebstoreId();
            List<seoWebApplication.Data.product> prods = (from prd in db.products where prd.webstore_id == webId select prd).Take(3).ToList();
   
            list.DataSource = prods;
            list.DataBind(); 
        }

    }
}