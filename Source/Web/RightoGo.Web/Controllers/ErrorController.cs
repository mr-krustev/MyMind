namespace RightoGo.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    public class ErrorController : BaseController
    {
        // GET: Error
        public ActionResult Index(string id)
        {
            if (id == "unauthorized")
            {
                throw new HttpException("Unauthorized to view this.");
            }

            return this.View("Error");
        }
    }
}