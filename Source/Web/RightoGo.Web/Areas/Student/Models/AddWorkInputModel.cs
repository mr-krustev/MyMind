namespace RightoGo.Web.Areas.Student.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    using Data.Models;

    public class AddWorkInputModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Title { get; set; }

        [Required]
        public int TopicId { get; set; }

        [Required]
        [MinLength(2)]
        [AllowHtml]
        public string Content { get; set; }
    }
}