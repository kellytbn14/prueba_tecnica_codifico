using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Models;


namespace SalesDatePrediction.Infrastructure.Database.Entities.Configurations
{
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails", "Sales", b => b.ExcludeFromMigrations());

            builder.HasKey(e => new { e.OrderId, e.ProductId });

            builder.Property(e => e.OrderId)
                .HasColumnName("orderid");

            builder.Property(e => e.ProductId)
                .HasColumnName("productid");

            builder.Property(e => e.UnitPrice)
                .HasColumnName("unitprice");

            builder.Property(e => e.Qty)
                .HasColumnName("qty");

            builder.Property(e => e.Discount)
                .HasColumnName("discount");
        }
    }
}
