namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postforprofilepicchange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PictureChange", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "AuthorPP", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "AuthorPP");
            DropColumn("dbo.Posts", "PictureChange");
        }
    }
}
