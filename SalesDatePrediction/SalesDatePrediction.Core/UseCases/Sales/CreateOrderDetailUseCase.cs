using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Repositories;

namespace SalesDatePrediction.Core.UseCases.Sales
{
    public class CreateOrderDetailUseCase
    {
        private readonly IOrderDetailRepository orderDetailRepository;

        public CreateOrderDetailUseCase(IOrderDetailRepository orderDetailRepository)
        {
            this.orderDetailRepository = orderDetailRepository;
        }

        public async Task<OrderDetail> ExecuteAsync(OrderDetail orderDetail)
        {
            return await orderDetailRepository.AddAsync(orderDetail);
        }
    }
}
