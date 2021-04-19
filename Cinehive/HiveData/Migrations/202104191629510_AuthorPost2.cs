namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorPost2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "AuthorPost_PostId", c => c.Int());
            CreateIndex("dbo.Posts", "AuthorPost_PostId");
            AddForeignKey("dbo.Posts", "AuthorPost_PostId", "dbo.Posts", "PostId");
            DropColumn("dbo.Posts", "Author");
            DropColumn("dbo.Posts", "AuthorPP");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "AuthorPP", c => c.String());
            AddColumn("dbo.Posts", "Author", c => c.String());
            DropForeignKey("dbo.Posts", "AuthorPost_PostId", "dbo.Posts");
            DropIndex("dbo.Posts", new[] { "AuthorPost_PostId" });
            DropColumn("dbo.Posts", "AuthorPost_PostId");
        }
    }
}
