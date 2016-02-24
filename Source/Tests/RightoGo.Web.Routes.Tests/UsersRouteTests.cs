namespace RightoGo.Web.Routes.Tests
{
    using System.Net.Http;
    using System.Web.Routing;

    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class UsersRouteTests
    {
        [Test]
        public void TestRouteById()
        {
            const string Url = "/Users/ById/coolstorybro";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<UsersController>(c => c.ById("coolstorybro"));
        }
    }
}
