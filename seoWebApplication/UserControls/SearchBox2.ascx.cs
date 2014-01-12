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
    public partial class SearchBox2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // don't repopulate control on postbacks
            if (!IsPostBack)
            {
                // load search box controls' values
                string allWords = Request.QueryString["AllWords"];
                string searchString = Request.QueryString["Search"];
                if (allWords != null)
                    allWordsCheckBox.Checked = (allWords.ToUpper() == "TRUE");
                if (searchString != null)
                    searchTextBox.Text = searchString;
            }
        }

        protected void goButton_Click(object sender, EventArgs e)
        {
            ExecuteSearch();
        }

        // Redirect to the search results page
        private void ExecuteSearch()
        {
            string searchText = searchTextBox.Text;
            bool allWords = allWordsCheckBox.Checked;
            if (searchTextBox.Text.Trim() != "")
                Response.Redirect(Linkor.ToSearch(searchText, allWords, "1"));
        }

        
    }
}