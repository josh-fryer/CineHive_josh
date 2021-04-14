namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveImg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Images", new[] { "UserProfile_ProfileId" });
            DropColumn("dbo.Images", "UserProfile_ProfileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "UserProfile_ProfileId", c => c.Int());
            CreateIndex("dbo.Images", "UserProfile_ProfileId");
            AddForeignKey("dbo.Images", "UserProfile_ProfileId", "dbo.UserProfiles", "ProfileId");
        }
    }
}
