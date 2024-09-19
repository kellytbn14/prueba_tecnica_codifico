using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Models;


namespace SalesDatePrediction.Infrastructure.Database.Entities.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "Production", b => b.ExcludeFromMigrations());

            builder.Property(e => e.ProductId)
                .HasColumnName("productid");

            builder.Property(e => e.ProductName)
                .HasColumnName("productname");

            builder.Property(e => e.SupplierId)
                .HasColumnName("supplierid");

            builder.Property(e => e.CategoryId)
                .HasColumnName("categoryid");

            builder.Property(e => e.UnitPrice)
                .HasColumnName("unitprice");

            builder.Property(e => e.Discontinued)
                .HasColumnName("discontinued");
        }
    }
}
