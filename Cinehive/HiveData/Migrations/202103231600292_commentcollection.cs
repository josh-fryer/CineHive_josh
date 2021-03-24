namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentcollection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostComments", "UserProfile_ProfileId", c => c.Int());
            CreateIndex("dbo.PostComments", "UserProfile_ProfileId");
            AddForeignKey("dbo.PostComments", "UserProfile_ProfileId", "dbo.UserProfiles", "ProfileId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostComments", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropIndex("dbo.PostComments", new[] { "UserProfile_ProfileId" });
            DropColumn("dbo.PostComments", "UserProfile_ProfileId");
        }
    }
}
