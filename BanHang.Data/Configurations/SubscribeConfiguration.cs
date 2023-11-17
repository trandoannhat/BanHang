using BanHang.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHang.Data.Configurations
{
    public class SubscribeConfiguration : IEntityTypeConfiguration<Subscribe>
    {
        public void Configure(EntityTypeBuilder<Subscribe> builder)
        {
            builder.ToTable("Subscribes");
            builder.HasKey(x => x.Id);
            builder.Property(o => o.Id).UseIdentityColumn();
            builder.Property(x => x.Email).IsRequired(false).HasMaxLength(300);
            builder.Property(x => x.CreatedDate).IsRequired(false).HasDefaultValueSql("GETDATE()");
        }
    }
}