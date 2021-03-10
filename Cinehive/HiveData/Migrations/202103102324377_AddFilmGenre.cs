namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFilmGenre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FaveGenres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        GenreId = c.Int(nullable: false),
                        UserProfile_ProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_ProfileId)
                .Index(t => t.UserId)
                .Index(t => t.GenreId)
                .Index(t => t.UserProfile_ProfileId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApiId = c.Int(nullable: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FaveGenres", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.FaveGenres", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FaveGenres", "GenreId", "dbo.Genres");
            DropIndex("dbo.FaveGenres", new[] { "UserProfile_ProfileId" });
            DropIndex("dbo.FaveGenres", new[] { "GenreId" });
            DropIndex("dbo.FaveGenres", new[] { "UserId" });
            DropTable("dbo.Genres");
            DropTable("dbo.FaveGenres");
        }
    }
}
