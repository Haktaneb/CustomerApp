using CustomerApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerApp.DAL.Mappings
{
    public class DeviceMapping : IEntityTypeConfiguration<DeviceEntity>
    {
        public void Configure(EntityTypeBuilder<DeviceEntity> builder)
        {
            builder.ToTable("DefinedMobilDevices");
            builder.Property(d => d.Id).HasColumnName("DeviceId");
            builder.Property(d => d.Status).HasColumnName("Status");
            builder.Property(d => d.Description).HasColumnName("Description");          
        }
    }
}
