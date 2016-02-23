namespace RightoGo.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AdminUniversityCreateModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}