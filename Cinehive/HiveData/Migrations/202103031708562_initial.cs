namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                "dbo.Friends",
                c => new
                    {
                        MainUserId = c.String(nullable: false, maxLength: 128),
                        FriendUserId = c.String(nullable: false, maxLength: 128),
                        UserProfile_ProfileId = c.Int(),
                    })
                .PrimaryKey(t => new { t.MainUserId, t.FriendUserId })
                .ForeignKey("dbo.AspNetUsers", t => t.MainUserId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.FriendUserId, cascadeDelete: false)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_ProfileId)
                .Index(t => t.MainUserId)
                .Index(t => t.FriendUserId)
                .Index(t => t.UserProfile_ProfileId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        SenderId = c.String(maxLength: 128),
                        RecipientId = c.String(maxLength: 128),
                        MessageId = c.Int(nullable: false, identity: true),
                        MessageContent = c.String(),
                        MessageSent = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId)
                .ForeignKey("dbo.AspNetUsers", t => t.RecipientId)
                .Index(t => t.SenderId)
                .Index(t => t.RecipientId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        SenderId = c.String(maxLength: 128),
                        ReceiverId = c.String(maxLength: 128),
                        Id = c.Int(nullable: false, identity: true),
                        DateReceived = c.DateTime(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId)
                .ForeignKey("dbo.AspNetUsers", t => t.ReceiverId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
            CreateTable(
                "dbo.PostComments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                        CommentContent = c.String(),
                        DateCommented = c.DateTime(nullable: false),
                        Awards = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: false)
                .Index(t => t.PostId)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        PostContent = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                        Awards = c.Int(nullable: false),
                        UserProfile_ProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_ProfileId)
                .Index(t => t.UserId)
                .Index(t => t.UserProfile_ProfileId);
            
            CreateTable(
                "dbo.FriendRequests",
                c => new
                    {
                        SenderId = c.String(maxLength: 128),
                        ReceiverId = c.String(maxLength: 128),
                        Id = c.Int(nullable: false, identity: true),
                        DateSent = c.DateTime(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId)
                .ForeignKey("dbo.AspNetUsers", t => t.ReceiverId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ImagePath = c.String(),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(),
                        AboutMe = c.String(),
                    })
                .PrimaryKey(t => t.ProfileId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Friends", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FriendRequests", "ReceiverId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendRequests", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostComments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.PostComments", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "ReceiverId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "RecipientId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "FriendUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "MainUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserProfiles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.FriendRequests", new[] { "ReceiverId" });
            DropIndex("dbo.FriendRequests", new[] { "SenderId" });
            DropIndex("dbo.Posts", new[] { "UserProfile_ProfileId" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.PostComments", new[] { "UserID" });
            DropIndex("dbo.PostComments", new[] { "PostId" });
            DropIndex("dbo.Notifications", new[] { "ReceiverId" });
            DropIndex("dbo.Notifications", new[] { "SenderId" });
            DropIndex("dbo.Messages", new[] { "RecipientId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Friends", new[] { "UserProfile_ProfileId" });
            DropIndex("dbo.Friends", new[] { "FriendUserId" });
            DropIndex("dbo.Friends", new[] { "MainUserId" });
            DropTable("dbo.UserProfiles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.FriendRequests");
            DropTable("dbo.Posts");
            DropTable("dbo.PostComments");
            DropTable("dbo.Notifications");
            DropTable("dbo.Messages");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Friends");
            DropTable("dbo.Followers");
        }
    }
}
