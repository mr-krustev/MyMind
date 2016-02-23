namespace RightoGo.Web.Areas.Administration.Models.AdmTopic
{
    using System.ComponentModel.DataAnnotations;

    public class AdminTopicInputModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }
    }
}