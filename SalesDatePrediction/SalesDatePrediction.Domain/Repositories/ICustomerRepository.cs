
using PagedList;
using SalesDatePrediction.Domain.Models;

namespace SalesDatePrediction.Domain.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public IPagedList<Customer> GetAllCustomersWithOrders(string companyName, int page, int size, string sort);
    }
}
