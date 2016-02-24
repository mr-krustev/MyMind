namespace RightoGo.Web.Areas.Administration.Models.AdmArti
{
    using System.ComponentModel.DataAnnotations;

    public class AdminArticleInputModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Title { get; set; }
    }
}
