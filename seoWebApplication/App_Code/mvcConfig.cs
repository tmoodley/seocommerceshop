using System.Configuration;
/// <summary>
/// Repository for BalloonShop configuration settings
/// </summary>

 
    public static class mvcConfig
    { 
        // Store the number of products per page
        private readonly static int productsPerPage;
        // Store the product description length for product lists
        private readonly static int productDescriptionLength;
        // Store the product description length for product lists
        private readonly static int idWebstore;
        // Store the name of your shop
        private readonly static string siteName;
        // Store the product description length for product lists
        private readonly static string appVersion;
        static mvcConfig()
        {
            appVersion = ConfigurationManager.AppSettings["Version"]; 
            idWebstore = System.Int32.Parse(ConfigurationManager.AppSettings["idSeoWebstore"]); 
            productsPerPage = System.Int32.Parse(ConfigurationManager.AppSettings["ProductsPerPage"]);
            productDescriptionLength = System.Int32.Parse(ConfigurationManager.AppSettings["ProductDescriptionLength"]);
            siteName = ConfigurationManager.AppSettings["SiteName"];
        }

        // Returns the appVersion
        public static string AppVersion
        {
            get
            {
                return appVersion;
            }
        } 

        // Returns the connection string for the BalloonShop database
        public static int IdWebstore
        {
            get
            {
                return idWebstore;
            }
        } 
        
        // Returns the maximum number of products to be displayed on a page
        public static int ProductsPerPage
        {
            get
            {
                return productsPerPage;
            }
        }
        // Returns the length of product descriptions in products lists
        public static int ProductDescriptionLength
        {
            get
            {
                return productDescriptionLength;
            }
        }
        // Returns the length of product descriptions in products lists
        public static string SiteName
        {
            get
            {
                return siteName;
            }
        }

        // Returns the address of the mail server
        public static string MailServer
        {
            get
            {
                return ConfigurationManager.AppSettings["MailServer"];
            }
        }
        // Returns the email username
        public static string MailUsername
        {
            get
            {
                return ConfigurationManager.AppSettings["MailUsername"];
            }
        }
        // Returns the email password
        public static string MailPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["MailPassword"];
            }
        }
        // Returns the email password
        public static string MailFrom
        {
            get
            {
                return ConfigurationManager.AppSettings["MailFrom"];
            }
        }
        // Send error log emails?
        public static bool EnableErrorLogEmail
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings
                ["EnableErrorLogEmail"]);
            }
        }
        // Returns the email address where to send error reports
        public static string ErrorLogEmail
        {
            get
            {
                return ConfigurationManager.AppSettings["ErrorLogEmail"];
            }
        }

        // The PayPal shopping cart URL
        public static string PaypalUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["PaypalUrl"];
            }
        }
        // The PayPal email account
        public static string PaypalEmail
        {
            get
            {
                return ConfigurationManager.AppSettings["PaypalEmail"];
            }
        }
        // Currency code (such as USD)
        public static string PaypalCurrency
        {
            get
            {
                return ConfigurationManager.AppSettings["PaypalCurrency"];
            }
        }
        // Return URL after a successful transaction
        public static string PaypalReturnUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["PaypalReturnUrl"];
            }
        }
        // Return URL after a canceled transaction
        public static string PaypalCancelUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["PaypalCancelUrl"];
            }
        }

        // Returns the number of days for shopping cart expiration
        public static int CartPersistDays
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["CartPersistDays"]);
            }
        }

        // Returns the email address for customers to contact the site
        public static string CustomerServiceEmail
        {
            get
            {
                return
                ConfigurationManager.AppSettings["CustomerServiceEmail"];
            }
        }
        // The "from" address for auto-generated order processor emails
        public static string OrderProcessorEmail
        {
            get
            {
                return
                ConfigurationManager.AppSettings["OrderProcessorEmail"];
            }
        }

        // The email address to use to contact the supplier
        public static string SupplierEmail
        {
            get
            {
                return ConfigurationManager.AppSettings["SupplierEmail"];
            }
        }
    }
 