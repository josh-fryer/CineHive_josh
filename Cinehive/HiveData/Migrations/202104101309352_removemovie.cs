namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removemovie : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Movies");
        }
        
        public override void Down()
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
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
