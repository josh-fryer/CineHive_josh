namespace Cinehive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterposttable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "UserId_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Posts", "UserId_Id");
            AddForeignKey("dbo.Posts", "UserId_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Posts", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Posts", "UserId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "UserId_Id" });
            DropColumn("dbo.Posts", "UserId_Id");
        }
    }
}
