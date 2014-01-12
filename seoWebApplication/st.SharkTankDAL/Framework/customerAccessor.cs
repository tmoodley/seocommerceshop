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
 

namespace seoWebApplication.st.SharkTankDAL
{
    public struct CustomerInfo
    {
        public int customer_id;
        public string name;
        public string address1;
        public string address2;
        public string city;
        public string region;
        public string zip;
        public string country;
        public string shippingRegion;
        public string dayPhone;
        public string evePhone;
        public string cellPhone;
        public string email; 
        public string username;
        public string password;
        public string creditCard;
        public string creditCardHolder;
        public string creditCardNumber;
        public string creditCardIssueDate;
        public string creditCardIssueNumber;
        public string creditCardExpiryDate;
        public string creditCardType;
    }

    public class customerAccessor
    {
        public customerAccessor()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 
        // get customer details 
        //public static CustomerInfo GetCustomerDetails(string customer_id)
        //{
        //    // get a configured DbCommand object
        //    DbCommand comm = GenericDataAccessor.CreateCommand();
        //    // set the stored procedure name
        //    comm.CommandText = "customerSelectById";
        //    // create a new parameter
        //    DbParameter param = comm.CreateParameter();
        //    param.ParameterName = "@customer_id";
        //    param.Value = customer_id;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);
              
        //    // obtain the results
        //    DataTable table = GenericDataAccessor.ExecuteSelectCommand(comm);
        //    DataRow custRow = table.Rows[0];
        //    // save the results into an OrderInfo object
        //    CustomerInfo custInfo;
        //    custInfo.customer_id = Int32.Parse(custRow["customer_id"].ToString());
        //    custInfo.name = custRow["name"].ToString();
        //    custInfo.address1 = custRow["address1"].ToString();
        //    custInfo.address2 = custRow["address2"].ToString();
        //    custInfo.region = custRow["region"].ToString();
        //    custInfo.zip = custRow["zip"].ToString();
        //    custInfo.country = custRow["country"].ToString();
        //    custInfo.shippingRegion = custRow["shippingRegion"].ToString();
        //    custInfo.dayPhone = custRow["dayPhone"].ToString();
        //    custInfo.cellPhone = custRow["cellPhone"].ToString();
        //    custInfo.evePhone = custRow["evePhone"].ToString();

        //    custInfo.creditCard = custRow["creditCard"].ToString();
        //    custInfo.username = custRow["username"].ToString();
        //    custInfo.password = custRow["password"].ToString();
        //    custInfo.email = custRow["email"].ToString();
        //    // return the custInfo object
        //    return custInfo;
  
         
            
        //}

        // Retrieve the list of customers
        public static DataTable GetCustomers()
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "customerSelectAll";
            // execute the stored procedure and return the results
            return GenericDataAccessor.ExecuteSelectCommand(comm);
        }

        // Create a new customer
        public static bool CreateCustomer(string name, string address1, string address2, string city, string region, string zip, string country, string shippingRegion, decimal dayPhone, decimal cellPhone, decimal evePhone, string creditCard, string username, string password, string email)
        {
            int customer_id;
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "customerInsert";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            //// create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@customer_id";
            param.Value = "";
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@name";
            param.Value = name;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@address1";
            param.Value = address1;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@address2";
            param.Value = address2;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@city";
            param.Value = city;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter  
            param = comm.CreateParameter();
            param.ParameterName = "@region";
            param.Value = region;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter  
            param = comm.CreateParameter();
            param.ParameterName = "@zip";
            param.Value = zip;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter  
            param = comm.CreateParameter();
            param.ParameterName = "@country";
            param.Value = country;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter  
            param = comm.CreateParameter();
            param.ParameterName = "@shippingRegion";
            param.Value = shippingRegion;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter 
            param = comm.CreateParameter();
            param.ParameterName = "@dayPhone";
            param.Value = dayPhone;
            param.DbType = DbType.Decimal;
            param.Size = 18;
            comm.Parameters.Add(param);
            // create a new parameter  
            param = comm.CreateParameter();
            param.ParameterName = "@cellPhone";
            param.Value = cellPhone;
            param.DbType = DbType.Decimal;
            param.Size = 18;
            comm.Parameters.Add(param);
            // create a new parameter  
            param = comm.CreateParameter();
            param.ParameterName = "@evePhone";
            param.Value = evePhone;
            param.DbType = DbType.Decimal;
            param.Size = 18;
            comm.Parameters.Add(param);
            // create a new parameter   
            param = comm.CreateParameter();
            param.ParameterName = "@creditCard";
            param.Value = creditCard;
            param.DbType = DbType.String;
            param.Size = 1000;
            comm.Parameters.Add(param);
            // create a new parameter  
            param = comm.CreateParameter();
            param.ParameterName = "@username";
            param.Value = username;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter   
            param = comm.CreateParameter();
            param.ParameterName = "@password";
            string hash1 = phasher.Hash(password);
            param.Value = hash1;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter  
            param = comm.CreateParameter();
            param.ParameterName = "@email";
            param.Value = email;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, and false otherwise
                GenericDataAccessor.ExecuteNonQuery(comm);
                return true;
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return false;
            }
        }

        // Update department details
        public static bool UpdateCustomer(int customer_id, string name, string address1, string address2, string city, string region, string zip, string country, string shippingRegion, decimal dayPhone, decimal cellPhone, decimal evePhone, string creditCard, string username, string password, string email)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "customerUpdate";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@customer_id";
            param.Value = customer_id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@name";
            param.Value = name;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@address1";
            param.Value = address1;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@address2";
            param.Value = address2;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@city";
            param.Value = city;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter  
            param = comm.CreateParameter();
            param.ParameterName = "@region";
            param.Value = region;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter  
            param = comm.CreateParameter();
            param.ParameterName = "@zip";
            param.Value = zip;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter  
            param = comm.CreateParameter();
            param.ParameterName = "@country";
            param.Value = country;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter  
            param = comm.CreateParameter();
            param.ParameterName = "@shippingRegion";
            param.Value = shippingRegion;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter 
            param = comm.CreateParameter();
            param.ParameterName = "@dayPhone";
            param.Value = dayPhone;
            param.DbType = DbType.Decimal;
            param.Size = 18;
            comm.Parameters.Add(param);
            // create a new parameter  
            param = comm.CreateParameter();
            param.ParameterName = "@cellPhone";
            param.Value = cellPhone;
            param.DbType = DbType.Decimal;
            param.Size = 18;
            comm.Parameters.Add(param);
            // create a new parameter  
            param = comm.CreateParameter();
            param.ParameterName = "@evePhone";
            param.Value = evePhone;
            param.DbType = DbType.Decimal;
            param.Size = 18;
            comm.Parameters.Add(param);
            // create a new parameter   
            param = comm.CreateParameter();
            param.ParameterName = "@creditCard";
            param.Value = creditCard;
            param.DbType = DbType.String;
            param.Size = 1000;
            comm.Parameters.Add(param);
            // create a new parameter  
            param = comm.CreateParameter();
            param.ParameterName = "@username";
            param.Value = username;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter   
            param = comm.CreateParameter();
            param.ParameterName = "@password";
            param.Value = password;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter  
            param = comm.CreateParameter();
            param.ParameterName = "@email";
            param.Value = email;
            param.DbType = DbType.String;
            param.Size = 50;
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

        // Delete customer 
        public static bool DeleteCustomer(string customer_id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "customerDelete";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@customer_id";
            param.Value = customer_id;
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
    }
}