namespace RightoGo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Topic : BaseModel<int>
    {
        [Required]
        public string Value { get; set; }

        public ICollection<Article> RelatedArticles { get; set; }

        public ICollection<Work> RelatedWorks { get; set; }
    }
}
