namespace RightoGo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Work : BaseModel<int>
    {
        public Work()
        {
            this.AuthorizedUsers = new HashSet<User>();
            this.Likes = new HashSet<Like>();
        }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Title { get; set; }

        public Topic Topic { get; set; }

        [Required]
        [MinLength(2)]
        public string Content { get; set; }

        [Required]
        public string CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }

        [DefaultValue(false)]
        public bool IsPrivate { get; set; }

        public ICollection<User> AuthorizedUsers { get; set; }

        public ICollection<Like> Likes { get; set; }
    }
}
