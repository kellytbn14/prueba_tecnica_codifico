using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Repositories;

namespace SalesDatePrediction.Infrastructure.Database.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly SalesDatesPredictionContext _context;

        public EmployeeRepository(SalesDatesPredictionContext context) : base(context)
        {
            _context = context;
        }
    }
}
