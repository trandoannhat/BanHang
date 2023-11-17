using BanHang.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanHang.Data.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Alias).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Description).IsRequired(false).HasColumnType("nvarchar(max)");

            builder.Property(x => x.Position).HasDefaultValue(1);
            builder.Property(x => x.SeoTitle).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.SeoDescription).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.SeoKeyword).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.Property(x => x.CreatedBy).IsRequired(false);

            builder.Property(x => x.CreatedDate).IsRequired(false).HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.ModifierBy).IsRequired(false);

            builder.Property(x => x.ModifiedDate).IsRequired(false);
        }
    }
}