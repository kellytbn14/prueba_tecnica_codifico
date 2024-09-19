using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Repositories;

namespace SalesDatePrediction.Core.UseCases.Sales
{
    public class GetNextPredictedOrderDatesUseCase
    {
        private readonly IOrderRepository orderRepository;

        public GetNextPredictedOrderDatesUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<List<NextPredictedOrderDate>> ExecuteAsync()
        {
            return await orderRepository.GetPredictNextOrderDatesSP();
        }
    }
}
