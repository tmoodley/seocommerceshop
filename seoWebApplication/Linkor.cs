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
  
namespace seoWebApplication
{
    public class Linkor
    {

        // regular expression that removes characters that aren't a-z, 0-9, dash,
        // underscore or space
        private static Regex purifyUrlRegex = new Regex("[^-a-zA-Z0-9_ ]", RegexOptions.Compiled);
        // regular expression that changes dashes, underscores and spaces to dashes
        private static Regex dashesRegex = new Regex("[-_ ]+",RegexOptions.Compiled);

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
        public static string ToDepartment(string department_id, string page)
        {
            // prepare department URL name
            DepartmentDetails d = catalogAccesor.GetDepartmentDetails(department_id);
            string deptUrlName = PrepareUrlText(d.name);

            // build department URL
            if (page == "1")
                return BuildAbsolute(String.Format("{0}-d{1}.html", deptUrlName, department_id));
            else
                return BuildAbsolute(String.Format("{0}-d{1}-Page-{2}.html", deptUrlName, department_id, page));

        }
        // Generate a department URL for the first page
        public static string ToDepartment(string department_id)
        {
            return ToDepartment(department_id, "1");
        }
        public static string ToCategory(string department_id, string category_id, string page)
        {
            // prepare department and category URL names
            DepartmentDetails d = catalogAccesor.GetDepartmentDetails(department_id);
            string deptUrlName = PrepareUrlText(d.name);
            CategoryDetails c = catalogAccesor.GetCategoryDetails(category_id);
            string catUrlName = PrepareUrlText(c.name);

            // build category URL
            if (page == "1")
                return BuildAbsolute(String.Format("{0}-d{1}-{2}-c{3}.html", deptUrlName, department_id, catUrlName, category_id));
            else
                return BuildAbsolute(String.Format("{0}-d{1}-{2}-c{3}-Page-{4}.html", deptUrlName, department_id, catUrlName, category_id, page));
        }
        public static string ToCategory(string department_id, string category_id)
        {
            return ToCategory(department_id, category_id, "1");
        }
        public static string ToProduct(string product_id)
        {
            // prepare product URL name
            ProductDetails p = catalogAccesor.GetProductDetails(product_id.ToString());
            string prodUrlName = PrepareUrlText(p.name);
            // build product URL
            return BuildAbsolute(String.Format("{0}-p{1}.html", prodUrlName, product_id));
        }
        public static string ToProductImage(string fileName)
        {
            // build product URL
            if (fileName.Length <= 0) {
                fileName = "Coming-Soon.gif";
            }
            return BuildAbsolute("/ProductImages/" + fileName);
        }

        // 301 redirects to correct product URL if not already there
        public static void CheckProductUrl(string product_id)
        {
            // get requested URL
            HttpContext context = HttpContext.Current;
            string requestedUrl = context.Request.RawUrl;
            // get last part of proper URL
            string properUrl = Linkor.ToProduct(product_id);
            string properUrlTrunc = properUrl.Substring(Math.Abs(properUrl.Length - requestedUrl.Length));
            // 301 redirect to the proper URL if necessary
            if (requestedUrl != properUrlTrunc)
            {
                context.Response.Status = "301 Moved Permanently";
                context.Response.AddHeader("Location", properUrl);
            }
        }
        public static string ToSearch(string searchString, bool allWords, string page)
        {
            if (page == "1")
                return BuildAbsolute(
                String.Format("/Search.aspx?Search={0}&AllWords={1}",
                searchString, allWords.ToString()));
            else
                return BuildAbsolute(
                String.Format("/Search.aspx?Search={0}&AllWords={1}&Page={2}",
                searchString, allWords.ToString(), page));
        }
        public static string ToPayPalViewCart()
        {
            return HttpUtility.UrlPathEncode(
            String.Format("{0}&business={1}&return={2}&cancel_return={3}&display=1",
            seoWebAppConfiguration.PaypalUrl,
            seoWebAppConfiguration.PaypalEmail,
            seoWebAppConfiguration.PaypalReturnUrl,
            seoWebAppConfiguration.PaypalCancelUrl));
        }
        public static string ToPayPalAddItem(string productUrl, string productName, decimal productPrice, string productOptions)
        {
            return HttpUtility.UrlPathEncode(
            String.Format("{0}&business={1}&return={2}&cancel_return={3}&shopping_url={4}&item_name={5}&amount={6:0.00}&currency={7}&on0=Options&os0={8}&add=1",
            seoWebAppConfiguration.PaypalUrl,
            seoWebAppConfiguration.PaypalEmail,
            seoWebAppConfiguration.PaypalReturnUrl,
            seoWebAppConfiguration.PaypalCancelUrl,
            productUrl,
            productName,
                    productPrice,
            seoWebAppConfiguration.PaypalCurrency,
            productOptions));
        }

        public static string ToPayPalCheckout(string orderName, decimal orderAmount)
            {
            return HttpUtility.UrlPathEncode(HttpUtility.UrlPathEncode(
            String.Format("{0}/business={1}&item_name={2}&amount={3:0.00}&currency ={4}&return={5}&cancel_return={6}",
            seoWebAppConfiguration.PaypalUrl,
            seoWebAppConfiguration.PaypalEmail,
            orderName,
            orderAmount,
            seoWebAppConfiguration.PaypalCurrency,
            seoWebAppConfiguration.PaypalReturnUrl,
            seoWebAppConfiguration.PaypalCancelUrl)));
            }
    }
}
