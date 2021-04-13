namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sharepost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Shared", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Shared");
        }
    }
}
