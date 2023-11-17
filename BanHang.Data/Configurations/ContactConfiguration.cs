using BanHang.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanHang.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(300);

            builder.Property(x => x.Website).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.Email).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.Message).IsRequired(false).HasMaxLength(500);

            builder.Property(x => x.IsRead).IsRequired(false).HasDefaultValue(true);

            builder.Property(x => x.CreatedBy).IsRequired(false);

            builder.Property(x => x.CreatedDate).IsRequired(false).HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.ModifierBy).IsRequired(false);

            builder.Property(x => x.ModifiedDate).IsRequired(false);
        }
    }
}