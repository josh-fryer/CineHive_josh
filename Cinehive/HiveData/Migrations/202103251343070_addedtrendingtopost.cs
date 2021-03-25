namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtrendingtopost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Trending", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Trending");
        }
    }
}
