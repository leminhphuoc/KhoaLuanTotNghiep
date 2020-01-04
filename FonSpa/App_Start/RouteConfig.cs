using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FonNature
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Admin
            routes.MapRoute(
               name: "Admin",
               url: "admin",
               defaults: new { controller = "HomeAdmin", action = "Index", id = UrlParameter.Optional }
           );
            #endregion

            routes.MapRoute(
              name: "Services Home",
              url: "serviceshome",
              defaults: new { controller = "Services", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "product detail",
             url: "productdetail",
             defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional }
         );

            routes.MapRoute(
             name: "services detail",
             url: "servicesdetail",
             defaults: new { controller = "Services", action = "Detail", id = UrlParameter.Optional }
         ); 

                routes.MapRoute(
             name: "blog detail",
             url: "blogdetail",
             defaults: new { controller = "Blog", action = "Detail", id = UrlParameter.Optional }
         );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
