namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Page",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Url = c.String(maxLength: 100),
                        Body = c.String(storeType: "ntext"),
                        MetaTitle = c.String(maxLength: 250),
                        MetaDescription = c.String(maxLength: 1000),
                        MetaKeywords = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Page");
        }
    }
}
