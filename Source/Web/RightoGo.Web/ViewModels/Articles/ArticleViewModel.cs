namespace RightoGo.Web.ViewModels.Articles
{
    using System;
    using System.Collections.Generic;

    using Data.Models;
    using Ganss.XSS;
    using Infrastructure.Mapping;

    public class ArticleViewModel : IMapFrom<Article>
    {
        private IHtmlSanitizer sanitizer;

        public ArticleViewModel()
        {
            this.sanitizer = new HtmlSanitizer();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public Topic Topic { get; set; }

        public string Content { get; set; }

        public string SanitizedContent
        {
            get
            {
                return this.sanitizer.Sanitize(this.Content);
            }
        }

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
