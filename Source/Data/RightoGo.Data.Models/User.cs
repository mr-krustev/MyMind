namespace RightoGo.Data.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public User()
        {
            // Student related
            this.Likes = new HashSet<Like>();
            this.TestsTaken = new HashSet<Test>();
            this.Grades = new HashSet<Grade>();
            this.Works = new HashSet<Work>();

            // Teacher related
            this.Videos = new HashSet<Video>();
            this.TestsCreated = new HashSet<Test>();
            this.Articles = new HashSet<Article>();
        }

        public string AvatarUrl { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? UniversityId { get; set; }

        public virtual University University { get; set; }

        public ICollection<Like> Likes { get; set; }

        // Students Related
        public virtual ICollection<Test> TestsTaken { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }

        public string Faculty { get; set; }

        public string Specialty { get; set; }

        public virtual ICollection<Work> Works { get; set; }

        // Teacher Related
        public virtual ICollection<Video> Videos { get; set; }

        public virtual ICollection<Test> TestsCreated { get; set; }

        public string FieldOfStudy { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
