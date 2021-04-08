namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "hasFilmLink", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "hasFilmLink");
        }
    }
}
