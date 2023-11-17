using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BanHang.Data.EF
{
    public class BanHangDbContextFactory : IDesignTimeDbContextFactory<BanHangDbContext>
    {
        public BanHangDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("BanHangConnection");

            var optionsBuilder = new DbContextOptionsBuilder<BanHangDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new BanHangDbContext(optionsBuilder.Options);
        }
    }
}