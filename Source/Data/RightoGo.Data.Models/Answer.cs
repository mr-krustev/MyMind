namespace RightoGo.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Answer : BaseModel<int>
    {
        [Required]
        public bool IsCorrect { get; set; }

        [Required]
        [MinLength(1)]
        public string Text { get; set; }

        [Required]
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
