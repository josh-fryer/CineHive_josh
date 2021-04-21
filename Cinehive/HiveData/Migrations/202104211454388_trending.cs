namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trending : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Trending", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Trending");
        }
    }
}
