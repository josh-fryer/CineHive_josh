namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingalbumcollection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "UserProfile_ProfileId", c => c.Int());
            CreateIndex("dbo.Albums", "UserProfile_ProfileId");
            AddForeignKey("dbo.Albums", "UserProfile_ProfileId", "dbo.UserProfiles", "ProfileId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Albums", new[] { "UserProfile_ProfileId" });
            DropColumn("dbo.Albums", "UserProfile_ProfileId");
        }
    }
}
