using System.Web.Mvc;
using System.Web.Routing;

namespace FonNature
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "PageRoute",
                url: "{pageUrl}",
                defaults: new { controller = "Default", action = "CommonPage" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Home" }
            );
        }
    }
}
