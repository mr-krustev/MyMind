namespace RightoGo.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.AdmUni;
    using Services.Data.Contracts;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdminUniversitiesController : BaseController
    {
        private IUniversitiesServices universities;

        public AdminUniversitiesController(IUniversitiesServices universities)
        {
            this.universities = universities;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Universities_Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.universities.GetAll().To<AdminUniversityViewModel>();
            return this.Json(result.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Universities_Create([DataSourceRequest]DataSourceRequest request, AdminUniversityCreateModel uni)
        {
            var id = 0;
            if (this.ModelState.IsValid)
            {
                var entity = new University()
                {
                    Name = uni.Name
                };

                this.universities.Add(entity);
                id = entity.Id;
            }

            var result = this.universities.GetById(id).To<AdminUniversityViewModel>().FirstOrDefault();
            return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Universities_Update([DataSourceRequest]DataSourceRequest request, AdminUniversityInputModel uni)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.universities.GetById(uni.Id).FirstOrDefault();
                entity.Name = uni.Name;

                this.universities.Update(entity);
            }

            var result = this.universities.GetById(uni.Id).To<AdminUniversityViewModel>().FirstOrDefault();
            return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Universities_Destroy([DataSourceRequest]DataSourceRequest request, University uni)
        {
            var entity = this.universities.GetById(uni.Id).FirstOrDefault();

            if (entity == null)
            {
                return this.Json(new[] { uni }.ToDataSourceResult(request, this.ModelState));
            }

            this.universities.Delete(entity);
            var result = this.universities.GetById(uni.Id).To<AdminUniversityViewModel>().FirstOrDefault();
            return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
