namespace Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FonNatureDbContext : DbContext
    {
        public FonNatureDbContext()
            : base("name=FonNatureDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FonNatureDbContext, Migrations.Configuration>());
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<AccountAdmin> AccountAdmins { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<ContentCategory> ContentCategories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<FooterCategory> FooterCategories { get; set; }
        public virtual DbSet<IPAddress> IPAddresses { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<UsefulInformation> UsefulInformations { get; set; }
        public virtual DbSet<VisitorByTime> VisitorByTimes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderInformation> OrderInformations { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<SEO> SEOs { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.promotionPrice)
                .HasPrecision(18, 0);
        }
    }
}
