namespace RightoGo.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.AdmWorks;
    using Services.Data.Contracts;
    using Web.Controllers;

    public class AdminWorksController : BaseController
    {
        private IWorksServices works;

        public AdminWorksController(IWorksServices works)
        {
            this.works = works;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Works_Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.works.GetAll().To<AdminWorkViewModel>();
            return this.Json(result.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Works_Update([DataSourceRequest]DataSourceRequest request, AdminWorkInputModel work)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.works.GetById(work.Id).FirstOrDefault();
                entity.Title = work.Title;

                this.works.Update(entity);
            }

            var result = this.works.GetById(work.Id).To<AdminWorkViewModel>().FirstOrDefault();
            return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Works_Destroy([DataSourceRequest]DataSourceRequest request, Work work)
        {
            var entity = this.works.GetById(work.Id).FirstOrDefault();

            if (entity == null)
            {
                return this.Json(new[] { work }.ToDataSourceResult(request, this.ModelState));
            }

            this.works.Delete(entity);
            var result = this.works.GetById(work.Id).To<AdminWorkViewModel>().FirstOrDefault();
            return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
