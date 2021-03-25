namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrendingtoPopular : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Popular", c => c.Boolean(nullable: false));
            DropColumn("dbo.Posts", "Trending");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Trending", c => c.Boolean(nullable: false));
            DropColumn("dbo.Posts", "Popular");
        }
    }
}
