namespace RightoGo.Web.Areas.Administration.Models.AdmWorks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminWorkViewModel : IMapFrom<Work>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string TopicName { get; set; }

        public string Content { get; set; }

        public string CreatedByUsername { get; set; }

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
                .ForMember(x => x.CreatedByUsername, opts => opts.MapFrom(x => x.CreatedBy.UserName));
        }
    }
}