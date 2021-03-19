namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MatchedNewClassDiagram : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Messages");
            
            DropForeignKey("dbo.FaveGenres", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.FaveGenres", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "MainUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "FriendUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Images", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Likes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "RecipientId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "ReceiverId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostComments", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendRequests", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendRequests", "ReceiverId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostComments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Friends", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Posts", "ProfileId", "dbo.UserProfiles");
            DropIndex("dbo.FaveGenres", new[] { "UserId" });
            DropIndex("dbo.FaveGenres", new[] { "GenreId" });
            DropIndex("dbo.Friends", new[] { "MainUserId" });
            DropIndex("dbo.Friends", new[] { "FriendUserId" });
            DropIndex("dbo.Friends", new[] { "UserProfile_ProfileId" });
            DropIndex("dbo.Images", new[] { "UserId" });
            DropIndex("dbo.Likes", new[] { "UserId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropIndex("dbo.Messages", new[] { "RecipientId" });
            DropIndex("dbo.Notifications", new[] { "SenderId" });
            DropIndex("dbo.Notifications", new[] { "ReceiverId" });
            DropIndex("dbo.PostComments", new[] { "PostId" });
            DropIndex("dbo.PostComments", new[] { "UserID" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "ProfileId" });
            DropIndex("dbo.FriendRequests", new[] { "SenderId" });
            DropIndex("dbo.FriendRequests", new[] { "ReceiverId" });
            DropColumn("dbo.Messages", "SenderId");
            DropColumn("dbo.Messages", "RecipientId");
            DropColumn("dbo.Messages", "MessageId");
            RenameColumn(table: "dbo.PostComments", name: "PostId", newName: "Post_PostId");
            RenameColumn(table: "dbo.Posts", name: "ProfileId", newName: "UserProfile_ProfileId");
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        AlbumName = c.String(),
                        AlbumDesc = c.String(),
                    })
                .PrimaryKey(t => t.AlbumId);
            
            CreateTable(
                "dbo.Awards",
                c => new
                    {
                        AwardId = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        UserProfile_ProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.AwardId)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_ProfileId)
                .Index(t => t.UserProfile_ProfileId);
            
            AddColumn("dbo.Images", "Album_AlbumId", c => c.Int());
            AddColumn("dbo.Messages", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Messages", "UserProfile_ProfileId", c => c.Int());
            AddColumn("dbo.Messages", "UserProfile_ProfileId1", c => c.Int());
            AddColumn("dbo.Notifications", "Type", c => c.String());
            AddColumn("dbo.Notifications", "UserProfile_ProfileId", c => c.Int());
            AddColumn("dbo.FriendRequests", "UserProfile_ProfileId", c => c.Int());
            AddColumn("dbo.FriendRequests", "UserProfile_ProfileId1", c => c.Int());
            AddColumn("dbo.UserProfiles", "UserProfile_ProfileId", c => c.Int());
            AddColumn("dbo.UserProfiles", "UserProfile_ProfileId1", c => c.Int());
            AddColumn("dbo.UserProfiles", "UserProfile_ProfileId2", c => c.Int());
            AlterColumn("dbo.PostComments", "Post_PostId", c => c.Int());
            AlterColumn("dbo.Posts", "UserProfile_ProfileId", c => c.Int());
            AddPrimaryKey("dbo.Messages", "Id");
            CreateIndex("dbo.Images", "Album_AlbumId");
            CreateIndex("dbo.FriendRequests", "UserProfile_ProfileId");
            CreateIndex("dbo.FriendRequests", "UserProfile_ProfileId1");
            CreateIndex("dbo.Messages", "UserProfile_ProfileId");
            CreateIndex("dbo.Messages", "UserProfile_ProfileId1");
            CreateIndex("dbo.Notifications", "UserProfile_ProfileId");
            CreateIndex("dbo.PostComments", "Post_PostId");
            CreateIndex("dbo.Posts", "UserProfile_ProfileId");
            CreateIndex("dbo.UserProfiles", "UserProfile_ProfileId");
            CreateIndex("dbo.UserProfiles", "UserProfile_ProfileId1");
            CreateIndex("dbo.UserProfiles", "UserProfile_ProfileId2");
            AddForeignKey("dbo.Images", "Album_AlbumId", "dbo.Albums", "AlbumId");
            AddForeignKey("dbo.UserProfiles", "UserProfile_ProfileId", "dbo.UserProfiles", "ProfileId");
            AddForeignKey("dbo.UserProfiles", "UserProfile_ProfileId1", "dbo.UserProfiles", "ProfileId");
            AddForeignKey("dbo.Notifications", "UserProfile_ProfileId", "dbo.UserProfiles", "ProfileId");
            AddForeignKey("dbo.FriendRequests", "UserProfile_ProfileId", "dbo.UserProfiles", "ProfileId");
            AddForeignKey("dbo.Messages", "UserProfile_ProfileId", "dbo.UserProfiles", "ProfileId");
            AddForeignKey("dbo.FriendRequests", "UserProfile_ProfileId1", "dbo.UserProfiles", "ProfileId");
            AddForeignKey("dbo.Messages", "UserProfile_ProfileId1", "dbo.UserProfiles", "ProfileId");
            AddForeignKey("dbo.PostComments", "Post_PostId", "dbo.Posts", "PostId");
            AddForeignKey("dbo.UserProfiles", "UserProfile_ProfileId2", "dbo.UserProfiles", "ProfileId");
            AddForeignKey("dbo.Posts", "UserProfile_ProfileId", "dbo.UserProfiles", "ProfileId");
            DropColumn("dbo.FaveGenres", "UserId");
            DropColumn("dbo.Images", "UserId");
            DropColumn("dbo.Notifications", "SenderId");
            DropColumn("dbo.Notifications", "ReceiverId");
            DropColumn("dbo.PostComments", "UserID");
            DropColumn("dbo.Posts", "UserId");
            DropColumn("dbo.FriendRequests", "SenderId");
            DropColumn("dbo.FriendRequests", "ReceiverId");
            DropTable("dbo.Followers");
            DropTable("dbo.Friends");
            DropTable("dbo.Likes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        LikeId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LikeId);
            
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        MainUserId = c.String(nullable: false, maxLength: 128),
                        FriendUserId = c.String(nullable: false, maxLength: 128),
                        UserProfile_ProfileId = c.Int(),
                    })
                .PrimaryKey(t => new { t.MainUserId, t.FriendUserId });
            
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        FollowerId = c.Int(nullable: false),
                        FollowingId = c.Int(nullable: false),
                        DateFollowed = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FollowingId });
            
            AddColumn("dbo.FriendRequests", "ReceiverId", c => c.String(maxLength: 128));
            AddColumn("dbo.FriendRequests", "SenderId", c => c.String(maxLength: 128));
            AddColumn("dbo.Posts", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.PostComments", "UserID", c => c.String(maxLength: 128));
            AddColumn("dbo.Notifications", "ReceiverId", c => c.String(maxLength: 128));
            AddColumn("dbo.Notifications", "SenderId", c => c.String(maxLength: 128));
            AddColumn("dbo.Messages", "MessageId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Messages", "RecipientId", c => c.String(maxLength: 128));
            AddColumn("dbo.Messages", "SenderId", c => c.String(maxLength: 128));
            AddColumn("dbo.Images", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.FaveGenres", "UserId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Posts", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfiles", "UserProfile_ProfileId2", "dbo.UserProfiles");
            DropForeignKey("dbo.PostComments", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.Messages", "UserProfile_ProfileId1", "dbo.UserProfiles");
            DropForeignKey("dbo.FriendRequests", "UserProfile_ProfileId1", "dbo.UserProfiles");
            DropForeignKey("dbo.Messages", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.FriendRequests", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Notifications", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfiles", "UserProfile_ProfileId1", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfiles", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Awards", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Images", "Album_AlbumId", "dbo.Albums");
            DropIndex("dbo.UserProfiles", new[] { "UserProfile_ProfileId2" });
            DropIndex("dbo.UserProfiles", new[] { "UserProfile_ProfileId1" });
            DropIndex("dbo.UserProfiles", new[] { "UserProfile_ProfileId" });
            DropIndex("dbo.Posts", new[] { "UserProfile_ProfileId" });
            DropIndex("dbo.PostComments", new[] { "Post_PostId" });
            DropIndex("dbo.Notifications", new[] { "UserProfile_ProfileId" });
            DropIndex("dbo.Messages", new[] { "UserProfile_ProfileId1" });
            DropIndex("dbo.Messages", new[] { "UserProfile_ProfileId" });
            DropIndex("dbo.FriendRequests", new[] { "UserProfile_ProfileId1" });
            DropIndex("dbo.FriendRequests", new[] { "UserProfile_ProfileId" });
            DropIndex("dbo.Awards", new[] { "UserProfile_ProfileId" });
            DropIndex("dbo.Images", new[] { "Album_AlbumId" });
            DropPrimaryKey("dbo.Messages");
            AlterColumn("dbo.Posts", "UserProfile_ProfileId", c => c.Int(nullable: false));
            AlterColumn("dbo.PostComments", "Post_PostId", c => c.Int(nullable: false));
            DropColumn("dbo.UserProfiles", "UserProfile_ProfileId2");
            DropColumn("dbo.UserProfiles", "UserProfile_ProfileId1");
            DropColumn("dbo.UserProfiles", "UserProfile_ProfileId");
            DropColumn("dbo.FriendRequests", "UserProfile_ProfileId1");
            DropColumn("dbo.FriendRequests", "UserProfile_ProfileId");
            DropColumn("dbo.Notifications", "UserProfile_ProfileId");
            DropColumn("dbo.Notifications", "Type");
            DropColumn("dbo.Messages", "UserProfile_ProfileId1");
            DropColumn("dbo.Messages", "UserProfile_ProfileId");
            DropColumn("dbo.Messages", "Id");
            DropColumn("dbo.Images", "Album_AlbumId");
            DropTable("dbo.Awards");
            DropTable("dbo.Albums");
            AddPrimaryKey("dbo.Messages", "MessageId");
            RenameColumn(table: "dbo.Posts", name: "UserProfile_ProfileId", newName: "ProfileId");
            RenameColumn(table: "dbo.PostComments", name: "Post_PostId", newName: "PostId");
            CreateIndex("dbo.FriendRequests", "ReceiverId");
            CreateIndex("dbo.FriendRequests", "SenderId");
            CreateIndex("dbo.Posts", "ProfileId");
            CreateIndex("dbo.Posts", "UserId");
            CreateIndex("dbo.PostComments", "UserID");
            CreateIndex("dbo.PostComments", "PostId");
            CreateIndex("dbo.Notifications", "ReceiverId");
            CreateIndex("dbo.Notifications", "SenderId");
            CreateIndex("dbo.Messages", "RecipientId");
            CreateIndex("dbo.Messages", "SenderId");
            CreateIndex("dbo.Likes", "UserId");
            CreateIndex("dbo.Images", "UserId");
            CreateIndex("dbo.Friends", "UserProfile_ProfileId");
            CreateIndex("dbo.Friends", "FriendUserId");
            CreateIndex("dbo.Friends", "MainUserId");
            CreateIndex("dbo.FaveGenres", "GenreId");
            CreateIndex("dbo.FaveGenres", "UserId");
            AddForeignKey("dbo.Posts", "ProfileId", "dbo.UserProfiles", "ProfileId", cascadeDelete: true);
            AddForeignKey("dbo.Friends", "UserProfile_ProfileId", "dbo.UserProfiles", "ProfileId");
            AddForeignKey("dbo.PostComments", "PostId", "dbo.Posts", "PostId", cascadeDelete: true);
            AddForeignKey("dbo.FriendRequests", "ReceiverId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FriendRequests", "SenderId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.PostComments", "UserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Notifications", "ReceiverId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Notifications", "SenderId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Messages", "RecipientId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Likes", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Images", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Friends", "FriendUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Friends", "MainUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FaveGenres", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FaveGenres", "GenreId", "dbo.Genres", "ID", cascadeDelete: true);
        }
    }
}
