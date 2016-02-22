namespace RightoGo.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;
    using Services.Data.Contracts;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdminArticlesController : Controller
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
            DataSourceResult result = this.articles.GetAll().To<ArticleViewModel>().ToDataSourceResult(request);

            return this.Json(result);
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

            return this.Json(new[] { article }.ToDataSourceResult(request, this.ModelState));
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

            return this.Json(new[] { article }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
