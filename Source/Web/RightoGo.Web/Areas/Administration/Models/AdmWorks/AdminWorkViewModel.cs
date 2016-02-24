namespace RightoGo.Web.Areas.Administration.Models.AdmWorks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Data.Models;
    using Ganss.XSS;
    using Infrastructure.Mapping;

    public class AdminWorkViewModel : IMapFrom<Work>, IHaveCustomMappings
    {
        private IHtmlSanitizer sanitizer;

        public AdminWorkViewModel()
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

        public string CreatorName { get; set; }

        public string CreatedById { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Work, AdminWorkViewModel>()
                .ForMember(x => x.TopicName, opts => opts.MapFrom(x => x.Topic.Value))
                .ForMember(x => x.CreatorName, opts => opts.MapFrom(x => x.CreatedBy.UserName));
        }
    }
}