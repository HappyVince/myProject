using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "somme",
                url: "somme/{a}/{b}",
                defaults: new { controller = "Somme", action = "Index", a = UrlParameter.Optional, b = UrlParameter.Optional }
            );

            routes.MapRoute(
    name: "GetUtilisateur",
    url: "getutilisateur",
    defaults: new { controller = "GetUtilisateur", action = "Index"}
);

            routes.MapRoute(
name: "GetUtilisateurData",
url: "getutilisateurData",
defaults: new { controller = "GetUtilisateur", action = "GetUtilisateur" }
);


            routes.MapRoute(
name: "NewUtilisateur",
url: "newutilisateur/{login}/{password}",
defaults: new { controller = "NewUtilisateur", action = "Index", login = UrlParameter.Optional, password = UrlParameter.Optional }
);

            routes.MapRoute(
    name: "Default",
    url: "{controller}/{action}/{id}",
    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
);
        }
    }
}
