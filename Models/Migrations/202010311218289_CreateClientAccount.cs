namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateClientAccount : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CustomerAccount");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerAccount",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50),
                        MobilePhone = c.String(nullable: false, maxLength: 20),
                        PassWord = c.String(nullable: false, maxLength: 1000),
                        TitleId = c.Long(nullable: false),
                        NickName = c.String(maxLength: 100),
                        MaritalStatusId = c.Long(nullable: false),
                        AgeRangeId = c.Long(nullable: false),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Birth = c.DateTime(nullable: false),
                        GenderId = c.Long(nullable: false),
                        RegionId = c.Long(nullable: false),
                        OccupationId = c.Long(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
