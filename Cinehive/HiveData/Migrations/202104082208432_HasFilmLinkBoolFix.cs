namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HasFilmLinkBoolFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "hasFilmLink", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "hasFilmLink", c => c.Boolean());
        }
    }
}
