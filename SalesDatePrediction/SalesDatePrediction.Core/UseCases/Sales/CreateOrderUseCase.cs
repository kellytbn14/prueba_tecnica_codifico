using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Repositories;

namespace SalesDatePrediction.Core.UseCases.Sales
{
    public class CreateOrderUseCase
    {
        private readonly IOrderRepository orderRepository;

        public CreateOrderUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<Order> ExecuteAsync(Order order)
        {
            return await orderRepository.AddAsync(order);
        }
    }
}
