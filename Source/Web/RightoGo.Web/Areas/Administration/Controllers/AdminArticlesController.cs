namespace RightoGo.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.AdmArti;
    using Services.Data.Contracts;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdminArticlesController : BaseController
    {
        private IArticlesServices articles;

        public AdminArticlesController(IArticlesServices articles)
        {
            this.articles = articles;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Articles_Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.articles.GetAll().To<ArticleViewModel>();

            // return this.Json(result);
            return this.Json(result.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Articles_Update([DataSourceRequest]DataSourceRequest request, ArticleInputModel article)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.articles.GetById(article.Id).FirstOrDefault();
                entity.Title = article.Title;

                this.articles.Update(entity);
            }

            var result = this.articles.GetById(article.Id).To<ArticleViewModel>().FirstOrDefault();
            return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Articles_Destroy([DataSourceRequest]DataSourceRequest request, Article article)
        {
            var entity = this.articles.GetById(article.Id).FirstOrDefault();

            if (entity == null)
            {
                return this.Json(new[] { article }.ToDataSourceResult(request, this.ModelState));
            }

            this.articles.Delete(entity);
            var result = this.articles.GetById(article.Id).To<ArticleViewModel>().FirstOrDefault();
            return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
