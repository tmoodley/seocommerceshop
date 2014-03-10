using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace seoWebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
          name: "StoreDepartment",
          url: "store/{storeid}/d/{id}/{name}/",
          defaults: new { controller = "Product", action = "Departments", storeid = UrlParameter.Optional, id = UrlParameter.Optional, name = UrlParameter.Optional }
        );

            routes.MapRoute(
        name: "StoreCategory",
        url: "store/{storeid}/c/{id}/{name}/",
        defaults: new { controller = "Product", action = "Categories", storeid = UrlParameter.Optional, id = UrlParameter.Optional, name = UrlParameter.Optional }
      );

            routes.MapRoute(
             name: "StoreProduct",
             url: "store/{storeid}/product/{id}/{name}/",
             defaults: new { controller = "Product", action = "Display", storeid = UrlParameter.Optional, id = UrlParameter.Optional, name = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Store",
              url: "store/{id}/{name}/",
              defaults: new { controller = "webstore", action = "store", id = UrlParameter.Optional, name = UrlParameter.Optional }
            );

            routes.MapRoute(
           name: "CategoryType",
           url: "ct/{id}/{productName}/",
           defaults: new { controller = "CategoryType", action = "Types", id = UrlParameter.Optional, productName = UrlParameter.Optional }
         );

            routes.MapRoute(
                     name: "Default",
                     url: "{controller}/{action}/{id}",
                     defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                 );

           

            

      
        }
    }
}
