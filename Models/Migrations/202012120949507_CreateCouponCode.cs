namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCouponCode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CouponCode",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Value = c.String(maxLength: 100),
                        DisplayName = c.String(maxLength: 100),
                        Description = c.String(maxLength: 200),
                        DiscountValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CouponCode");
        }
    }
}
