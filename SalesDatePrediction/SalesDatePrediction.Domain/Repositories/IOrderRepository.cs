using PagedList;
using SalesDatePrediction.Domain.Models;

namespace SalesDatePrediction.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        public IPagedList<Order> GetOrdersByCustomerPaged(int CustomerId, int page, int size, string sort);
        public Task<List<NextPredictedOrderDate>> GetPredictNextOrderDatesSP();
    }
}
