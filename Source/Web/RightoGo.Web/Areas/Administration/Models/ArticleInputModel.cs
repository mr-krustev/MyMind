namespace RightoGo.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ArticleInputModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Title { get; set; }
    }
}