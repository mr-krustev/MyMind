namespace RightoGo.Web.Areas.Administration.Models.AdmWorks
{
    using System.ComponentModel.DataAnnotations;

    public class AdminWorkInputModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Title { get; set; }
    }
}
