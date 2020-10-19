namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateServiceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Metatitle = c.String(maxLength: 250),
                        ParentID = c.Int(),
                        DisplayOrder = c.Int(),
                        CreatedDate = c.DateTime(storeType: "date"),
                        ModifiedDate = c.DateTime(storeType: "date"),
                        Status = c.Boolean(),
                        ShowOnHome = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        MetaTitle = c.String(maxLength: 250),
                        MetaKeyword = c.String(maxLength: 250),
                        MetaDescription = c.String(maxLength: 250),
                        Description = c.String(maxLength: 999),
                        Image = c.String(),
                        MoreImages = c.String(storeType: "xml"),
                        Price = c.Decimal(precision: 18, scale: 2),
                        PromotionPrice = c.Decimal(precision: 18, scale: 2),
                        IdCategory = c.Int(nullable: false),
                        Detail = c.String(storeType: "ntext"),
                        CreatedDate = c.DateTime(storeType: "date"),
                        ModifiDate = c.DateTime(storeType: "date"),
                        Status = c.Boolean(),
                        TopHot = c.DateTime(storeType: "date"),
                        IsDisplayHomePage = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Product", "quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "quantity", c => c.Int());
            DropTable("dbo.Service");
            DropTable("dbo.ServiceCategory");
        }
    }
}
