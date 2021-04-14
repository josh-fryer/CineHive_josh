namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "UserProfile_ProfileId", c => c.Int());
            CreateIndex("dbo.Images", "UserProfile_ProfileId");
            AddForeignKey("dbo.Images", "UserProfile_ProfileId", "dbo.UserProfiles", "ProfileId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Images", new[] { "UserProfile_ProfileId" });
            DropColumn("dbo.Images", "UserProfile_ProfileId");
        }
    }
}
