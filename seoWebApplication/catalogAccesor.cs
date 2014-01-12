using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;
 
namespace seoWebApplication
{
    public class catalogAccesor
    {
        static catalogAccesor()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        // Search the product catalog
        public static DataTable Search(string searchString, string allWords, string pageNumber, out int howManyPages)
        {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccessor.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "SearchCatalog";
            // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DescriptionLength";
        param.Value = seoWebAppConfiguration.ProductDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@AllWords";
        param.Value = allWords.ToUpper() == "TRUE" ? "1" : "0";
        param.DbType = DbType.Byte;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = seoWebAppConfiguration.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyResults";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // define the maximum number of words
        int howManyWords = 5;
        // transform search string into array of words
        string[] words = Regex.Split(searchString, "[^a-zA-Z0-9]+");
        // add the words as stored procedure parameters
        int index = 1;
        for (int i = 0; i <= words.GetUpperBound(0) && index <= howManyWords; i++)
        // ignore short words
        if (words[i].Length > 2)
        {
        // create the @Word parameters
        param = comm.CreateParameter();
        param.ParameterName = "@Word" + index.ToString();
        param.Value = words[i];
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        index++;
        }
        // execute the stored procedure and save the results in a DataTable
        DataTable table = GenericDataAccessor.ExecuteSelectCommand(comm);
        // calculate how many pages of products and set the out parameter
        int howManyProducts =
        Int32.Parse(comm.Parameters["@HowManyResults"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)howManyProducts /
        (double)seoWebAppConfiguration.ProductsPerPage);
        // return the page of products
        return table;
        }
        // Retrieve the list of departments
        public static DataTable GetDepartments()
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "departmentSelectByWId";
            DbParameter param = comm.CreateParameter(); 
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@webstore_id";
            param.Value = dBHelper.GetWebstoreId();
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure and return the results
            return GenericDataAccessor.ExecuteSelectCommand(comm);
        }
        // get department details
        public static DepartmentDetails GetDepartmentDetails(string department_id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetDepartmentDetails";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@department_id";
            param.Value = department_id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure
            DataTable table = GenericDataAccessor.ExecuteSelectCommand(comm);
            // wrap retrieved data into a DepartmentDetails object
            DepartmentDetails details = new DepartmentDetails();
            if (table.Rows.Count > 0)
            {
                details.name = table.Rows[0]["name"].ToString();
                details.description = table.Rows[0]["description"].ToString();
            }
            // return department details
            return details;
        }

        // Get category details
        public static CategoryDetails GetCategoryDetails(string category_id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetCategoryDetails";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@category_id";
            param.Value = category_id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure
            DataTable table = GenericDataAccessor.ExecuteSelectCommand(comm);
            // wrap retrieved data into a CategoryDetails object
            CategoryDetails details = new CategoryDetails();
            if (table.Rows.Count > 0)
            {
                details.department_id = Int32.Parse(table.Rows[0]["department_id"].ToString());
                details.name = table.Rows[0]["name"].ToString();
                details.description = table.Rows[0]["description"].ToString();
            }
            // return department details
            return details;
        }

        // Get product details
        public static ProductDetails GetProductDetails(string product_id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetProductDetails";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@product_id";
            param.Value = product_id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure
            DataTable table = GenericDataAccessor.ExecuteSelectCommand(comm);
            // wrap retrieved data into a ProductDetails object
            ProductDetails details = new ProductDetails();
            if (table.Rows.Count > 0)
            {
                // get the first table row
                DataRow dr = table.Rows[0];
                // get product details
                details.product_id = int.Parse(product_id);
                details.name = dr["name"].ToString();
                details.description = dr["description"].ToString();
                details.price = Decimal.Parse(dr["price"].ToString());
                details.thumbnail = dr["thumbnail"].ToString();
                details.image = dr["image"].ToString();
                details.promofront = bool.Parse(dr["promofront"].ToString());
                details.promodept = bool.Parse(dr["promodept"].ToString());
            }
            // return department details
            return details;
        }
        // retrieve the list of categories in a department
        public static DataTable GetCategoriesInDepartment(string department_id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetCategoriesInDepartment";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@department_id";
            param.Value = department_id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure
            return GenericDataAccessor.ExecuteSelectCommand(comm);
        }

        // Retrieve the list of products on catalog promotion
        public static DataTable GetProductsOnFrontPromo(string pageNumber, out int howManyPages)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetProductsOnFrontPromo";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@DescriptionLength";
            param.Value = seoWebAppConfiguration.ProductDescriptionLength;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@webstore_id";
            param.Value = dBHelper.GetWebstoreId();
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@PageNumber";
            param.Value = pageNumber;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ProductsPerPage";
            param.Value = seoWebAppConfiguration.ProductsPerPage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@HowManyProducts";
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure and save the results in a DataTable
            DataTable table = GenericDataAccessor.ExecuteSelectCommand(comm);
            // calculate how many pages of products and set the out parameter
            int howManyProducts = Int32.Parse(comm.Parameters
            ["@HowManyProducts"].Value.ToString());
            howManyPages = (int)Math.Ceiling((double)howManyProducts /
            (double)seoWebAppConfiguration.ProductsPerPage);
            // return the page of products
            return table;
        }

        // retrieve the list of products featured for a department
        public static DataTable GetProductsOnDeptPromo(string department_id, string pageNumber, out int howManyPages)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetProductsOnDeptPromo";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@department_id";
            param.Value = department_id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@webstore_id";
            param.Value = dBHelper.GetWebstoreId();
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DescriptionLength";
            param.Value = seoWebAppConfiguration.ProductDescriptionLength;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@PageNumber";
            param.Value = pageNumber;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ProductsPerPage";
            param.Value = seoWebAppConfiguration.ProductsPerPage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@HowManyProducts";
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure and save the results in a DataTable
            DataTable table = GenericDataAccessor.ExecuteSelectCommand(comm);
            // calculate how many pages of products and set the out parameter
            int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());
            howManyPages = (int)Math.Ceiling((double)howManyProducts / (double)seoWebAppConfiguration.ProductsPerPage);
            // return the page of products
            return table;
        }
        // retrieve the list of products in a category
        public static DataTable GetProductsInCategory(string category_id, string pageNumber, out int howManyPages)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetProductsInCategory";
            
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@category_id";
            param.Value = category_id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@webstore_id";
            param.Value = dBHelper.GetWebstoreId();
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DescriptionLength";
            param.Value = seoWebAppConfiguration.ProductDescriptionLength;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@PageNumber";
            param.Value = pageNumber;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ProductsPerPage";
            param.Value = seoWebAppConfiguration.ProductsPerPage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@HowManyProducts";
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure and save the results in a DataTable
            DataTable table = GenericDataAccessor.ExecuteSelectCommand(comm);
            // calculate how many pages of products and set the out parameter
            int howManyProducts = Int32.Parse
            (comm.Parameters["@HowManyProducts"].Value.ToString());
            howManyPages = (int)Math.Ceiling((double)howManyProducts / (double)seoWebAppConfiguration.ProductsPerPage);
            // return the page of products
            return table;
        }

        // Retrieve the list of product attributes
        public static DataTable GetProductAttributes(string product_id)
        {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccessor.CreateCommand();
         
            // set the stored procedure name
        comm.CommandText = "CatalogGetProductAttributeValues";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@product_id";
        param.Value = product_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure and return the results
        return GenericDataAccessor.ExecuteSelectCommand(comm);
        }

        // Update department details
        public static bool UpdateDepartment(string id, string name, string description)
        {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccessor.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogUpdateDepartment";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DepartmentId";
        param.Value = id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
            // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@DepartmentName";
        param.Value = name;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@DepartmentDescription";
        param.Value = description;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);
        // result will represent the number of changed rows
        int result = -1;
        try
        {
        // execute the stored procedure
            result = GenericDataAccessor.ExecuteNonQuery(comm);
        }
        catch
        {
        // any errors are logged in GenericDataAccessor, we ignore them here
        }
        // result will be 1 in case of success
        return (result != -1);
        }
        // Delete department
        public static bool DeleteDepartment(string id)
        {
        // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogDeleteDepartment";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DepartmentId";
        param.Value = id;
        param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
        // execute the stored procedure; an error will be thrown by the
        // database if the department has related categories, in which case
        // it is not deleted
        int result = -1;
        try
        {
            result = GenericDataAccessor.ExecuteNonQuery(comm);
        }
        catch
        {
        // any errors are logged in GenericDataAccessor, we ignore them here
        }
        // result will be 1 in case of success
        return (result != -1);
        }
        // Add a new department
        public static bool AddDepartment(string name, string description)
        {
        // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogAddDepartment";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DepartmentName";
        param.Value = name;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@DepartmentDescription";
        param.Value = description;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);
         // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@webstore_id";
        param.Value = dBHelper.GetWebstoreId();
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccessor.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccessor, we ignore them here
        }
        // result will be 1 in case of success
        return (result != -1);
        }

        // Create a new Category
        public static bool CreateCategory(string department_id,
        string name, string description)
        {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccessor.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogCreateCategory";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@department_id";
        param.Value = department_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@CategoryName";
        param.Value = name;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@CategoryDescription";
        param.Value = description;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);
        // result will represent the number of changed rows
        int result = -1;
        try
        {
        // execute the stored procedure
            result = GenericDataAccessor.ExecuteNonQuery(comm);
        }
        catch
        {
        // any errors are logged in GenericDataAccessor, we ignore them here
        }
            // result will be 1 in case of success
        return (result != -1);
        }
        // Update category details
        public static bool UpdateCategory(string id, string name, string description)
        {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccessor.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogUpdateCategory";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@category_id";
        param.Value = id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@CategoryName";
        param.Value = name;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@CategoryDescription";
        param.Value = description;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);
        // result will represent the number of changed rows
        int result = -1;
        try
        {
        // execute the stored procedure
            result = GenericDataAccessor.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccessor, we ignore them here
        }
        // result will be 1 in case of success
        return (result != -1);
        }
        // Delete Category
        public static bool DeleteCategory(string id)
        {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccessor.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogDeleteCategory";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@category_id";
        param.Value = id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure; an error will be thrown by the
        // database if the Category has related categories, in which case
        // it is not deleted
        int result = -1;
        try
        {
            result = GenericDataAccessor.ExecuteNonQuery(comm);
        }
        catch
        {
            // any errors are logged in GenericDataAccessor, we ignore them here
        }
        // result will be 1 in case of success
        return (result != -1);
        }

        // retrieve the list of products in a category
        public static DataTable GetAllProductsInCategory(string category_id)
        {
        // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetAllProductsInCategory";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@category_id";
        param.Value = category_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure and save the results in a DataTable
        DataTable table = GenericDataAccessor.ExecuteSelectCommand(comm);
        return table;
        }
        // Create a new product
        public static bool CreateProduct(string category_id, string name, string description, string price, string thumbnail, string image, string promodept, string promofront)
        {
        // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogCreateProduct";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@category_id";
        param.Value = category_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@webstore_id";
        param.Value = dBHelper.GetWebstoreId();
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
            // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@productname";
        param.Value = name;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@productdescription";
        param.Value = description;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@price";
        param.Value = price;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@thumbnail";
        param.Value = thumbnail;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@image";
        param.Value = image;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@promofront";
        param.Value = promofront;
        param.DbType = DbType.Boolean;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@promodept";
        param.Value = promodept;
        param.DbType = DbType.Boolean;
        comm.Parameters.Add(param);
      
            // result will represent the number of changed rows
        int result = -1;
        try
        {
        // execute the stored procedure
            result = GenericDataAccessor.ExecuteNonQuery(comm);
        }
        catch
        {
        // any errors are logged in GenericDataAccessor, we ignore them here
        }
        // result will be 1 in case of success
        return (result >= 1);
        }
        // Update an existing product
        public static bool UpdateProduct(string product_id, string name, string description, string price, string thumbnail, string image, string promodept, string promofront)
        {
        // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogUpdateProduct";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@product_id";
        param.Value = product_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@productname";
        param.Value = name;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@productdescription";
        param.Value = description;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@price";
        param.Value = price;
                param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@thumbnail";
        param.Value = thumbnail;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@image";
        param.Value = image;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@promodept";
        param.Value = promodept;
        param.DbType = DbType.Boolean;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@promofront";
        param.Value = promofront;
        param.DbType = DbType.Boolean;
        comm.Parameters.Add(param);
        // result will represent the number of changed rows
        int result = -1;
        try
        {
        // execute the stored procedure
            result = GenericDataAccessor.ExecuteNonQuery(comm);
        }
        catch
        {
        // any errors are logged in GenericDataAccessor, we ignore them here
        }
        // result will be 1 in case of success
        return (result != -1);
        }

        // get categories that contain a specified product
        public static DataTable GetCategoriesWithProduct(string product_id)
        {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccessor.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetCategoriesWithProduct";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@product_id";
        param.Value = product_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure
        return GenericDataAccessor.ExecuteSelectCommand(comm);
        }

        // get categories that do not contain a specified product
        public static DataTable GetCategoriesWithoutProduct(string product_id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetCategoriesWithoutProduct";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@product_id";
            param.Value = product_id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure
            return GenericDataAccessor.ExecuteSelectCommand(comm);
        }

        // assign a product to a new category
        public static bool AssignProductToCategory(string product_id, string category_id)
        {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccessor.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogAssignProductToCategory";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@product_id";
        param.Value = product_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@category_id";
        param.Value = category_id;
        param.DbType = DbType.Int32;
                comm.Parameters.Add(param);
        // result will represent the number of changed rows
        int result = -1;
        try
        {
        // execute the stored procedure
        result = GenericDataAccessor.ExecuteNonQuery(comm);
        }
        catch
        {
        // any errors are logged in GenericDataAccessor, we ignore them here
        }
        // result will be 1 in case of success
        return (result != -1);
        }

        // move product to a new category
        public static bool MoveProductToCategory(string product_id, string oldcategory_id,
        string newcategory_id)
        {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccessor.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogMoveProductToCategory";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@product_id";
        param.Value = product_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Oldcategory_id";
        param.Value = oldcategory_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Newcategory_id";
        param.Value = newcategory_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // result will represent the number of changed rows
        int result = -1;
                try
        {
        // execute the stored procedure
        result = GenericDataAccessor.ExecuteNonQuery(comm);
        }
        catch
        {
        // any errors are logged in GenericDataAccessor, we ignore them here
        }
        // result will be 1 in case of success
        return (result != -1);
        }

        // removes a product from a category
        public static bool RemoveProductFromCategory(string product_id, string category_id)
        {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccessor.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogRemoveProductFromCategory";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@product_id";
        param.Value = product_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@category_id";
        param.Value = category_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // result will represent the number of changed rows
        int result = -1;
        try
        {
        // execute the stored procedure
        result = GenericDataAccessor.ExecuteNonQuery(comm);
        }
        catch
        {
        // any errors are logged in GenericDataAccessor, we ignore them here
        }
        // result will be 1 in case of success
        return (result != -1);
        }
        // deletes a product from the product catalog
        public static bool DeleteProduct(string product_id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogDeleteProduct";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@product_id";
            param.Value = product_id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = GenericDataAccessor.ExecuteNonQuery(comm);
            }
            catch
            {
                // any errors are logged in GenericDataAccessor, we ignore them here
            }
            // result will be 1 in case of success
            return (result != -1);
        }


        // gets product recommendations
        public static DataTable GetRecommendations(string productId)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetProductRecommendations";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@product_id";
            param.Value = productId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DescriptionLength";
            param.Value = seoWebAppConfiguration.ProductDescriptionLength;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure
            return GenericDataAccessor.ExecuteSelectCommand(comm);
        }

        // gets product recommendations
        public static DataTable GetAttributes(int controlTypeId)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "AttributeValueSelectByWId";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@webstore_id";
            param.Value = dBHelper.GetWebstoreId();
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@controlTypeId";
            param.Value = controlTypeId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            
            
            // execute the stored procedure
            return GenericDataAccessor.ExecuteSelectCommand(comm);
        }

        // gets product recommendations
        public static DataTable GetCustomAttributes(int controlTypeId, int productId)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "productGetCustomAttById";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@product_id";
            param.Value = productId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@controlTypeId";
            param.Value = controlTypeId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);


            // execute the stored procedure
            return GenericDataAccessor.ExecuteSelectCommand(comm);
        }
         
   }
}