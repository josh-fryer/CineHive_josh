namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class privacyint : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Privacy", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "Privacy");
        }
    }
}
