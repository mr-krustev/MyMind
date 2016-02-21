namespace RightoGo.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Home;
    public class HomeController : BaseController
    {
        private IArticlesServices articles;

        public HomeController(IArticlesServices articles)
        {
            this.articles = articles;
        }

        public ActionResult Index()
        {
            var articleData = this.articles
                .GetPaged(1, 10)
                .To<IndexArticleViewModel>()
                .ToList();

            var viewModel = new IndexViewModel()
            {
                Articles = articleData
            };

            return this.View(viewModel);
        }
    }
}
