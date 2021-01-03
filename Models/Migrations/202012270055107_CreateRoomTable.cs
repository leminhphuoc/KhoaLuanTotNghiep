namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRoomTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(maxLength: 100),
                        Code = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Room");
        }
    }
}
