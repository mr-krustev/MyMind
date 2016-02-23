namespace RightoGo.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminUniversityInputModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(5)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}