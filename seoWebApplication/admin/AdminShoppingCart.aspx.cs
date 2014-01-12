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

namespace seoWebApplication
{
    public partial class AdminShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            byte days = byte.Parse(daysList.SelectedItem.Value);
            ShoppingCartAccess.DeleteOldCarts(days);
            countLabel.Text = "The old shopping carts were removed from the database";
        }

        protected void countButton_Click(object sender, EventArgs e)
        {
            byte days = byte.Parse(daysList.SelectedItem.Value);
            int oldItems = ShoppingCartAccess.CountOldCarts(days);
            if (oldItems == -1)
                countLabel.Text = "Could not count the old shopping carts!";
            else if (oldItems == 0)
                countLabel.Text = "There are no old shopping carts.";
            else
                countLabel.Text = "There are " + oldItems.ToString() +
                " old shopping carts.";
        }

        
    }
}
