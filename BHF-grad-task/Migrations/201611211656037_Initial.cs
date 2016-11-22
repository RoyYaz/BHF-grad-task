namespace BHF_grad_task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donation",
                c => new
                    {
                        DonationID = c.Int(nullable: false, identity: true),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DonationDate = c.DateTime(nullable: false),
                        Regularity = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DonationID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Forename = c.String(nullable: false, maxLength: 35),
                        Surname = c.String(nullable: false, maxLength: 35),
                        Email = c.String(nullable: false, maxLength: 255),
                        NoAddress = c.String(nullable: false, maxLength: 7),
                        Address = c.String(nullable: false, maxLength: 35),
                        PostCode = c.String(nullable: false, maxLength: 8),
                        Telephone = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donation", "UserID", "dbo.User");
            DropIndex("dbo.Donation", new[] { "UserID" });
            DropTable("dbo.User");
            DropTable("dbo.Donation");
        }
    }
}
