namespace RightoGo.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    public class TeachersController : Controller
    {
        [HttpGet]
        public ActionResult GetAccess()
        {
            var errorHandle = new HandleErrorInfo(new NotImplementedException("Sorry but teacher access is not yet available."), "Teachers", "GetAccess");

            return this.View("Error", errorHandle);
        }
    }
}
