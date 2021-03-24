namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeditedtocommentandpost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostComments", "Edited", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "Edited", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Edited");
            DropColumn("dbo.PostComments", "Edited");
        }
    }
}
