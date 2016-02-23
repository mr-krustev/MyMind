namespace RightoGo.Web.ViewModels.Shared
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class PagingTopicViewModel : IMapFrom<Topic>, IHaveCustomMappings
    {
        public string Value { get; set; }

        public string Text { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Topic, PagingTopicViewModel>()
                .ForMember(a => a.Text, opt => opt.MapFrom(x => x.Value));
        }
    }
}