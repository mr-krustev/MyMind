namespace RightoGo.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Web.Controllers;

    public class HomeController : BaseController
    {
        // GET: Administration/Home
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
