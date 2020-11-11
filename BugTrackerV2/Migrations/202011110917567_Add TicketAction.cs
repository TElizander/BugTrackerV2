namespace BugTrackerV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketAction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketAction",
                c => new
                    {
                        TicketActionID = c.Int(nullable: false, identity: true),
                        TicketID = c.Int(nullable: false),
                        Field = c.String(nullable: false),
                        Action = c.Int(nullable: false),
                        From = c.String(),
                        To = c.String(),
                        ActionTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TicketActionID)
                .ForeignKey("dbo.Ticket", t => t.TicketID)
                .Index(t => t.TicketID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketAction", "TicketID", "dbo.Ticket");
            DropIndex("dbo.TicketAction", new[] { "TicketID" });
            DropTable("dbo.TicketAction");
        }
    }
}
