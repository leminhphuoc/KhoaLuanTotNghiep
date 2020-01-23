namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderInformation",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IdProduct = c.Long(nullable: false),
                        IdOrder = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IdCustomer = c.Long(nullable: false),
                        createdDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Order");
            DropTable("dbo.OrderInformation");
        }
    }
}
