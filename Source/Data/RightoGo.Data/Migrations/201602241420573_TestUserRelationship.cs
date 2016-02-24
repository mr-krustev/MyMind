namespace RightoGo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class TestUserRelationship : DbMigration
    {
        public override void Up()
        {
           this.DropForeignKey("dbo.AspNetUsers", "Test_Id", "dbo.Tests");
           this.DropIndex("dbo.AspNetUsers", new[] { "Test_Id" });
           this.DropColumn("dbo.AspNetUsers", "Test_Id");
        }

        public override void Down()
        {
           this.AddColumn("dbo.AspNetUsers", "Test_Id", c => c.Int());
           this.CreateIndex("dbo.AspNetUsers", "Test_Id");
           this.AddForeignKey("dbo.AspNetUsers", "Test_Id", "dbo.Tests", "Id");
        }
    }
}
