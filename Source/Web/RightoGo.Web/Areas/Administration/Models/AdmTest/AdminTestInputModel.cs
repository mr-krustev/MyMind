namespace RightoGo.Web.Areas.Administration.Models.AdmTest
{
    using System.ComponentModel.DataAnnotations;

    public class AdminTestInputModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int TopicId { get; set; }
    }
}