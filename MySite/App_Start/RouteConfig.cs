using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MySite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // duplicate MapRoute thêm 1 lần nữa tương ứng vs 1 controller đc tạo
            routes.MapRoute(
                name: "Test",
                url: "",
                defaults: new { controller = "Home", action = "Test", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",// nhớ nhé !
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );// 


        }

    }
}
