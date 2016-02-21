namespace RightoGo.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Like : BaseModel<int>
    {
        [Required]
        public string VoterId { get; set; }

        public virtual User Voter { get; set; }

        [Required]
        public int WorkId { get; set; }

        public virtual Work Work { get; set; }

        [Required]
        public LikeType Type { get; set; }
    }
}
