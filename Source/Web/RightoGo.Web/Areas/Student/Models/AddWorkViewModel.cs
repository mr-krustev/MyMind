namespace RightoGo.Web.Areas.Student.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Data.Models;
    using Ganss.XSS;

    public class AddWorkViewModel
    {
        private IHtmlSanitizer sanitizer;

        public AddWorkViewModel()
        {
            this.sanitizer = new HtmlSanitizer();
        }

        public string Title { get; set; }

        public int TopicId { get; set; }

        [UIHint("tinymce")]
        [AllowHtml]
        public string Content { get; set; }

        public string SanitizedContent
        {
            get
            {
                return this.sanitizer.Sanitize(this.Content);
            }
        }

        public IEnumerable<TopicViewModel> Topics { get; set; }
    }
}
