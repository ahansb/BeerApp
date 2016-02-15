namespace BeerApp.Web.Routes.Tests
{
    using System.Web.Routing;

    using MvcRouteTester;

    using BeerApp.Web.Controllers;

    using NUnit.Framework;

    [TestFixture]
    public class BeersRouteTests
    {
        [Test]
        public void TestRouteById()
        {
            const string Url = "/Beer/Details/MS4xMjMxMjMxMzEyMw==";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<BeerController>(c => c.Details("MS4xMjMxMjMxMzEyMw=="));
        }
    }
}
