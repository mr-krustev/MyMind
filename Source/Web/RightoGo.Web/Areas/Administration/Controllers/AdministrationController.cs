namespace RightoGo.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using RightoGo.Common;
    using RightoGo.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
