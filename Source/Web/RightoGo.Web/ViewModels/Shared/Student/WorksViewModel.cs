namespace RightoGo.Web.ViewModels.Shared.Student
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class WorksViewModel : IMapFrom<Work>, IHaveCustomMappings
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string TopicName { get; set; }

        public string Content { get; set; }

        public string CreatedById { get; set; }

        public string UserName { get; set; }

        public bool IsPrivate { get; set; }

        public int LikesCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnFormatted
        {
            get
            {
                return string.Format("{0:yyyy-MM-dd HH:mm}", this.CreatedOn);
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Work, WorksViewModel>()
                 .ForMember(a => a.TopicName, opt => opt.MapFrom(x => x.Topic.Value))
                 .ForMember(a => a.UserName, opt => opt.MapFrom(x => x.CreatedBy.UserName))
                 .ForMember(a => a.LikesCount, opt => opt.MapFrom(x => x.Likes.Any() ? x.Likes.Sum(l => (int)l.Type) : 0));
        }
    }
}