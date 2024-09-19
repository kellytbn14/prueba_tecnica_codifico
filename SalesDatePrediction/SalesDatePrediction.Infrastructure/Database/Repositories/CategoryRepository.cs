using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Repositories;

namespace SalesDatePrediction.Infrastructure.Database.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(SalesDatesPredictionContext context) : base(context)
        {

        }
    }
}
