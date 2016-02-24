namespace RightoGo.Web.Areas.Administration.Models.AdmTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminTestViewModel : IMapFrom<Test>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifiedOn { get; set; }

        public int TopicId { get; set; }

        public AdminTopicViewModel Topic { get; set; }

        public string TopicName { get; set; }

        public string CreatedById { get; set; }

        public string CreatorName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Test, AdminTestViewModel>()
                .ForMember(x => x.CreatorName, opts => opts.MapFrom(x => x.CreatedBy.UserName))
                .ForMember(x => x.TopicId, opts => opts.MapFrom(x => x.Topic.Id))
                .ForMember(x => x.TopicName, opts => opts.MapFrom(x => x.Topic.Value));
        }
    }
}