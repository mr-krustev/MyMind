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
            this.userStore = new UserStore<User>(context);
            this.userManager = new UserManager<User>(this.userStore);

            this.topics = this.GenerateTopics();
            this.topics.ForEach(t => context.Topics.Add(t));
            this.universities = this.GenerateUniversities();
            this.universities.ForEach(u => context.University.Add(u));
            context.SaveChanges();

            this.users = this.GenerateUsers();
            this.AddUsersToRoles(context);
            context.SaveChanges();

            this.articles = this.GenerateArticles(context);
            this.articles.ForEach(a => context.Articles.Add(a));
            context.SaveChanges();

            this.works = this.GenerateWorks(context);
            this.works.ForEach(w => context.Works.Add(w));
            context.SaveChanges();

            // TODO: Add more seed.

            // TODO: Add Likes

            // TODO: Add Tests
            // TODO: Add Questions
            // TODO: Add Grades
        }

        private List<Work> GenerateWorks(ApplicationDbContext context)
        {
            var students = context.Users.ToList().Where(u => this.userManager.IsInRole(u.Id, TeacherRoleName)).ToList();
            var generatedWorks = new List<Work>();

            foreach (var student in students)
            {
                var work = new Work()
                {
                    Title = "This is my unique title.",
                    Topic = this.topics[this.random.Next(0, this.topics.Count)],
                    Content = "This is nothing but blaberish",
                    CreatedById = student.Id,
                    CreatedBy = student,
                    IsPrivate = this.random.Next(1, 5) % 2 == 0,
                };
                work.AuthorizedUsers.Add(student);
                generatedWorks.Add(work);
            }

            return generatedWorks;
        }

        private List<Article> GenerateArticles(ApplicationDbContext context)
        {
            const int numberOfArticles = 3;

            var teacher = context.Users.ToList().FirstOrDefault(u => this.userManager.IsInRole(u.Id, TeacherRoleName));
            var generatedArticles = new List<Article>();

            if (teacher != null)
            {
                for (int i = 0; i < numberOfArticles; i++)
                {
                    var article = new Article()
                    {
                        Title = "This is just an article",
                        Content = "With no real purpose, except test. Oh, snap it's a number: " + i + "!",
                        Topic = this.topics[this.random.Next(0, this.topics.Count)],
                        CreatedBy = teacher,
                        CreatedById = teacher.Id,
                        IsPrivate = i % 2 == 1,
                    };
                    article.AuthorizedUsers.Add(teacher);
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

            var generatedUsers = new List<User>();
            for (int i = 0; i < numberOfUsers; i++)
            {
                var user = new User
                {
                    UserName = "user" + i + "@cool.com",
                    Email = "user" + i + "@cool.com",
                };

                // These users later on will have roles Student(first 5) and Teacher(last one)
                if (i < numberOfUsers / 2 || i == numberOfUsers - 1)
                {
                    user.UniversityId = this.universities[this.random.Next(0, this.universities.Count)].Id;
                }

                generatedUsers.Add(user);
                this.userManager.Create(user, "user" + i);
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
    }
}
