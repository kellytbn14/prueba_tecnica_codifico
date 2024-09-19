using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Models;


namespace SalesDatePrediction.Infrastructure.Database.Entities.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "Sales", b => b.ExcludeFromMigrations());

            builder.Property(e => e.OrderId)
                .HasColumnName("orderid");

            builder.Property(e => e.CustumerId)
                .HasColumnName("custid");

            builder.Property(e => e.EmployeeId)
                .HasColumnName("empid");

            builder.Property(e => e.OrderDate)
                .HasColumnName("orderdate");

            builder.Property(e => e.RequiredDate)
                .HasColumnName("requireddate");

            builder.Property(e => e.ShippedDate)
                .HasColumnName("shippeddate");

            builder.Property(e => e.ShipperId)
                .HasColumnName("shipperid");

            builder.Property(e => e.Freight)
                .HasColumnName("freight");

            builder.Property(e => e.ShipName)
                .HasColumnName("shipname");

            builder.Property(e => e.ShipAddress)
                .HasColumnName("shipaddress");

            builder.Property(e => e.ShipCity)
                .HasColumnName("shipcity");

            builder.Property(e => e.ShipRegion)
                .HasColumnName("shipregion");

            builder.Property(e => e.ShipPostalCode)
                .HasColumnName("shippostalcode");

            builder.Property(e => e.ShipCountry)
                .HasColumnName("shipcountry");

            builder.HasOne(e => e.Customer)
               .WithMany(c => c.Orders)
               .HasForeignKey(e => e.CustumerId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
