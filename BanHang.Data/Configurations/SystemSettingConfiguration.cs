using BanHang.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanHang.Data.Configurations
{
    public class SystemSettingConfiguration : IEntityTypeConfiguration<SystemSetting>
    {
        public void Configure(EntityTypeBuilder<SystemSetting> builder)
        {
            builder.ToTable("SystemSettings");
            builder.HasKey(x => x.SettingKey);
            builder.Property(x => x.SettingValue).IsRequired(false).HasMaxLength(4000);
            builder.Property(x => x.SettingDescription).IsRequired(false).HasMaxLength(4000);
        }
    }
}