using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCDemo {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name : "Upload",
                url : "Employee/BulkUpload",
                defaults : new {controller = "BulkUpload", action = "Index"}
            );

            //routes.MapRoute(
            //    name : "Show",
            //    url : "Show/{id1},{id2},{id3}",
            //    defaults : new {controller = "Employee", action = "Show"}
            //);
            //越常用的路由，定义顺序越后
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
