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
    public partial class AdminProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Load the grid only the first time the page is loaded
            if (!Page.IsPostBack)
            {
            // Get category_id and department_id from the query string
                string category_id = Request.QueryString["category_id"];
                string department_id = Request.QueryString["department_id"];
            // Obtain the category name
            CategoryDetails cd = catalogAccesor.GetCategoryDetails(category_id);
            string categoryName = cd.name;
            //// Link to department
                catLink.Text = categoryName;
                catLink.NavigateUrl = "AdminCategories.aspx?department_id=" + department_id;
                // Load the products grid
            BindGrid();
            }
        }
        // Populate the GridView with data
        private void BindGrid()
        {
            // Get CategoryID from the query string
            string category_id = Request.QueryString["category_id"];
            // Get a DataTable object containing the products
            grid.DataSource = catalogAccesor.GetAllProductsInCategory(category_id);
            // Needed to bind the data bound controls to the data source
            grid.DataBind();
        }

        // Enter row into edit mode
        protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the row for which to enable edit mode
            grid.EditIndex = e.NewEditIndex;
            // Set status message
            statusLabel.Text = "Editing row # " + e.NewEditIndex.ToString();
            // Reload the grid
            BindGrid();
        }

        // Cancel edit mode
        protected void grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancel edit mode
            grid.EditIndex = -1;
            // Set status message
            statusLabel.Text = "Editing canceled";
            // Reload the grid
            BindGrid();
        }

        // Update a product
        protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
        // Retrieve updated data
        try
        {
        string id = grid.DataKeys[e.RowIndex].Value.ToString();
        string name = ((TextBox)grid.Rows[e.RowIndex].FindControl("nameTextBox")).Text;
        string description = ((TextBox)grid.Rows[e.RowIndex].FindControl("descriptionTextBox")).Text;
        string price = ((TextBox)grid.Rows[e.RowIndex].FindControl("priceTextBox")).Text;
        string thumbnail = ((TextBox)grid.Rows[e.RowIndex].FindControl("thumbTextBox")).Text;
        string image = ((TextBox)grid.Rows[e.RowIndex].FindControl("imageTextBox")).Text;
        string promodept = ((CheckBox)grid.Rows[e.RowIndex].Cells[6].Controls[0]).Checked.ToString();
        string promofront = ((CheckBox)grid.Rows[e.RowIndex].Cells[7].Controls[0]).Checked.ToString();
        // Execute the update command
        bool success = catalogAccesor.UpdateProduct(id, name, description, price, thumbnail, image, promodept, promofront);
        // Cancel edit mode
        grid.EditIndex = -1;
        // Display status message
        statusLabel.Text = success ? "Product update successful" : "Product update failed";
        }
        catch
        {
        // Display error
        statusLabel.Text = "Product update failed";
        }
        // Reload grid
        BindGrid();
        }

        // Create a new product
        protected void createProduct_Click(object sender, EventArgs e)
        {
        // Get CategoryID from the query string
            string category_id = Request.QueryString["category_id"];
        // Execute the insert command
            bool success = catalogAccesor.CreateProduct(category_id, newName.Text, newDescription.Text, newPrice.Text, newThumbnail.Text, newImage.Text, newPromoDept.Checked.ToString(), newPromoFront.Checked.ToString());
        // Display status message
        statusLabel.Text = success ? "Insert successful" : "Insert failed";
        // Reload the grid
        BindGrid();
        }
    }
}
