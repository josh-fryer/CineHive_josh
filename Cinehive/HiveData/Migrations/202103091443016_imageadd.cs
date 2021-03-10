namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Images", new[] { "UserId" });
            DropTable("dbo.Images");
        }
    }
}
