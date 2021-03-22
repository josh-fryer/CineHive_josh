namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FaveGenreChanges : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.FaveGenres", new[] { "UserProfile_ProfileId" });
            AddColumn("dbo.Genres", "UserProfile_ProfileId", c => c.Int());
            CreateIndex("dbo.Genres", "UserProfile_ProfileId");
            DropTable("dbo.FaveGenres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FaveGenres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GenreId = c.Int(nullable: false),
                        UserProfile_ProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropIndex("dbo.Genres", new[] { "UserProfile_ProfileId" });
            DropColumn("dbo.Genres", "UserProfile_ProfileId");
            CreateIndex("dbo.FaveGenres", "UserProfile_ProfileId");
        }
    }
}
