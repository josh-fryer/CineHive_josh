namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Originalpost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "OriginalPost_PostId", c => c.Int());
            CreateIndex("dbo.Posts", "OriginalPost_PostId");
            AddForeignKey("dbo.Posts", "OriginalPost_PostId", "dbo.Posts", "PostId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "OriginalPost_PostId", "dbo.Posts");
            DropIndex("dbo.Posts", new[] { "OriginalPost_PostId" });
            DropColumn("dbo.Posts", "OriginalPost_PostId");
        }
    }
}
