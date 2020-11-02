namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBooking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ArrivalTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        ClientAccountId = c.Long(nullable: false),
                        ServiceId = c.Long(nullable: false),
                        RoomId = c.Int(nullable: false),
                        Message = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Booking");
        }
    }
}
