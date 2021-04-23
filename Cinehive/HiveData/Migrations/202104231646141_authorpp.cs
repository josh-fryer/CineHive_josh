namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authorpp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "AuthorPicture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "AuthorPicture");
        }
    }
}
