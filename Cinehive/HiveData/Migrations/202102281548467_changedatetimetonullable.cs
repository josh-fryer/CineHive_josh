namespace Cinehive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedatetimetonullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfiles", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfiles", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
