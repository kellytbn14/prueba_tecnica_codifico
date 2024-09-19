using Microsoft.EntityFrameworkCore;
using PagedList;
using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Repositories;
using System.Linq.Dynamic.Core;

namespace SalesDatePrediction.Infrastructure.Database.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly SalesDatesPredictionContext _context;

        public CustomerRepository(SalesDatesPredictionContext context) : base(context)
        {
            _context = context;
        }

        public IPagedList<Customer> GetAllCustomersWithOrders(string companyName, int page, int size, string sort)
        {
            var query = _context.Set<Customer>()
                .Include(c => c.Orders)
                .Where(c => companyName == null || c.CompanyName.Contains(companyName))
                .OrderBy(sort);

            IPagedList<Customer> orders = query.ToPagedList(page, size);
            return orders;
        }

    }
}
