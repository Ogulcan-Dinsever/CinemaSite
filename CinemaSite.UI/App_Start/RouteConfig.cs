using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CinemaSite.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "FilmEdit",
                url: "edit/{id}",
                defaults: new { controller = "Main", action = "Edit" }
            );

            routes.MapRoute(
                name: "FilmDelete",
                url: "delete/{id}",
                defaults: new { controller = "Main", action = "Delete" }
            );

            routes.MapRoute(
                name: "CategoryDetail",
                url: "filmler/{id}",
                defaults: new { controller = "Main", action = "Films" }
            );

            routes.MapRoute(
                name: "FilmDetail",
                url: "film/{id}",
                defaults: new { controller = "Main", action = "Film" }
            );

            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "Account", action = "Login" }
            );

            routes.MapRoute(
                name: "Register",
                url: "register",
                defaults: new { controller = "Account", action = "Register" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Main", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
