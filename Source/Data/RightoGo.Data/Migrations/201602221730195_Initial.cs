namespace RightoGo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCorrect = c.Boolean(nullable: false),
                        Text = c.String(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Task = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        Test_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.Test_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Test_Id);

            this.CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 40),
                        Content = c.String(nullable: false),
                        CreatedById = c.String(nullable: false, maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        Topic_Id = c.Int(),
                        Article_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById, cascadeDelete: true)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .Index(t => t.CreatedById)
                .Index(t => t.IsDeleted)
                .Index(t => t.Topic_Id)
                .Index(t => t.Article_Id);

            this.CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AvatarUrl = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UniversityId = c.Int(),
                        Faculty = c.String(),
                        Specialty = c.String(),
                        FieldOfStudy = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Test_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.Test_Id)
                .ForeignKey("dbo.Universities", t => t.UniversityId)
                .Index(t => t.UniversityId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Test_Id);

            this.CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            this.CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        RelatedTestId = c.Int(nullable: false),
                        RelatedStudentId = c.String(nullable: false, maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.RelatedStudentId, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.RelatedTestId, cascadeDelete: true)
                .Index(t => t.RelatedTestId)
                .Index(t => t.RelatedStudentId)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedById = c.String(maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        Topic_Id = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                        User_Id1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.Topics", t => t.Topic_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id1)
                .Index(t => t.CreatedById)
                .Index(t => t.IsDeleted)
                .Index(t => t.Topic_Id)
                .Index(t => t.User_Id)
                .Index(t => t.User_Id1);

            this.CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.Works",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 40),
                        Content = c.String(nullable: false),
                        CreatedById = c.String(nullable: false, maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        Topic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById, cascadeDelete: true)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .Index(t => t.CreatedById)
                .Index(t => t.IsDeleted)
                .Index(t => t.Topic_Id);

            this.CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VoterId = c.String(nullable: false, maxLength: 128),
                        WorkId = c.Int(),
                        Type = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.VoterId, cascadeDelete: true)
                .ForeignKey("dbo.Works", t => t.WorkId)
                .Index(t => t.VoterId)
                .Index(t => t.WorkId)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            this.CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            this.CreateTable(
                "dbo.Universities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        User_Id = c.String(maxLength: 128),
                        Article_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.User_Id)
                .Index(t => t.Article_Id);

            this.CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
        }

        public override void Down()
        {
            this.DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            this.DropForeignKey("dbo.Videos", "Article_Id", "dbo.Articles");
            this.DropForeignKey("dbo.Articles", "Article_Id", "dbo.Articles");
            this.DropForeignKey("dbo.Videos", "User_Id", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.AspNetUsers", "UniversityId", "dbo.Universities");
            this.DropForeignKey("dbo.Tests", "User_Id1", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.Tests", "User_Id", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.Grades", "RelatedTestId", "dbo.Tests");
            this.DropForeignKey("dbo.Tests", "Topic_Id", "dbo.Topics");
            this.DropForeignKey("dbo.Works", "Topic_Id", "dbo.Topics");
            this.DropForeignKey("dbo.Likes", "WorkId", "dbo.Works");
            this.DropForeignKey("dbo.Likes", "VoterId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.Works", "CreatedById", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.Articles", "Topic_Id", "dbo.Topics");
            this.DropForeignKey("dbo.AspNetUsers", "Test_Id", "dbo.Tests");
            this.DropForeignKey("dbo.Questions", "Test_Id", "dbo.Tests");
            this.DropForeignKey("dbo.Tests", "CreatedById", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.Grades", "RelatedStudentId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.Articles", "CreatedById", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            this.DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            this.DropIndex("dbo.Videos", new[] { "Article_Id" });
            this.DropIndex("dbo.Videos", new[] { "User_Id" });
            this.DropIndex("dbo.Videos", new[] { "IsDeleted" });
            this.DropIndex("dbo.Universities", new[] { "IsDeleted" });
            this.DropIndex("dbo.Universities", new[] { "Name" });
            this.DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            this.DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            this.DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            this.DropIndex("dbo.Likes", new[] { "IsDeleted" });
            this.DropIndex("dbo.Likes", new[] { "WorkId" });
            this.DropIndex("dbo.Likes", new[] { "VoterId" });
            this.DropIndex("dbo.Works", new[] { "Topic_Id" });
            this.DropIndex("dbo.Works", new[] { "IsDeleted" });
            this.DropIndex("dbo.Works", new[] { "CreatedById" });
            this.DropIndex("dbo.Topics", new[] { "IsDeleted" });
            this.DropIndex("dbo.Tests", new[] { "User_Id1" });
            this.DropIndex("dbo.Tests", new[] { "User_Id" });
            this.DropIndex("dbo.Tests", new[] { "Topic_Id" });
            this.DropIndex("dbo.Tests", new[] { "IsDeleted" });
            this.DropIndex("dbo.Tests", new[] { "CreatedById" });
            this.DropIndex("dbo.Grades", new[] { "IsDeleted" });
            this.DropIndex("dbo.Grades", new[] { "RelatedStudentId" });
            this.DropIndex("dbo.Grades", new[] { "RelatedTestId" });
            this.DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            this.DropIndex("dbo.AspNetUsers", new[] { "Test_Id" });
            this.DropIndex("dbo.AspNetUsers", "UserNameIndex");
            this.DropIndex("dbo.AspNetUsers", new[] { "UniversityId" });
            this.DropIndex("dbo.Articles", new[] { "Article_Id" });
            this.DropIndex("dbo.Articles", new[] { "Topic_Id" });
            this.DropIndex("dbo.Articles", new[] { "IsDeleted" });
            this.DropIndex("dbo.Articles", new[] { "CreatedById" });
            this.DropIndex("dbo.Questions", new[] { "Test_Id" });
            this.DropIndex("dbo.Questions", new[] { "IsDeleted" });
            this.DropIndex("dbo.Answers", new[] { "IsDeleted" });
            this.DropIndex("dbo.Answers", new[] { "QuestionId" });
            this.DropTable("dbo.AspNetRoles");
            this.DropTable("dbo.Videos");
            this.DropTable("dbo.Universities");
            this.DropTable("dbo.AspNetUserRoles");
            this.DropTable("dbo.AspNetUserLogins");
            this.DropTable("dbo.Likes");
            this.DropTable("dbo.Works");
            this.DropTable("dbo.Topics");
            this.DropTable("dbo.Tests");
            this.DropTable("dbo.Grades");
            this.DropTable("dbo.AspNetUserClaims");
            this.DropTable("dbo.AspNetUsers");
            this.DropTable("dbo.Articles");
            this.DropTable("dbo.Questions");
            this.DropTable("dbo.Answers");
        }
    }
}
