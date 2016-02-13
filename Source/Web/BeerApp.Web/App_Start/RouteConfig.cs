namespace BeerApp.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "JokePage",
                url: "Joke/{id}",
                defaults: new { controller = "Jokes", action = "ById" });
            routes.MapRoute(
                name: "BeerType",
                url: "BeerType/{id}",
                defaults: new { controller = "BeerType", action = "BeerTypeDetails" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
