using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FoodDeliveryApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "INDEX",
              url: "INDEX",
              defaults: new { controller = "Web", action = "Index", id = UrlParameter.Optional }
             );

            routes.MapRoute(
                name: "HOME",
                url: "HOME",
                defaults: new { controller = "Web", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "MENU",
                url: "MENU",
                defaults: new { controller = "Web", action = "Menu", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SERVICES",
                url: "SERVICES",
                defaults: new { controller = "Web", action = "Services", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CART",
                url: "CART",
                defaults: new { controller = "Web", action = "Cart", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ABOUT",
                url: "ABOUT",
                defaults: new { controller = "Web", action = "About", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "LOGIN",
                url: "LOGIN",
                defaults: new { controller = "Web", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ADMINLOGIN",
                url: "ADMINLOGIN",
                defaults: new { controller = "Web", action = "AdminLogin", id = UrlParameter.Optional }
            );





            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Web", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
