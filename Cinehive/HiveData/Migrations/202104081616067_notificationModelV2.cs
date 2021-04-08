namespace Cinehive.HiveData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notificationModelV2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Notifications", name: "senderProfile_ProfileId", newName: "UserProfile_ProfileId");
            RenameIndex(table: "dbo.Notifications", name: "IX_senderProfile_ProfileId", newName: "IX_UserProfile_ProfileId");
            AddColumn("dbo.Notifications", "senderProfileID", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "senderProfileID");
            RenameIndex(table: "dbo.Notifications", name: "IX_UserProfile_ProfileId", newName: "IX_senderProfile_ProfileId");
            RenameColumn(table: "dbo.Notifications", name: "UserProfile_ProfileId", newName: "senderProfile_ProfileId");
        }
    }
}
