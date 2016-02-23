namespace RightoGo.Web.ViewModels.Students
{
    using System.ComponentModel.DataAnnotations;

    public class StudentInputModel
    {
        [Required]
        [MinLength(2)]
        public string Faculty { get; set; }

        [Required]
        [MinLength(2)]
        public string Specialty { get; set; }
    }
}