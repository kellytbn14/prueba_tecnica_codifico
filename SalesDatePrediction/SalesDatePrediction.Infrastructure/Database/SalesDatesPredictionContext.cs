using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesDatePrediction.Domain.Models;

namespace SalesDatePrediction.Infrastructure.Database
{
    public class SalesDatesPredictionContext : DbContext
    {
        private readonly string _schema;
        public DbSet<NextPredictedOrderDate> PredictNextOrderDates { get; set; }

        public SalesDatesPredictionContext(IConfiguration configuration, DbContextOptions<SalesDatesPredictionContext> dbContextOptions) : base(dbContextOptions)
        {
            _schema = configuration.GetConnectionString("SchemaName");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.HasDefaultSchema(_schema);

            modelBuilder.Entity<NextPredictedOrderDate>().HasNoKey();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SalesDatesPredictionContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
