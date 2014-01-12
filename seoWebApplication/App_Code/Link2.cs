using System;
using System.Web;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text.RegularExpressions;
/// <summary>
/// Link factory class
/// </summary>

 
    public class Link2
    {
        // regular expression that removes characters that aren't a-z, 0-9, dash,
        // underscore or space
        private static Regex purifyUrlRegex = new Regex("[^-a-zA-Z0-9_ ]", RegexOptions.Compiled);
        // regular expression that changes dashes, underscores and spaces to dashes
        private static Regex dashesRegex = new Regex("[-_ ]+", RegexOptions.Compiled);

        // prepares a string to be included in an URL
        private static string PrepareUrlText(string urlText)
        {
            // remove all characters that aren't a-z, 0-9, dash, underscore or space
            urlText = purifyUrlRegex.Replace(urlText, "");
            // remove all leading and trailing spaces
            urlText = urlText.Trim();
            // change all dashes, underscores and spaces to dashes
            urlText = dashesRegex.Replace(urlText, "-");
            // return the modified string
            return urlText;
        }
        // Builds an absolute URL
        private static string BuildAbsolute(string relativeUri)
        {
            // get current uri
            Uri uri = HttpContext.Current.Request.Url;
            // build absolute path
            string app = HttpContext.Current.Request.ApplicationPath;
            if (!app.EndsWith("/")) app += "/";
            relativeUri = relativeUri.TrimStart('/');
            // return the absolute path
            return HttpUtility.UrlPathEncode(
            String.Format("http://{0}:{1}{2}{3}",
            uri.Host, uri.Port, app, relativeUri));
        }
        // Generate a department URL
        // Generate a department URL
        public static string ToDepartment(string department_id, string page)
        {
            // prepare department URL name
            DepartmentDetails d = CatalogAccess.GetDepartmentDetails(department_id);
            string deptUrlName = PrepareUrlText(d.name);

            // build department URL
            if (page == "1")
                return BuildAbsolute(String.Format("{0}-d{1}/", deptUrlName, department_id));
            else
                return BuildAbsolute(String.Format("{0}-d{1}/Page={2}", deptUrlName, department_id, page));

        }
        // Generate a department URL for the first page
        public static string ToDepartment(string department_id)
        {
            return ToDepartment(department_id, "1");
        }
        public static string ToCategory(string department_id, string category_id, string page)
        {
            // prepare department and category URL names
            DepartmentDetails d = CatalogAccess.GetDepartmentDetails(department_id);
            string deptUrlName = PrepareUrlText(d.name);
            CategoryDetails c = CatalogAccess.GetCategoryDetails(category_id);
            string catUrlName = PrepareUrlText(c.name);

            // build category URL
            if (page == "1")
                return BuildAbsolute(String.Format("{0}-d{1}/{2}-c{3}/", deptUrlName, department_id, catUrlName, category_id));
            else
                return BuildAbsolute(String.Format("{0}-d{1}/{2}-c{3}/Page-{4}/", deptUrlName, department_id, catUrlName, category_id, page));
        }
        public static string ToCategory(string department_id, string category_id)
        {
            return ToCategory(department_id, category_id, "1");
        }
        public static string ToProduct(string product_id)
        {
            // prepare product URL name
            ProductDetails p = CatalogAccess.GetProductDetails(product_id.ToString());
            string prodUrlName = PrepareUrlText(p.name);
            // build product URL
            return BuildAbsolute(String.Format("{0}-p{1}/", prodUrlName, product_id));
        }
        public static string ToProductImage(string fileName)
        {
            // build product URL
            return BuildAbsolute("/ProductImages/" + fileName);
        }
    }
 
