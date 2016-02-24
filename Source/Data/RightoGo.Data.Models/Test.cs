namespace RightoGo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Test : BaseModel<int>
    {
        public Test()
        {
            this.Questions = new HashSet<Question>();
        }

        [Required]
        public Topic Topic { get; set; }

        public string CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
