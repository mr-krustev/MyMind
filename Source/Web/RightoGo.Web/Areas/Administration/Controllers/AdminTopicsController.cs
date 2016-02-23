namespace RightoGo.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.AdmTopic;
    using Services.Data.Contracts;
    using Web.Controllers;

    public class AdminTopicsController : BaseController
    {
        private ITopicsServices topics;

        public AdminTopicsController(ITopicsServices topics)
        {
            this.topics = topics;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Topics_Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.topics.GetAll().To<AdminTopicViewModel>();

            // return this.Json(result);
            return this.Json(result.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Topics_Create([DataSourceRequest]DataSourceRequest request, AdminTopicCreateModel topic)
        {
            var id = 0;
            if (this.ModelState.IsValid)
            {
                var entity = new Topic
                {
                    Value = topic.Value
                };

                this.topics.Add(entity);
                id = entity.Id;
            }

            var result = this.topics.GetById(id).To<AdminTopicViewModel>().FirstOrDefault();
            return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Topics_Update([DataSourceRequest]DataSourceRequest request, AdminTopicInputModel topic)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.topics.GetById(topic.Id).FirstOrDefault();
                entity.Value = topic.Value;

                this.topics.Update(entity);
            }

            var result = this.topics.GetById(topic.Id).To<AdminTopicViewModel>().FirstOrDefault();
            return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Topics_Destroy([DataSourceRequest]DataSourceRequest request, AdminTopicInputModel topic)
        {
            var entity = this.topics.GetById(topic.Id).FirstOrDefault();

            if (entity == null)
            {
                return this.Json(new[] { topic }.ToDataSourceResult(request, this.ModelState));
            }

            this.topics.Delete(entity);
            var result = this.topics.GetById(topic.Id).To<AdminTopicViewModel>().FirstOrDefault();
            return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
