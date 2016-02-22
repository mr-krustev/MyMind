namespace RightoGo.Web.ViewModels.Articles
{
    using System.Collections.Generic;

    using Shared;

    public class AllArticlesViewModel
    {
        public IEnumerable<ArticleViewModel> Articles { get; set; }

        public PagingViewModel PagingInfo { get; set; }
    }
}
