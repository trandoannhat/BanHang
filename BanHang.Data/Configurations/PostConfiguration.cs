using BanHang.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanHang.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Alias).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(4000);
            builder.Property(x => x.Detail).IsRequired(false).HasMaxLength(4000);
            builder.Property(x => x.Image).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.SeoTitle).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.SeoDescription).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.SeoKeyword).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreatedBy).IsRequired(false);
            builder.Property(x => x.CreatedDate).IsRequired(false).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.ModifierBy).IsRequired(false);
            builder.Property(x => x.ModifiedDate).IsRequired(false);

            builder.HasOne(x => x.Category).WithMany(x => x.Posts).HasForeignKey(x => x.CategoryID);
        }
    }
}