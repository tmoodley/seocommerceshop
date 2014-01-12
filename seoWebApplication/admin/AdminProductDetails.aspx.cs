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
    public partial class AdminProductDetails : System.Web.UI.Page
    {
        // store product, category, and department IDs as class members
        private string currentProductId, currentCategoryId, currentDepartmentId;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get DepartmentID, CategoryID, and ProductID from the query string
            // and save their values
            currentDepartmentId = Request.QueryString["department_id"];
            currentCategoryId = Request.QueryString["category_id"];
            currentProductId = Request.QueryString["product_id"];
            // Fill the controls with data only on the initial page load
            if (!IsPostBack)
            {
                // Fill controls with data
                PopulateControls();
            }
        }

        // Populate the controls
        private void PopulateControls()
        {
        // Retrieve product details and category details from database
        ProductDetails productDetails = catalogAccesor.GetProductDetails(currentProductId);
        CategoryDetails categoryDetails = catalogAccesor.GetCategoryDetails(currentCategoryId);
        // Set up labels and images
        productNameLabel.Text = productDetails.name;
        image1.ImageUrl = Linkor.ToProductImage(productDetails.thumbnail);
        image2.ImageUrl = Linkor.ToProductImage(productDetails.image);
        // Link to department
        catLink.Text = categoryDetails.name;
        catLink.NavigateUrl = "AdminCategories.aspx?department_id=" + currentDepartmentId;
        // Clear form
        categoriesLabel.Text = "";
        categoriesListAssign.Items.Clear();
        categoriesListMove.Items.Clear();
        categoriesListRemove.Items.Clear();
        // Fill categoriesLabel and categoriesListRemove with data
        string category_id, categoryName;
        DataTable productCategories = catalogAccesor.GetCategoriesWithProduct(currentProductId);
        for (int i = 0; i < productCategories.Rows.Count; i++)
        {
        // obtain category id and name
        category_id = productCategories.Rows[i]["category_id"].ToString();
        categoryName = productCategories.Rows[i]["name"].ToString();
        // add a link to the category admin page
        categoriesLabel.Text +=
        (categoriesLabel.Text == "" ? "" : ", ") +
        "<a href='AdminProducts.aspx?department_id=" +
        catalogAccesor.GetCategoryDetails(currentCategoryId).department_id +
        "&category_id=" + category_id + "'>" +
        categoryName + "</a>";
        // populate the categoriesListRemove combo box
        categoriesListRemove.Items.Add(new ListItem(categoryName, category_id));
        }
            // Delete from catalog or remove from category?
        if (productCategories.Rows.Count > 1)
        {
        deleteButton.Visible = false;
        removeButton.Enabled = true;
        }
        else
        {
        deleteButton.Visible = true;
        removeButton.Enabled = false;
        }
        // Fill categoriesListMove and categoriesListAssign with data
        productCategories = catalogAccesor.GetCategoriesWithoutProduct(currentProductId);
        for (int i = 0; i < productCategories.Rows.Count; i++)
        {
        // obtain category id and name
            category_id = productCategories.Rows[i]["category_id"].ToString();
        categoryName = productCategories.Rows[i]["name"].ToString();
        // populate the list boxes
        categoriesListAssign.Items.Add(new ListItem(categoryName, category_id));
        categoriesListMove.Items.Add(new ListItem(categoryName, category_id));
        }
        }

        protected void removeButton_Click(object sender, EventArgs e)
        {
            // Check if a category was selected
            if (categoriesListRemove.SelectedIndex != -1)
                {
                // Get the category ID that was selected in the DropDownList
                string categoryId = categoriesListRemove.SelectedItem.Value;
                // Remove the product from the category
                bool success = catalogAccesor.RemoveProductFromCategory(currentProductId, categoryId);
                 
                // Display status message
                statusLabel.Text = success ? "Product removed successfully": "Product removal failed";
                // Refresh the page
                PopulateControls();
                }
                else
                statusLabel.Text = "You need to select a category";
                }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            // Delete the product from the catalog
            catalogAccesor.DeleteProduct(currentProductId);
            // Need to go back to the categories page now
            Response.Redirect("AdminDepartments.aspx");
        }

        protected void assignButton_Click(object sender, EventArgs e)
        {
        // Check if a category was selected
        if (categoriesListAssign.SelectedIndex != -1)
        {
        // Get the category ID that was selected in the DropDownList
        string categoryId = categoriesListAssign.SelectedItem.Value;
        // Assign the product to the category
        bool success = catalogAccesor.AssignProductToCategory(currentProductId, categoryId);
        // Display status message
        statusLabel.Text = success ? "Product assigned successfully": "Product assignation failed";
        // Refresh the page
        PopulateControls();
        }
        else
        statusLabel.Text = "You need to select a category";
        }

        protected void moveButton_Click(object sender, EventArgs e)
        {
        // Check if a category was selected
        if (categoriesListMove.SelectedIndex != -1)
        {
        // Get the category ID that was selected in the DropDownList
        string newCategoryId = categoriesListMove.SelectedItem.Value;
        // Move the product to the category
        bool success = catalogAccesor.MoveProductToCategory(currentProductId, currentCategoryId, newCategoryId);
        // If the operation was successful, reload the page,
        // so the new category will reflect in the query string
        if (!success)
        statusLabel.Text = "Couldn't move the product to the specified category";
        else
        Response.Redirect("AdminProductDetails.aspx" +
        "?department_id=" + currentDepartmentId +
        "&category_id=" + newCategoryId +
        "&product_id=" + currentProductId);
        }
        else
        statusLabel.Text = "You need to select a category";
        }

        protected void upload1Button_Click(object sender, EventArgs e)
        {
        // proceed with uploading only if the user selected a file
        if (image1FileUpload.HasFile)
        {
        try
        {
        string fileName = image1FileUpload.FileName;
        string location = Server.MapPath("~/ProductImages/") + fileName;
        // save image to server
        image1FileUpload.SaveAs(location);

        //string filename = Path.GetFileName(image1FileUpload.FileName);
        //image1FileUpload.SaveAs(Server.MapPath("~/") + filename);
        


        // update database with new product details
        ProductDetails pd = catalogAccesor.GetProductDetails(currentProductId);
        catalogAccesor.UpdateProduct(currentProductId, pd.name, pd.description, pd.price.ToString(), fileName, pd.image, pd.promodept.ToString(), pd.promofront.ToString());
        // reload the page
        Response.Redirect("AdminProductDetails.aspx" +
        "?department_id=" + currentDepartmentId +
        "&category_id=" + currentCategoryId +
        "&product_id=" + currentProductId);
        }
        catch
        {
        statusLabel.Text = "Uploading image 1 failed";
        }
        }
        }

        protected void upload2Button_Click(object sender, EventArgs e)
        {
        // proceed with uploading only if the user selected a file
        if (image2FileUpload.HasFile)
        {
        try
        {
        string fileName = image2FileUpload.FileName;
        string location = Server.MapPath("~/ProductImages/") + fileName;
        // save image to server
        image2FileUpload.SaveAs(location);
        // update database with new product details
        ProductDetails pd = catalogAccesor.GetProductDetails(currentProductId);
        catalogAccesor.UpdateProduct(currentProductId, pd.name, pd.description, pd.price.ToString(), pd.thumbnail, fileName, pd.promodept.ToString(), pd.promofront.ToString());
        // reload the page
        Response.Redirect("AdminProductDetails.aspx" +
        "?department_id=" + currentDepartmentId +
        "&category_id=" + currentCategoryId +
        "&product_id=" + currentProductId);
        }
        catch
        {
        statusLabel.Text = "Uploading image 2 failed";
        }
        }
        }
        
         
    }
}
