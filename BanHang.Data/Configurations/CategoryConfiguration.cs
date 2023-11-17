using BanHang.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanHang.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categoris");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title).IsRequired(true).HasMaxLength(300);
            builder.Property(x => x.Icon).IsRequired(false).HasMaxLength(300);
            builder.Property(x => x.SeoTitle).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.SeoDescription).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.SeoKeyword).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.CreatedBy).IsRequired(false);

            builder.Property(x => x.CreatedDate).IsRequired(false).HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.ModifierBy).IsRequired(false);

            builder.Property(x => x.ModifiedDate).IsRequired(false);
        }
    }
}