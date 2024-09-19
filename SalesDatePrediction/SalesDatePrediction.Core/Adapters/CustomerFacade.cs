using AutoMapper;
using SalesDatePrediction.Core.Models;
using SalesDatePrediction.Core.Ports;
using SalesDatePrediction.Core.UseCases.Sales;
using SalesDatePrediction.Domain.Models;

namespace SalesDatePrediction.Core.Adapters
{
    public class CustomerFacade : ICustomerFacade
    {
        private readonly GetCustomersWithOrdersUseCase customersWithOrdersUseCase;
        private readonly IMapper _mapper;

        public CustomerFacade(GetCustomersWithOrdersUseCase customersWithOrdersUseCase, IMapper mapper)
        {
            this.customersWithOrdersUseCase = customersWithOrdersUseCase;
            _mapper = mapper;
        }

        public PageableList<NextPredictedOrderDate> GetNextPredictedOrderDates(string companyName, int page, int size, string sort)
        {
            return customersWithOrdersUseCase.ExecuteAsync(companyName, page, size, sort);
        }
    }
}
