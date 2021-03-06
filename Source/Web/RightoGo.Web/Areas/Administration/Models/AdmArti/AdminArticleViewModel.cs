﻿namespace RightoGo.Web.Areas.Administration.Models.AdmArti
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminArticleViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ModifiedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string CreatedById { get; set; }

        public string TopicName { get; set; }

        public string CreatorName { get; set; }

        public bool IsPrivate { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Article, AdminArticleViewModel>()
                .ForMember(a => a.CreatorName, opt => opt.MapFrom(x => x.CreatedBy.UserName))
                .ForMember(a => a.TopicName, opt => opt.MapFrom(x => x.Topic.Value));
        }
    }
}
