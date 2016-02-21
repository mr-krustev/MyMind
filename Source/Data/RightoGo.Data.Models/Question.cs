namespace RightoGo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Question : BaseModel<int>
    {
        public Question()
        {
            this.Answers = new HashSet<Answer>();
        }

        [Required]
        public string Task { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
