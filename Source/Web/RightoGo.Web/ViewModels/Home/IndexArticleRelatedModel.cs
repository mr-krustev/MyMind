namespace RightoGo.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Data.Models;
    using Infrastructure.Mapping;

    public class IndexArticleRelatedModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}