namespace RightoGo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Topic : BaseModel<int>
    {
        [Required]
        public string Value { get; set; }

        public virtual ICollection<Article> RelatedArticles { get; set; }

        public virtual ICollection<Work> RelatedWorks { get; set; }
    }
}
