using BanHang.Data.Configurations;
using BanHang.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BanHang.Data.EF
{
    public class BanHangDbContext : DbContext//IdentityDbContext<AppUser>
    {
        public BanHangDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Bỏ tiền tố AspNet của các bảng: mặc định
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    var tableName = entityType.GetTableName();
            //    if (tableName.StartsWith("AspNet"))
            //    {
            //        entityType.SetTableName(tableName.Substring(6));
            //    }
            //}
            //Configure using Fluent API

            modelBuilder.ApplyConfiguration(new AdvConfigConfiguration());
            //modelBuilder.ApplyConfiguration(new AppUserConfigConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            modelBuilder.ApplyConfiguration(new SubscribeConfiguration());
            modelBuilder.ApplyConfiguration(new SystemSettingConfiguration());

            //modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("AppUserClaims");
            //// những entity có HasKey là do lúc migrate báo lỗi yêu cầu thêm key
            //modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });

            //modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            //modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("AppRoleClaims");

            //modelBuilder.Entity<IdentityUserToken<string>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            //Data seeding

            //modelBuilder.Seed();

            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Adv> Advs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }

        public DbSet<SystemSetting> SystemSettings { get; set; }
    }
}