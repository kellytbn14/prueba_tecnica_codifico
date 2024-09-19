using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Models;


namespace SalesDatePrediction.Infrastructure.Database.Entities.Configurations
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees", "HR", b => b.ExcludeFromMigrations());

            builder.Property(e => e.EmployeeId)
                .HasColumnName("empid");

            builder.Property(e => e.LastName)
                .HasColumnName("lastname");

            builder.Property(e => e.FirstName)
                .HasColumnName("firstname");

            builder.Property(e => e.Title)
                .HasColumnName("title");

            builder.Property(e => e.TitleOfCourtesy)
                .HasColumnName("titleofcourtesy");

            builder.Property(e => e.Birthdate)
                .HasColumnName("birthdate");

            builder.Property(e => e.Hiredate)
                .HasColumnName("hiredate");

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

            builder.Property(e => e.MGrid)
                .HasColumnName("mgrid");
        }
    }
}
