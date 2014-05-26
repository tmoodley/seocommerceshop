using seoWebApplication.Data;
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
    public partial class AdminPictures : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public string productId;
        public void LoadProductPictures(int id)
        {
            productId = id.ToString();
            SeoWebAppEntities db = new SeoWebAppEntities();
            var pictures = (from p in db.Pictures where p.ProductFK == id select p).ToList();
            list.DataSource = pictures;
            list.DataBind(); 
        }
    }
}