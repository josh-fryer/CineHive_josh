namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notificationModelChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notifications", "senderProfileID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notifications", "senderProfileID", c => c.Int(nullable: false));
        }
    }
}
