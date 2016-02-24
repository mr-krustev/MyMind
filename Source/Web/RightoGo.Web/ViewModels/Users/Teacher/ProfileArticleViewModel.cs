namespace RightoGo.Web.ViewModels.Users.Teacher
{
    using System;
    using System.Collections.Generic;

    using Articles;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ProfileArticleViewModel : IMapFrom<Article>
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public Topic Topic { get; set; }

        public string Content { get; set; }

        public bool IsPrivate { get; set; }

        public User CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnFormated
        {
            get
            {
                return string.Format("{0:yyyy-MM-dd HH:mm}", this.CreatedOn);
            }
        }

        public IEnumerable<ArticleRelatedModel> RelatedArticles { get; set; }
    }
}
