using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Models;


namespace SalesDatePrediction.Infrastructure.Database.Entities.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "Production", b => b.ExcludeFromMigrations());

            builder.Property(e => e.CategoryId)
                .HasColumnName("categoryid");

            builder.Property(e => e.CategoryName)
                .HasColumnName("categoryname");

            builder.Property(e => e.Description)
                .HasColumnName("description");
        }
    }
}
