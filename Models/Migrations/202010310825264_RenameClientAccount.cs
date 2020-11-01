namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameClientAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerAccount", "Email", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.CustomerAccount", "MobilePhone", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.CustomerAccount", "TitleId", c => c.Long(nullable: false));
            AddColumn("dbo.CustomerAccount", "NickName", c => c.String(maxLength: 100));
            AddColumn("dbo.CustomerAccount", "MaritalStatusId", c => c.Long(nullable: false));
            AddColumn("dbo.CustomerAccount", "AgeRangeId", c => c.Long(nullable: false));
            AddColumn("dbo.CustomerAccount", "FirstName", c => c.String(maxLength: 100));
            AddColumn("dbo.CustomerAccount", "LastName", c => c.String(maxLength: 100));
            AddColumn("dbo.CustomerAccount", "Birth", c => c.DateTime(nullable: false));
            AddColumn("dbo.CustomerAccount", "GenderId", c => c.Long(nullable: false));
            AddColumn("dbo.CustomerAccount", "RegionId", c => c.Long(nullable: false));
            AddColumn("dbo.CustomerAccount", "OccupationId", c => c.Long(nullable: false));
            AlterColumn("dbo.CustomerAccount", "PassWord", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.CustomerAccount", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.CustomerAccount", "userName");
            DropColumn("dbo.CustomerAccount", "type");
            DropTable("dbo.ClientAccount");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.CustomerAccount", "IdCustomer", c => c.Long());
            AddColumn("dbo.CustomerAccount", "type", c => c.Boolean());
            AddColumn("dbo.CustomerAccount", "userName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.CustomerAccount", "Status", c => c.Boolean());
            AlterColumn("dbo.CustomerAccount", "PassWord", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.CustomerAccount", "OccupationId");
            DropColumn("dbo.CustomerAccount", "RegionId");
            DropColumn("dbo.CustomerAccount", "GenderId");
            DropColumn("dbo.CustomerAccount", "Birth");
            DropColumn("dbo.CustomerAccount", "LastName");
            DropColumn("dbo.CustomerAccount", "FirstName");
            DropColumn("dbo.CustomerAccount", "AgeRangeId");
            DropColumn("dbo.CustomerAccount", "MaritalStatusId");
            DropColumn("dbo.CustomerAccount", "NickName");
            DropColumn("dbo.CustomerAccount", "TitleId");
            DropColumn("dbo.CustomerAccount", "MobilePhone");
            DropColumn("dbo.CustomerAccount", "Email");
        }
    }
}
