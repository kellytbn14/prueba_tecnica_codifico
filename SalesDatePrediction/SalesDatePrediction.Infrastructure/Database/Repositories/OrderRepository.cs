using Azure;
using Microsoft.EntityFrameworkCore;
using PagedList;
using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Repositories;
using System.Drawing;
using System.Linq.Dynamic.Core;

namespace SalesDatePrediction.Infrastructure.Database.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly SalesDatesPredictionContext _context;

        public OrderRepository(SalesDatesPredictionContext context) : base(context)
        {
            _context = context;
        }

        public IPagedList<Order> GetOrdersByCustomerPaged(int CustomerId, int page, int size, string sort)
        {
            var query = _context.Set<Order>()
                .Where(i => i.CustumerId == CustomerId)
                .OrderBy(sort);

            IPagedList<Order> orders = query.ToPagedList(page, size);
            return orders;
        }

        public async Task<List<NextPredictedOrderDate>> GetPredictNextOrderDatesSP()
        {
            var predictedOrders = await _context.PredictNextOrderDates
                .FromSqlRaw("EXEC dbo.PredictNextOrderDate")
                .ToListAsync();

            return predictedOrders;
        }
    }
}
