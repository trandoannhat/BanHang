using BanHang.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanHang.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Alias).IsRequired().HasMaxLength(500);

            builder.Property(x => x.ProductCode).IsRequired(false).HasMaxLength(150);

            builder.Property(x => x.Description).IsRequired(false).HasColumnType("nvarchar(500)");
            builder.Property(x => x.Detail).IsRequired(false).HasColumnType("nvarchar(max)");

            builder.Property(x => x.Image).IsRequired(false).HasMaxLength(300);
            builder.Property(x => x.Price).HasDefaultValue(0);
            builder.Property(x => x.PriceSale).HasDefaultValue(0);
            builder.Property(x => x.Quantity).HasDefaultValue(0);
            builder.Property(x => x.IsHome).HasDefaultValue(false);
            builder.Property(x => x.IsSale).HasDefaultValue(false);
            builder.Property(x => x.IsFeature).HasDefaultValue(false);
            builder.Property(x => x.IsHot).HasDefaultValue(false);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.SeoTitle).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.SeoDescription).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.SeoKeyword).IsRequired(false).HasMaxLength(500);

            builder.HasOne(x => x.ProductCategory).WithMany(x => x.Products).HasForeignKey(x => x.ProductCategoryID);

            builder.Property(x => x.CreatedBy).IsRequired(false);
            builder.Property(x => x.CreatedDate).IsRequired(false).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.ModifierBy).IsRequired(false);
            builder.Property(x => x.ModifiedDate).IsRequired(false);
        }
    }
}