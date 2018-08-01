namespace CustomerApp.DAL.Mappings
{
    using CustomerApp.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CustomerMapping : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.ToTable("CUSTTABLE");
            builder.Property(c => c.Id).HasColumnName("ACCOUNTNUM");
            builder.Property(c => c.Name).HasColumnName("NAME");
            builder.Property(c => c.Address).HasColumnName("ADDRESS");
            builder.Property(c => c.Phone).HasColumnName("PHONE");
            builder.Property(c => c.Email).HasColumnName("EMAIL");
            builder.Property(c => c.DataAreaId).HasColumnName("DATAAREAID");
            builder.Property(c => c.RecId).HasColumnName("RECID").IsRequired();
        }
    }
}