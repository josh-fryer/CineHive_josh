namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfilenametoimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Filename", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "Filename");
        }
    }
}
