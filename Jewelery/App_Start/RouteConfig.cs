using System.Web.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Jewelery
{
    public class RouteConfig
    {
        //TODO Baxilmalidir Vacibdir. rooting ucun
        public static void RegisterRoutes(RouteCollection routes)
        {
            // routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //
            // routes.MapRoute(
            // name: "Language",
            // url: "{lang}/{controller}/{action}/{id}",
            // defaults: new { controller = "Default", action = "index", id = UrlParameter.Optional },
            // constraints: new { lang = @"az|ru" }
            //  );
            //
            // routes.MapRoute(
            //     name: "Default",
            //     url: "{controller}/{action}/{id}",
            //     defaults: new { controller = "home", action = "index", id = UrlParameter.Optional , lang="az"}
            // );
        
        }
    }
}
