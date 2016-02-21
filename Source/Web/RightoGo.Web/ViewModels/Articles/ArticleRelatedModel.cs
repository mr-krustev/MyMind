namespace RightoGo.Web.ViewModels.Articles
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class ArticleRelatedModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}