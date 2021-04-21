namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnmapAwardsOnPost : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "Awards");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Awards", c => c.Int(nullable: false));
        }
    }
}
