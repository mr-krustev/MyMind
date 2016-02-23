namespace RightoGo.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public class SeedData
    {
        private const string StudentRoleName = "Student";
        private const string TeacherRoleName = "Teacher";

        private Random random = new Random();

        private List<User> users;
        private List<Topic> topics;
        private List<University> universities;
        private List<Work> works;
        private List<Article> articles;

        private UserStore<User> userStore;
        private UserManager<User> userManager;

        public void GenerateData(ApplicationDbContext context)
        {
            if (context.Topics.Any() && context.University.Any() && (context.Users.Count() > 1)
                && context.Articles.Any() && context.Works.Any())
            {
                return;
            }

            this.userStore = new UserStore<User>(context);
            this.userManager = new UserManager<User>(this.userStore);

            if (!context.Topics.Any())
            {
                this.topics = this.GenerateTopics();
                this.topics.ForEach(t => context.Topics.Add(t));
                context.SaveChanges();
            }
            else
            {
                this.topics = context.Topics.ToList();
            }

            if (!context.University.Any())
            {
                this.universities = this.GenerateUniversities();
                this.universities.ForEach(u => context.University.Add(u));
                context.SaveChanges();
            }
            else
            {
                this.universities = context.University.ToList();
            }

            if (!(context.Users.Count() > 1))
            {
                this.users = this.GenerateUsers();
                this.users.ForEach(u => context.Users.Add(u));
                context.SaveChanges();
            }
            else
            {
                this.users = context.Users.ToList();
            }

            if (!(context.Roles.Count() > 1))
            {
                this.AddUsersToRoles(context);
                context.SaveChanges();
            }

            if (!context.Articles.Any())
            {
                this.articles = this.GenerateArticles(context);
                this.articles.ForEach(a => context.Articles.Add(a));
                context.SaveChanges();
            }
            else
            {
                this.articles = context.Articles.ToList();
            }

            if (!context.Works.Any())
            {
                this.works = this.GenerateWorks(context);
                this.works.ForEach(w => context.Works.Add(w));
                context.SaveChanges();
            }
            else
            {
                this.works = context.Works.ToList();
            }

            // TODO: Add more seed.

            // TODO: Add Likes

            // TODO: Add Tests
            // TODO: Add Questions
            // TODO: Add Grades
        }

        private List<Work> GenerateWorks(ApplicationDbContext context)
        {
            var students = context.Users.ToList().Where(u => this.userManager.IsInRole(u.Id, StudentRoleName)).ToList();
            var generatedWorks = new List<Work>();

            foreach (var student in students)
            {
                for (int i = 0; i < 3; i++)
                {
                    var work = new Work()
                    {
                        Title = "This is my unique title.",
                        Topic = this.topics[this.random.Next(0, this.topics.Count)],
                        Content = "This is nothing but blaberish",
                        CreatedById = student.Id,
                    };
                    generatedWorks.Add(work);
                }
            }

            return generatedWorks;
        }

        private List<Article> GenerateArticles(ApplicationDbContext context)
        {
            const int numberOfArticles = 10;

            var teacher = context.Users.ToList().FirstOrDefault(u => this.userManager.IsInRole(u.Id, TeacherRoleName));
            var generatedArticles = new List<Article>();

            if (teacher != null)
            {
                for (int i = 0; i < numberOfArticles; i++)
                {
                    var article = new Article()
                    {
                        Title = "This is just an article",
                        Content = this.GetContentForArticle(),
                        Topic = this.topics[this.random.Next(0, this.topics.Count)],
                        CreatedById = teacher.Id,
                    };
                    if (generatedArticles.Count > 0)
                    {
                        article.RelatedArticles.Add(generatedArticles[0]);
                    }

                    generatedArticles.Add(article);
                }
            }

            return generatedArticles;
        }

        private void AddUsersToRoles(ApplicationDbContext context)
        {
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            var currentUsers = context.Users.ToList();

            if (!context.Roles.Any(r => r.Name == StudentRoleName))
            {
                var role = new IdentityRole { Name = StudentRoleName };

                manager.Create(role);

                for (int i = 0; i < currentUsers.Count / 2; i++)
                {
                    this.userManager.AddToRole(currentUsers[i].Id, role.Name);
                }
            }

            if (!context.Roles.Any(r => r.Name == TeacherRoleName))
            {
                var role = new IdentityRole { Name = TeacherRoleName };

                manager.Create(role);

                for (int i = currentUsers.Count - 1; i < currentUsers.Count; i++)
                {
                    this.userManager.AddToRole(currentUsers[i].Id, role.Name);
                }
            }
        }

        private List<User> GenerateUsers()
        {
            const int numberOfUsers = 10;
            const string defaultAvatar = "http://www.avatarys.com/var/albums/Cool-Avatars/Mix-Avatars/Cool-avatars-anonymous-avatar.jpg?m=1439941438";

            var generatedUsers = new List<User>();
            for (int i = 0; i < numberOfUsers; i++)
            {
                var user = new User
                {
                    UserName = "user" + i,
                    Email = "user" + i + "@cool.com",
                    PasswordHash = this.userManager.PasswordHasher.HashPassword("user" + i + "pass"),
                    AvatarUrl = defaultAvatar,
                    FirstName = "Toshko",
                    LastName = "Goshkov",
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                user.UniversityId = this.universities[this.random.Next(0, this.universities.Count)].Id;

                generatedUsers.Add(user);
            }

            return generatedUsers;
        }

        private List<Topic> GenerateTopics()
        {
            var generatedTopics = new List<Topic>();

            generatedTopics.Add(new Topic
            {
                Value = "International Law"
            });

            generatedTopics.Add(new Topic
            {
                Value = "European Law"
            });

            generatedTopics.Add(new Topic
            {
                Value = "Labour Law"
            });

            generatedTopics.Add(new Topic
            {
                Value = "Trade Law"
            });

            generatedTopics.Add(new Topic
            {
                Value = "Marriage Law"
            });

            return generatedTopics;
        }

        private List<University> GenerateUniversities()
        {
            var generatedUniversities = new List<University>();

            generatedUniversities.Add(new University()
            {
                Name = "None"
            });

            generatedUniversities.Add(new University
            {
                Name = "Sofia University St. Kliment Ohridski"
            });

            generatedUniversities.Add(new University
            {
                Name = "University of National and World Economy"
            });

            generatedUniversities.Add(new University
            {
                Name = "New Bulgarian University"
            });

            return generatedUniversities;
        }

        private string GetContentForArticle()
        {
            return @"
Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.

It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.The point of using Lorem Ipsum is that it has a more-or - less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.Various versions have evolved over the years, sometimes by accident, sometimes on purpose(injected humour and the like).";
        }
    }
}
