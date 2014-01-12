using System;
using System.Data;
using System.Data.Common;
 
/// <summary>
/// Product catalog business tier component
/// </summary>
 

    public class CatalogAccess
    {
        static CatalogAccess()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        // Retrieve the list of departments
        public static DataTable GetDepartments()
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "departmentSelectAll";
            // execute the stored procedure and return the results
            return GenericDataAccess.ExecuteSelectCommand(comm);
        }
        // get department details
        public static DepartmentDetails GetDepartmentDetails(string department_id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetDepartmentDetails";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@department_id";
            param.Value = department_id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
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
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetCategoryDetails";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@category_id";
            param.Value = category_id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
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
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetProductDetails";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@product_id";
            param.Value = product_id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
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
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetCategoriesInDepartment";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@department_id";
            param.Value = department_id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure
            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        // Retrieve the list of products on catalog promotion
        public static DataTable GetProductsOnFrontPromo(string pageNumber, out int howManyPages)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
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
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
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
            DbCommand comm = GenericDataAccess.CreateCommand();
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
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
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
            DbCommand comm = GenericDataAccess.CreateCommand();
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
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            // calculate how many pages of products and set the out parameter
            int howManyProducts = Int32.Parse
            (comm.Parameters["@HowManyProducts"].Value.ToString());
            howManyPages = (int)Math.Ceiling((double)howManyProducts / (double)seoWebAppConfiguration.ProductsPerPage);
            // return the page of products
            return table;
        }
    }
 