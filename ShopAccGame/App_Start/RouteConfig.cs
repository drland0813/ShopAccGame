using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopAccGame
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Product",
               url: "lol-account",
               defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "Register",
              url: "register",
              defaults: new { controller = "register", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
               name: "Login",
               url: "login",
               defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
           );

            // Nhớ đăng ký map route ở trên này, ở dưới đây thì nó không nhận
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

           

        }
    }
}
