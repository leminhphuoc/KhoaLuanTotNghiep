namespace Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddSEOTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SEO",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Name = c.String(maxLength: 100),
                    MetaTitle = c.String(maxLength: 500),
                    MetaKeyWord = c.String(maxLength: 500),
                    MetaDescription = c.String(maxLength: 500),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.SEO");
        }
    }
}
