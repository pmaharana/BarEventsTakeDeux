namespace BarEventsTakeDeux.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketsAndOrdersadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        CustomerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BarCode = c.Guid(nullable: false),
                        DatePurchased = c.DateTime(),
                        PurchasedPrice = c.Double(nullable: false),
                        WasUsed = c.Boolean(nullable: false),
                        EventId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Tickets", "EventId", "dbo.Events");
            DropIndex("dbo.Tickets", new[] { "OrderId" });
            DropIndex("dbo.Tickets", new[] { "EventId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Orders");
        }
    }
}
