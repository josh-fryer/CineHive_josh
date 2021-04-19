namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class undoOfOriginalPost : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "OriginalPost_PostId", "dbo.Posts");
            DropIndex("dbo.Posts", new[] { "OriginalPost_PostId" });
            DropColumn("dbo.Posts", "OriginalPost_PostId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "OriginalPost_PostId", c => c.Int());
            CreateIndex("dbo.Posts", "OriginalPost_PostId");
            AddForeignKey("dbo.Posts", "OriginalPost_PostId", "dbo.Posts", "PostId");
        }
    }
}
