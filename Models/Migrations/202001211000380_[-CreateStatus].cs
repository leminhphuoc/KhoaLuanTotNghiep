namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.OrderInformation", "IdStatus", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderInformation", "IdStatus");
            DropTable("dbo.OrderStatus");
        }
    }
}
