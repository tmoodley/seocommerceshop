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
    public partial class MapLocation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadProductRecommendations(string productId)
        {
            // display product recommendations
            DataTable table = catalogAccesor.GetRecommendations(productId);
            if (table.Rows.Count > 0)
            {

                repeaterList.DataSource = table;
                repeaterList.DataBind();
            }
        }

        public void LoadCartRecommendations()
        {
            // display product recommendations
            DataTable table = ShoppingCartAccess.GetRecommendations();
            if (table.Rows.Count > 0)
            {

                repeaterList.DataSource = table;
                repeaterList.DataBind();
            }
        }
    }
}