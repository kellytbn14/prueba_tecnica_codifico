using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Models;


namespace SalesDatePrediction.Infrastructure.Database.Entities.Configurations
{
    public class ShipperConfig : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.ToTable("Shippers", "Sales", b => b.ExcludeFromMigrations());

            builder.Property(e => e.ShipperId)
                .HasColumnName("shipperid");

            builder.Property(e => e.CompanyName)
                .HasColumnName("companyname");

            builder.Property(e => e.Phone)
                .HasColumnName("phone");
        }
    }
}
