namespace RightoGo.Web.Areas.Administration.Models.AdmTopic
{
    using System.ComponentModel.DataAnnotations;

    public class AdminTopicCreateModel
    {
        [Required]
        public string Value { get; set; }
    }
}