namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApiIdFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "ApiId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "ApiId", c => c.Int(nullable: false));
        }
    }
}
