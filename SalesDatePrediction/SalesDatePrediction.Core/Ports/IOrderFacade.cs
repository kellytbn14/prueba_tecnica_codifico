using SalesDatePrediction.Core.Models;
using SalesDatePrediction.Domain.Models;

namespace SalesDatePrediction.Core.Ports
{
    public interface IOrderFacade
    {
        public Task<PageableList<CustomerOrderResponse>> GetOrdersByCustomerPaged(int CustomerId, int page, int size, string sort);
        public Task<OrderDto> CreateOrderWithDetails(CreateOrderRequest request);
    }
}
