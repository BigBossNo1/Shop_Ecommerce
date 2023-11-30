using System.Web.Mvc;
using System.Web.Routing;

namespace ShopEcommerce.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Page Home",
                url: "home",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "ShopEcommerce.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Page About",
                url: "page_about",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
                namespaces: new string[] { "ShopEcommerce.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Page Contact",
                url: "contact",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional },
                namespaces: new string[] { "ShopEcommerce.Web.Controllers" }

            );
        }
    }
}