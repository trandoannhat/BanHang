using Microsoft.EntityFrameworkCore;

namespace BanHang.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // tạo data cho user mặc định
            // any guid
            //var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            //var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");

            //modelBuilder.Entity<AppRole>().HasData(
            //new AppRole
            //{
            //    Id = roleId,
            //    Name = "admin",
            //    NormalizedName = "admin",
            //    Description = "Administrator role"
            //}
            //);
            //var hasher = new PasswordHasher<AppUser>();
            //modelBuilder.Entity<AppUser>().HasData(new AppUser
            //{
            //    Id = adminId,
            //    UserName = "admin",
            //    NormalizedUserName = "ADMIN",
            //    Email = "doannhatit@gmail.com",
            //    PhoneNumber = "0123456789",
            //    Address = "TP.HCM",
            //    NormalizedEmail = "DOANNHATIT@GMAIL.COM",
            //    EmailConfirmed = true,
            //    PasswordHash = hasher.HashPassword(null, "080390"),
            //    SecurityStamp = string.Empty,
            //    FullName = "TDN Dev",
            //});
            //// gán role admin và admin user
            //modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            //{
            //    RoleId = roleId,
            //    UserId = adminId
            //});
        }
    }
}