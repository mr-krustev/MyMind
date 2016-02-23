namespace RightoGo.Web.Areas.Student.Models
{
    using System;
    using AutoMapper;
    using RightoGo.Data.Models;

    using RightoGo.Web.Infrastructure.Mapping;

    public class LikeViewModel : IMapFrom<Like>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string VoterName { get; set; }

        public int VoteType { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Like, LikeViewModel>()
                .ForMember(a => a.VoterName, opt => opt.MapFrom(x => x.Voter.UserName))
                .ForMember(a => a.VoteType, opt => opt.MapFrom(x => (int)x.Type));
        }
    }
}