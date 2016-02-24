namespace RightoGo.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Common;
    using Helpers;
    using Web.Controllers;

    [AuthorizeRedirect(Roles = GlobalConstants.AdministratorRoleName)]
    public class HomeController : BaseController
    {
        // GET: Administration/Home
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
