namespace RightoGo.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;
    using Services.Data.Contracts;

    public class AdminUniversitiesController : Controller
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
            IQueryable<University> universities = this.universities.GetAll();
            DataSourceResult result = universities.ToDataSourceResult(request, university => new {
                Id = university.Id,
                Name = university.Name,
                CreatedOn = university.CreatedOn,
                ModifiedOn = university.ModifiedOn,
                IsDeleted = university.IsDeleted,
                DeletedOn = university.DeletedOn
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Universities_Create([DataSourceRequest]DataSourceRequest request, AdminUniversityCreateModel university)
        {
            var id = 0;
            if (this.ModelState.IsValid)
            {
                var entity = new University
                {
                    Name = university.Name
                };

                this.universities.Add(entity);
                id = entity.Id;
            }

            var uniToDisplay = this.universities.GetById(id).To<AdminUniversityViewModel>();
            return this.Json(new[] { uniToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Universities_Update([DataSourceRequest]DataSourceRequest request, AdminUniversityInputModel university)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.universities.GetById(university.Id).FirstOrDefault();
                entity.Name = university.Name;    
                this.universities.Update(entity);
            }

            var uniToDisplay = this.universities.GetById(university.Id).To<AdminUniversityViewModel>();
            return this.Json(new[] { uniToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Universities_Destroy([DataSourceRequest]DataSourceRequest request, University university)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.universities.GetById(university.Id).FirstOrDefault();
                this.universities.Delete(entity);
            }

            var uniToDisplay = this.universities.GetById(university.Id).To<AdminUniversityViewModel>();
            return this.Json(new[] { uniToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
