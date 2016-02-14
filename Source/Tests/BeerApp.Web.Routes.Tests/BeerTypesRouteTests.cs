namespace BeerApp.Web.Routes.Tests
{
    using System.Web.Routing;

    using MvcRouteTester;

    using BeerApp.Web.Controllers;

    using NUnit.Framework;

    [TestFixture]
    public class BeerTypesRouteTests
    {
        [Test]
        public void TestRouteById()
        {
            const string Url = "/BeerType/MS4xMjMxMjMxMzEyMw==";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<BeerTypeController>(c => c.BeerTypeDetails("Mjc2NS4xMjMxMjMxMzEyMw=="));
        }
    }
}
