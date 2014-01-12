using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Web; 
using System.ServiceModel.Channels; 
using System.Data; 
using System.Data.SqlClient; 
using System.Web.Services;
using System.Xml;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Description;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.entObject;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.Framework;
using System.Reflection; 

namespace seoWebApplication.webservices
{
    /// <summary>
    /// Summary description for authenticateUser
    /// </summary>
    [WebService(Name = "Mini Passport", Description = "Web Service to Authenticate and Manage Users", Namespace = "devArticles")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
 
    [System.ComponentModel.ToolboxItem(false)]
  
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class authenticateUser : System.Web.Services.WebService
    {

        public class Product
        {
            public string product_id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
        }
 
        public class Cat
        {
            public string category_id { get; set; }
            public string description { get; set; }
            public string name { get; set; }
            public string department_id { get; set; }
        }

        public class Dept
        { 
            public string description { get; set; }
            public string name { get; set; }
            public string department_id { get; set; }
        }

        public class Orders
        {
            public int OrderID { get; set; } 
            public DateTime DateCreated { get; set; }
            public DateTime DateShipped { get; set; }
            public bool Verified { get; set; }
            public bool Completed { get; set; }
            public bool Canceled { get; set; }
            public string Comments { get; set; }
            public string CustomerName { get; set; }
            public string CustomerEmail { get; set; }
            public string ShippingAddress { get; set; }
            public int CustomerID { get; set; }
            public Nullable<int> Status { get; set; }
            public string AuthCode { get; set; }
            public string Reference { get; set; }
            public Nullable<int> TaxID { get; set; }
            public Nullable<int> ShippingID { get; set; }
            public decimal total { get; set; }
            public string cart_id { get; set; } 
        }

         // Caches the connection string
        const string connStr = "Data Source=db405206422.db.1and1.com;Initial Catalog=db405206422;Persist Security Info=True;User ID=dbo405206422;Password=seven764;"; 
        //const string connStr = "Data Source=TY-PC\\SQLEXPRESS;Initial Catalog=seowebapp;Persist Security Info=True;User ID=sa;Password=sa;"; 


        [WebMethod(Description = "Method to Authenticate Admin Users")]
        public bool AuthenticateAdmin(string username, string password)
        {
            try
            {
                UserAccountEO userAccount = new UserAccountEO();
                return userAccount.Login(username, password);
            }
            catch
            {
                // Handle an error by displaying the information.
                return false;
            }

        }
        [WebMethod(Description = "Method to Authenticate Users")]
        public bool AuthenticateCustomer(string username, string password)
        {
            try
            {
                customerEO customer = new customerEO();
                return customer.Login(username, password);
            }
            catch
            {
                // Handle an error by displaying the information.
                return false; 
            }
            
        }

        [WebMethod(Description = "Method to Add User")]
        public bool AddUser(string username, string password, string name, string email)
        {
            bool returnBool = false;
            SqlConnection dbConn = new SqlConnection(connStr);
            string sqlStr = "INSERT INTO users(username,password,name,email) values('" + username + "', '" + password + "', '" + name + "', '" + email + "');";
            SqlCommand dbCommand = new SqlCommand(sqlStr, dbConn);
            try
            {
                dbConn.Open();
                if (dbCommand.ExecuteNonQuery() != 0)
                {
                    returnBool = true;
                }
                returnBool = true;
            }
            catch
            {
                returnBool = false;
            }
            dbConn.Close();
            return returnBool;
        }

        [WebMethod(Description = "Show Connstr")]
        public string ShowConnection(string username, string password, string name, string email)
        {
            string returnBool = "";
            SqlConnection dbConn = new SqlConnection(connStr);
            string sqlStr = "INSERT INTO users(username,password,name,email) values('" + username + "', '" + password + "', '" + name + "', '" + email + "');";
            SqlCommand dbCommand = new SqlCommand(sqlStr, dbConn);
            try
            {
                dbConn.Open();
                if (dbCommand.ExecuteNonQuery() != 0)
                {
                    returnBool = connStr;
                }
                returnBool = connStr;
            }
            catch
            {
                returnBool = connStr;
            }
            dbConn.Close();
            return returnBool;
        }

        [WebMethod(Description = "Method to Delete User")]
        public bool DeleteUser(string username)
        {
            bool returnBool = false;
            SqlConnection dbConn = new SqlConnection(connStr);
            string sqlStr = "DELETE FROM users where username = '" + username + "';";
            SqlCommand dbCommand = new SqlCommand(sqlStr, dbConn);
            try
            {
                dbConn.Open();
                if (dbCommand.ExecuteNonQuery() != 0)
                {
                    returnBool = true;
                }
            }
            catch
            {
                returnBool = false;
            }
            dbConn.Close();
            return returnBool;
        }

        [WebMethod(Description = "Method to Edit User Information")]
        public bool EditUser(string username, string name, string email)
        {
            bool returnBool = false;
            SqlConnection dbConn = new SqlConnection(connStr);
            string sqlStr = "UPDATE users SET username = '" + username + "',name = '" + name + "',email= '" + email + "';";
            SqlCommand dbCommand = new SqlCommand(sqlStr, dbConn);
            try
            {
                dbConn.Open();
                if (dbCommand.ExecuteNonQuery() != 0)
                {
                    returnBool = true;
                }
            }
            catch
            {
                returnBool = false;
            }
            dbConn.Close();
            return returnBool;
        }

        [WebMethod(Description = "Method to Change User Password")]
        public bool ChangePassword(string username, string password)
        {
            bool returnBool = false;
            SqlConnection dbConn = new SqlConnection(connStr);
            string sqlStr = "UPDATE users SET password = '" + password + "';";
            SqlCommand dbCommand = new SqlCommand(sqlStr, dbConn);
            try
            {
                dbConn.Open();
                if (dbCommand.ExecuteNonQuery() != 0)
                {
                    returnBool = true;
                }
            }
            catch
            {
                returnBool = false;
            }
            dbConn.Close();
            return returnBool;
        }

        [WebMethod(Description = "Method to Obtain User Name")]
        public string ReturnName(string username)
        {
            SqlConnection dbConn = new SqlConnection(connStr);
            string sqlStr = "Select Name from users where username = '" + username + "';";
            dbConn.Open();
            SqlCommand dbCommand = new SqlCommand(sqlStr, dbConn);
            SqlDataReader dbReader = dbCommand.ExecuteReader();
            dbReader.Read();
            string _name = dbReader[0].ToString();
            dbReader.Close();
            dbConn.Close();
            return _name;
        }

        [WebMethod(Description = "Method to obtain User Email Address")]
        public string ReturnEmail(string username)
        {
            SqlConnection dbConn = new SqlConnection(connStr);
            string sqlStr = "Select email from users where username = '" + username + "';";
            dbConn.Open();
            SqlCommand dbCommand = new SqlCommand(sqlStr, dbConn);
            SqlDataReader dbReader = dbCommand.ExecuteReader();
            dbReader.Read();
            string _name = dbReader[0].ToString();
            dbReader.Close();
            dbConn.Close();
            return _name;
        }

        [WebMethod(Description = "Return All Current Makes")]
        public string ReturnMakes()
        {
            // Get All Records with NAME Parameter
            //DataTable dataTable = GenericDataAccessor.ExecuteDataTable("product");
            string page = "1";
            int howManyPages = 1;
            DataTable dataTable = catalogAccesor.GetProductsOnFrontPromo(page, out howManyPages);

            StringBuilder sbrXML = new StringBuilder();

            if (dataTable.Rows.Count > 0)
            {
                sbrXML.AppendLine("<MakeList>");

                foreach (DataRow objRow in dataTable.Rows)
                {
                    sbrXML.AppendLine("<Make><MakeID>[product_id]</MakeID><MakeName>[name]</MakeName></Make>");
                    sbrXML.Replace("[product_id]", objRow["product_id"].ToString());
                    sbrXML.Replace("[name]", objRow["name"].ToString());
                }
                sbrXML.AppendLine("</MakeList>");
            }
            else
            {
                // no data
                sbrXML.AppendLine("<makeList>");
                sbrXML.AppendLine("no data");
                sbrXML.AppendLine("</makeList>");
            }
            return sbrXML.ToString();
        }

        [WebMethod(Description = "Return All Departments")]
        public Dept[] ReturnDepartments()
        {
            departmentEOList deo = new departmentEOList();
            deo.Load();

            List<departmentEO> departments = deo;

            IEnumerable<Dept> QueryResult =
             from a in departments
             select new Dept
             { 
                 description = a.Description,
                 name = a.Name,
                 department_id = a.department_id.ToString()
             }
            ;


            return QueryResult.ToArray();

        }

        [WebMethod(Description = "Return All Categories")]
        public Cat[] ReturnCategoriesByDept(int deptid)
        {
            categoryEOList ceo = new categoryEOList();
            ceo.Load();

            List<categoryEO> categorys = ceo;

            IEnumerable<Cat> QueryResult =
             from a in categorys
             where a.department_id.Equals(deptid)
             select new Cat
             {
                 category_id = a.category_id.ToString(),
                 description = a.description,
                 name = a.name,
                 department_id = a.department_id.ToString()
             }
            ;


            return QueryResult.ToArray();

        }


        [WebMethod(Description = "Return All Categories")]
        public Cat[] ReturnCategories()
        {
            categoryEOList ceo = new categoryEOList();
            ceo.Load();

            List<categoryEO> categorys = ceo;

            IEnumerable<Cat> QueryResult =
             from a in categorys
             select new Cat
             {
                 category_id = a.category_id.ToString(),
                 description = a.description,
                 name = a.name,
                 department_id = a.department_id.ToString()
             }
            ;


            return QueryResult.ToArray(); 

        }

        [WebMethod(Description = "Return All Verified Orders")]
        public OrdersEO[] ReturnVerifiedOrders()
        {
            OrdersEOList oeo = new OrdersEOList();
            oeo.LoadVerified(); 
            return oeo.ToArray();  
        }

        [WebMethod(Description = "Return All Open Orders")]
        public OrdersEO[] ReturnOpenOrders()
        {
            OrdersEOList oeo = new OrdersEOList();
            oeo.Load(); 
            return oeo.ToArray();  
        }

        [WebMethod(Description = "Verify Order By Id")]
        public bool VerifyOrder(int idOrder)
        {
            try
            {
                OrdersEO oeo = new OrdersEO();
                oeo.Load(idOrder);
                oeo.Verified = true; 
                oeo.DateShipped = DateTime.Now;
                oeo.Save(false);

                return true;
            }
            catch
            {
                return false;
            }
          

        }

        [WebMethod(Description = "Return All Open Orders")]
        public OrderDetailEO[] ReturnOrderDetails(int idOrder)
        {
            OrderDetailEOList oeo = new OrderDetailEOList();
            oeo.Load(idOrder);

            return oeo.ToArray(); 

        }

        [WebMethod(Description = "Method to New Product")] 
        public bool AddProduct(string name, string description, decimal price, string thumbnail, string image, bool promofront, bool promodept, bool defaultAttribute, bool defaultAttCat, int insertENTUserAccountId)
        {
            bool returnBool;
            try
            { 
                productEO baseEO = new productEO();

                baseEO.webstore_id = Convert.ToInt32(dBHelper.GetWebstoreId());

                baseEO.name = name;

                baseEO.description = description;

                baseEO.price = Convert.ToDecimal(price);

                baseEO.thumbnail = thumbnail;

                baseEO.image = image;

                baseEO.promofront = promofront;
              
                baseEO.promodept = promodept; 

                baseEO.ID = 0;

                baseEO.defaultAttribute = defaultAttribute;

                baseEO.defaultAttCat = defaultAttCat;
                  
                if (!baseEO.SaveWs(insertENTUserAccountId, true))
                {
                    returnBool = false;
                }
                else
                {
                    returnBool = true;
                }
            }
            catch
            {
                returnBool = false;
            }
         
            return returnBool;
        }

        [WebMethod(Description = "Return All Current Makes")]
        public Product[] ReturnProducts()
        {
            // Get All Records with NAME Parameter
            string page = "1";
            int howManyPages = 1;
            DataTable dataTable = catalogAccesor.GetProductsOnFrontPromo(page, out howManyPages);

            List<Product> products = new List<Product>();
            
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow objRow in dataTable.Rows)
                {
                    Product product = new Product
                    {
                        product_id = objRow["product_id"].ToString(),
                        name = objRow["name"].ToString(),
                        description = objRow["description"].ToString()
                            
                    };
                    products.Add(product);
                }
            }

            return products.ToArray();
        }

       
    }
}
