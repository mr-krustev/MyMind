namespace RightoGo.Web.Controllers
{
    using System;
    using System.Collections.Generic;
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
            IEnumerable<IndexArticleViewModel> articleData;

            if (this.HttpContext.Cache["HomeArticles"] != null)
            {
                articleData = (IEnumerable<IndexArticleViewModel>)this.HttpContext.Cache["HomeArticles"];
            }
            else
            {
                articleData = this.articles
                .GetPaged(1, 5)
                .To<IndexArticleViewModel>()
                .ToList();

                this.HttpContext.Cache.Insert("HomeArticles", articleData, null, DateTime.MaxValue, new TimeSpan(1, 0, 0));
            }

            var viewModel = new IndexViewModel()
            {
                Articles = articleData
            };

            return this.View(viewModel);
        }
    }
}
