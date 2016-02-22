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

        [OutputCache(Duration = 10 * 60 * 60)]
        public ActionResult Index()
        {
            var articleData = this.articles
                .GetPaged(1, 5)
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
