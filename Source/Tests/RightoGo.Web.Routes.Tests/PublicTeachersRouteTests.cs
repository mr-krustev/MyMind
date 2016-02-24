namespace RightoGo.Web.Routes.Tests
{
    using System.Net.Http;
    using System.Web.Routing;

    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class PublicTeachersRouteTests
    {
        [Test]
        public void TestRouteGetAccess()
        {
            const string Url = "/Teachers/GetAccess";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<TeachersController>(c => c.GetAccess());
        }
    }
}
