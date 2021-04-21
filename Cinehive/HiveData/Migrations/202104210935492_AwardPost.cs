namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AwardPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Awards", "Post_PostId", c => c.Int());
            CreateIndex("dbo.Awards", "Post_PostId");
            AddForeignKey("dbo.Awards", "Post_PostId", "dbo.Posts", "PostId");
            DropColumn("dbo.Awards", "PostId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Awards", "PostId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Awards", "Post_PostId", "dbo.Posts");
            DropIndex("dbo.Awards", new[] { "Post_PostId" });
            DropColumn("dbo.Awards", "Post_PostId");
        }
    }
}
