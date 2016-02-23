namespace RightoGo.Web.Areas.Student.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Data.Models;
    using Ganss.XSS;
    using Infrastructure.Mapping;

    public class WorkViewModel : IMapFrom<Work>, IHaveCustomMappings
    {
        private IHtmlSanitizer sanitizer;

        public WorkViewModel()
        {
            this.sanitizer = new HtmlSanitizer();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string TopicName { get; set; }

        public string Content { get; set; }

        public string SanitizedContent
        {
            get
            {
                return this.sanitizer.Sanitize(this.Content);
            }
        }

        public string CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnFormatted
        {
            get
            {
                return string.Format("{0:yyyy-MM-dd HH:mm}", this.CreatedOn);
            }
        }

        public int LikesCount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Work, WorkViewModel>()
                .ForMember(a => a.LikesCount, opt => opt.MapFrom(x => x.Likes.Any() ? x.Likes.Sum(l => (int)l.Type) : 0))
                .ForMember(a => a.TopicName, opt => opt.MapFrom(x => x.Topic.Value));
        }
    }
}