namespace RightoGo.Web.ViewModels.Users.Teacher
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class ProfileRelatedArticleViewModel : IMapFrom<Article>
    {

        public int Id { get; set; }

        public string Title { get; set; }
    }
}