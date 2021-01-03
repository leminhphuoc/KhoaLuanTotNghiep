namespace Models.Entity
{
    using System.Data.Entity;

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
        public virtual DbSet<Dictionary> Dictionaries { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Benefit> Benefits { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<GenderCustomer> GenderCustomers { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<MaritalStatusCustomer> MaritalStatusCustomers { get; set; }
        public virtual DbSet<OccupationCustomer> OccupationCustomers { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<TitleCustomer> TitleCustomers { get; set; }
        public virtual DbSet<ClientAccount> ClientAccounts { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<CouponCode> CouponCodes { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.promotionPrice)
                .HasPrecision(18, 0);
        }
    }
}
