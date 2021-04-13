namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moviesModeltweak : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieApi_ID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "MovieApi_ID");
        }
    }
}
