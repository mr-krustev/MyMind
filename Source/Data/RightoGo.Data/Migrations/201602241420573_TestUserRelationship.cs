namespace RightoGo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestUserRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Test_Id", "dbo.Tests");
            DropIndex("dbo.AspNetUsers", new[] { "Test_Id" });
            DropColumn("dbo.AspNetUsers", "Test_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Test_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Test_Id");
            AddForeignKey("dbo.AspNetUsers", "Test_Id", "dbo.Tests", "Id");
        }
    }
}
