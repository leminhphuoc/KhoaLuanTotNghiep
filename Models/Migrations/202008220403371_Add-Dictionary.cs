namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDictionary : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dictionary",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Key = c.String(maxLength: 250),
                        Value = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dictionary");
        }
    }
}
