namespace RightoGo.Web.Areas.Administration.Models.AdmTopic
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminTopicViewModel : IMapFrom<Topic>
    {
        public int Id { get; set; }

        public string Value { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifiedOn { get; set; }
        // public virtual ICollection<Article> RelatedArticles { get; set; }
        // public virtual ICollection<Work> RelatedWorks { get; set; }
    }
}
