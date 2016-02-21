namespace RightoGo.Web.ViewModels.Articles
{
    using System.Collections.Generic;

    public class AllArticlesViewModel
    {
        public IEnumerable<ArticleViewModel> Articles { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public string FilterBy { get; set; }

        public string OrderBy { get; set; }

        public string SortBy { get; set; }

        public int TotalPages { get; set; }
    }
}
