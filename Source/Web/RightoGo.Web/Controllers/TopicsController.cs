namespace RightoGo.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using Views.Topics;

    public class TopicsController : BaseController
    {
        private ITopicsServices topics;

        public TopicsController(ITopicsServices topics)
        {
            this.topics = topics;
        }

        [HttpGet]
        public ActionResult AllJson()
        {
            var result = this.topics.GetAll().To<TopicsViewModel>().ToList();

            return this.Json(new { topics = result }, JsonRequestBehavior.AllowGet);
        }
    }
}
