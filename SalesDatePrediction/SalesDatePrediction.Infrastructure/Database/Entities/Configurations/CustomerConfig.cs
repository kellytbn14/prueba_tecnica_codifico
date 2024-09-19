using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Models;


namespace SalesDatePrediction.Infrastructure.Database.Entities.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", "Sales", b => b.ExcludeFromMigrations());

            builder.Property(e => e.CustomerId)
                .HasColumnName("custid");

            builder.Property(e => e.CompanyName)
                .HasColumnName("companyname");

            builder.Property(e => e.ContactName)
                .HasColumnName("contactname");

            builder.Property(e => e.ContactTitle)
                .HasColumnName("contacttitle");

            builder.Property(e => e.Address)
                .HasColumnName("address");

            builder.Property(e => e.City)
                .HasColumnName("city");

            builder.Property(e => e.Region)
                .HasColumnName("region");

            builder.Property(e => e.PostalCode)
                .HasColumnName("postalcode");

            builder.Property(e => e.Country)
                .HasColumnName("country");

            builder.Property(e => e.Phone)
                .HasColumnName("phone");

            builder.Property(e => e.Fax)
                .HasColumnName("fax");
        }
    }
}
