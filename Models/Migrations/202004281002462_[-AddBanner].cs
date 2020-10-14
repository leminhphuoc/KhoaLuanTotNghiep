namespace Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddBanner : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banner",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Location = c.String(maxLength: 200),
                    Image = c.String(maxLength: 500),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Banner");
        }
    }
}
