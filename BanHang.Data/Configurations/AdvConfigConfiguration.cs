using BanHang.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BanHang.Data.Configurations
{
    public class AdvConfigConfiguration : IEntityTypeConfiguration<Adv>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Adv> builder)
        {
            builder.ToTable("Advs");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired(false).HasColumnType("nvarchar(max)");
            builder.Property(x => x.Type).HasDefaultValue(1);
            builder.Property(x => x.Image).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.Link).IsRequired(false).HasMaxLength(500);

            builder.Property(x => x.CreatedBy).IsRequired(false).HasColumnType("nvarchar(255)");

            builder.Property(x => x.CreatedDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.ModifierBy).IsRequired(false).HasColumnType("nvarchar(255)");
            builder.Property(x => x.ModifiedDate).IsRequired(false).HasColumnType("datetime");
        }
    }
}