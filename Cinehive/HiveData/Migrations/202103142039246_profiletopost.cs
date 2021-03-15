namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profiletopost : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Posts", new[] { "UserProfile_ProfileId" });
            RenameColumn(table: "dbo.Posts", name: "UserProfile_ProfileId", newName: "ProfileId");
            AlterColumn("dbo.Posts", "ProfileId", c => c.Int(nullable: true));
            CreateIndex("dbo.Posts", "ProfileId");
            AddForeignKey("dbo.Posts", "ProfileId", "dbo.UserProfiles", "ProfileId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "ProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Posts", new[] { "ProfileId" });
            AlterColumn("dbo.Posts", "ProfileId", c => c.Int());
            RenameColumn(table: "dbo.Posts", name: "ProfileId", newName: "UserProfile_ProfileId");
            CreateIndex("dbo.Posts", "UserProfile_ProfileId");
            AddForeignKey("dbo.Posts", "UserProfile_ProfileId", "dbo.UserProfiles", "ProfileId");
        }
    }
}
