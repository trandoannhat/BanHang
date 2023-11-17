using BanHang.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanHang.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn();

            builder.Property(x => x.Code).IsRequired().HasMaxLength(150);
            builder.Property(x => x.CustomerName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(500);
            builder.Property(x => x.TotalAmount).HasDefaultValue(0);

            builder.Property(x => x.Quantity).HasDefaultValue(0);

            builder.Property(x => x.CreatedBy).IsRequired(false);
            builder.Property(x => x.CreatedDate).IsRequired(false).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.ModifierBy).IsRequired(false);
            builder.Property(x => x.ModifiedDate).IsRequired(false);
        }
    }
}