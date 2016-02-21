namespace RightoGo.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Grade : BaseModel<int>
    {
        [Required]
        [Range(0, 100)]
        public int Value { get; set; }

        [Required]
        public int RelatedTestId { get; set; }

        public virtual Test RelatedTest { get; set; }

        [Required]
        public string RelatedStudentId { get; set; }

        public virtual User RelatedStudent { get; set; }
    }
}
