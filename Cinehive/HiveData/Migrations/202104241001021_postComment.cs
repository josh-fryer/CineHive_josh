namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Awards", "PostComment_CommentId", c => c.Int());
            CreateIndex("dbo.Awards", "PostComment_CommentId");
            AddForeignKey("dbo.Awards", "PostComment_CommentId", "dbo.PostComments", "CommentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Awards", "PostComment_CommentId", "dbo.PostComments");
            DropIndex("dbo.Awards", new[] { "PostComment_CommentId" });
            DropColumn("dbo.Awards", "PostComment_CommentId");
        }
    }
}
