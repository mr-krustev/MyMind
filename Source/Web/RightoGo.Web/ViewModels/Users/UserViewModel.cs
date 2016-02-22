namespace RightoGo.Web.ViewModels.Users
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string UserName { get; set; }

        public string AvatarUrl { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UniversityName { get; set; }

        // Students Related
        public ICollection<Test> TestsTaken { get; set; }

        public ICollection<Grade> Grades { get; set; }

        public string Faculty { get; set; }

        public string Specialty { get; set; }

        public ICollection<Work> Works { get; set; }

        // Teacher Related
        public ICollection<Video> Videos { get; set; }

        public ICollection<Test> TestsCreated { get; set; }

        public string FieldOfStudy { get; set; }

        public ICollection<Article> Articles { get; set; }

        public string RoleName { get; set; } // How do you even?

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, UserViewModel>()
                .ForMember(a => a.UniversityName, opt => opt.MapFrom(x => x.University.Name));
        }
    }
}