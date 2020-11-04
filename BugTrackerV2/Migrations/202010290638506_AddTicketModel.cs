namespace BugTrackerV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            CreateTable(
                "dbo.TicketAttachment",
                c => new
                    {
                        TicketAttachmentID = c.Int(nullable: false, identity: true),
                        TicketID = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                        FileName = c.String(nullable: false, maxLength: 100),
                        FileLocation = c.String(nullable: false, maxLength: 150),
                        AttachedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TicketAttachmentID)
                .ForeignKey("dbo.Ticket", t => t.TicketID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.TicketID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        SubmitterID = c.String(nullable: false, maxLength: 128),
                        OwnerID = c.String(maxLength: 128),
                        Subject = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 2500),
                        Environment = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                        Edited = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerID)
                .ForeignKey("dbo.AspNetUsers", t => t.SubmitterID)
                .Index(t => t.SubmitterID)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.TicketComment",
                c => new
                    {
                        TicketCommentID = c.Int(nullable: false, identity: true),
                        TicketID = c.Int(nullable: false),
                        CommentDescription = c.String(nullable: false, maxLength: 2500),
                        PostDate = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TicketCommentID)
                .ForeignKey("dbo.Ticket", t => t.TicketID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.TicketID)
                .Index(t => t.User_Id);
            
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TicketAttachment", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.TicketComment", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TicketComment", "TicketID", "dbo.Ticket");
            DropForeignKey("dbo.TicketAttachment", "TicketID", "dbo.Ticket");
            DropForeignKey("dbo.Ticket", "SubmitterID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ticket", "OwnerID", "dbo.AspNetUsers");
            DropIndex("dbo.TicketComment", new[] { "User_Id" });
            DropIndex("dbo.TicketComment", new[] { "TicketID" });
            DropIndex("dbo.Ticket", new[] { "OwnerID" });
            DropIndex("dbo.Ticket", new[] { "SubmitterID" });
            DropIndex("dbo.TicketAttachment", new[] { "UserID" });
            DropIndex("dbo.TicketAttachment", new[] { "TicketID" });
            DropTable("dbo.TicketComment");
            DropTable("dbo.Ticket");
            DropTable("dbo.TicketAttachment");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
