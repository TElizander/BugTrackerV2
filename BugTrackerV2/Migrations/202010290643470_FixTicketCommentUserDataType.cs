namespace BugTrackerV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTicketCommentUserDataType : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TicketComment", new[] { "User_Id" });
            DropColumn("dbo.TicketComment", "UserID");
            RenameColumn(table: "dbo.TicketComment", name: "User_Id", newName: "UserID");
            AlterColumn("dbo.TicketComment", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.TicketComment", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TicketComment", new[] { "UserID" });
            AlterColumn("dbo.TicketComment", "UserID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.TicketComment", name: "UserID", newName: "User_Id");
            AddColumn("dbo.TicketComment", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.TicketComment", "User_Id");
        }
    }
}
