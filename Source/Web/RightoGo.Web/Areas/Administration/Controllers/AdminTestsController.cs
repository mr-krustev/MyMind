namespace RightoGo.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Models.AdmTest;
    using Services.Data.Contracts;
    using Web.Controllers;

    public class AdminTestsController : BaseController
    {
        private ITestsServices tests;
        private ITopicsServices topics;

        public AdminTestsController(ITestsServices tests, ITopicsServices topics)
        {
            this.tests = tests;
            this.topics = topics;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Tests_Read([DataSourceRequest]DataSourceRequest request)
        {
           var result = this.tests.GetAll().To<AdminTestViewModel>();
            return this.Json(result.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Tests_Create([DataSourceRequest]DataSourceRequest request, AdminTestCreateModel test)
        {
            var id = 0;
            if (this.ModelState.IsValid)
            {
                var entity = new Test
                {
                    Topic = this.topics.GetById(test.TopicId).FirstOrDefault(),
                    CreatedById = this.User.Identity.GetUserId()
                };

                this.tests.Add(entity);
                id = entity.Id;
            }

            var result = this.tests.GetById(id).To<AdminTestViewModel>().FirstOrDefault();
            return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Tests_Update([DataSourceRequest]DataSourceRequest request, AdminTestInputModel test)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.tests.GetById(test.Id).FirstOrDefault();
                entity.Topic = this.topics.GetById(test.TopicId).FirstOrDefault();

                this.tests.Update(entity);
            }

            var result = this.tests.GetById(test.Id).To<AdminTestViewModel>().FirstOrDefault();
            return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Tests_Destroy([DataSourceRequest]DataSourceRequest request, Test test)
        {
            var entity = this.tests.GetById(test.Id).FirstOrDefault();

            if (entity == null)
            {
                return this.Json(new[] { test }.ToDataSourceResult(request, this.ModelState));
            }

            this.tests.Delete(entity);
            var result = this.tests.GetById(test.Id).To<AdminTestViewModel>().FirstOrDefault();
            return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
