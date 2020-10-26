namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCliendAcctountAndMembership : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientAccount",
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
            
            CreateTable(
                "dbo.District",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GenderCustomer",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaritalStatusCustomer",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Membership",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OccupationCustomer",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        DistrictId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TitleCustomer",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TitleCustomer");
            DropTable("dbo.Region");
            DropTable("dbo.OccupationCustomer");
            DropTable("dbo.Membership");
            DropTable("dbo.MaritalStatusCustomer");
            DropTable("dbo.GenderCustomer");
            DropTable("dbo.District");
            DropTable("dbo.ClientAccount");
        }
    }
}
