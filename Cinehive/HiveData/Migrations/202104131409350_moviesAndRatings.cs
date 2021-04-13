namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moviesAndRatings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PosterPath = c.String(),
                        Overview = c.String(),
                        ReleaseDate = c.DateTime(),
                        Title = c.String(),
                        VideoKey = c.String(),
                        viewCounter = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Stars = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Movie_ID = c.Int(),
                        UserProfile_ProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movies", t => t.Movie_ID)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_ProfileId)
                .Index(t => t.Movie_ID)
                .Index(t => t.UserProfile_ProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Ratings", "Movie_ID", "dbo.Movies");
            DropIndex("dbo.Ratings", new[] { "UserProfile_ProfileId" });
            DropIndex("dbo.Ratings", new[] { "Movie_ID" });
            DropTable("dbo.Ratings");
            DropTable("dbo.Movies");
        }
    }
}
