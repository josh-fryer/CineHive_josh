namespace Cinehive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialiseThree : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        FollowerId = c.Int(nullable: false),
                        FollowingId = c.Int(nullable: false),
                        DateFollowed = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FollowingId });
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        RecipientId = c.Int(nullable: false),
                        MessageContent = c.String(),
                        MessageSent = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.PostComments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CommentContent = c.String(),
                        DateCommented = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PostContent = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        ReqSenderId = c.Int(nullable: false),
                        ReqRecipientId = c.Int(nullable: false),
                        ReqDateSent = c.DateTime(nullable: false),
                        ReqStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        AboutMe = c.String(),
                        FollowerCount = c.Int(nullable: false),
                        FollowingCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProfileId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Requests");
            DropTable("dbo.Posts");
            DropTable("dbo.PostComments");
            DropTable("dbo.Messages");
            DropTable("dbo.Followers");
        }
    }
}
