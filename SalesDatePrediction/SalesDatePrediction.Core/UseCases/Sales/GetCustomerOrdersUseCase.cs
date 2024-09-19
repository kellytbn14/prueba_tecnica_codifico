using AutoMapper;
using PagedList;
using SalesDatePrediction.Core.Models;
using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Repositories;

namespace SalesDatePrediction.Core.UseCases.Sales
{
    public class GetCustomerOrdersUseCase
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper _mapper;

        public GetCustomerOrdersUseCase(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            _mapper = mapper;
        }

        public PageableList<CustomerOrderResponse> ExecuteAsync(int CustomerId, int page, int size, string sort)
        {
            IPagedList<Order> ordersPaged = orderRepository.GetOrdersByCustomerPaged(CustomerId, page, size, sort);

            PageableList<CustomerOrderResponse> customerOrdersResponse = new()
            {
                totalElements = ordersPaged.TotalItemCount,
                page = ordersPaged.PageNumber,
                size = ordersPaged.PageSize,
                totalPages = ordersPaged.PageCount,
                totalContent = ordersPaged.Count,
                content = ordersPaged.Select(i => _mapper.Map<CustomerOrderResponse>(i)).ToList()
            };
            return customerOrdersResponse;
        }
    }
}
