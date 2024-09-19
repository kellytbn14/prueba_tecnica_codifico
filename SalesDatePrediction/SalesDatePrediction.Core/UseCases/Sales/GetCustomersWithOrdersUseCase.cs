using SalesDatePrediction.Core.Models;
using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Repositories;

namespace SalesDatePrediction.Core.UseCases.Sales
{
    public class GetCustomersWithOrdersUseCase
    {
        private readonly ICustomerRepository customerRepository;

        public GetCustomersWithOrdersUseCase(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public PageableList<NextPredictedOrderDate> ExecuteAsync(string companyName, int page, int size, string sort)
        {
            var customersPaged = customerRepository.GetAllCustomersWithOrders(companyName, page, size, sort);

            var nextPredictedOrderDatesList = customersPaged
                .Select(c =>
                {
                    var orderedOrders = c.Orders.OrderBy(o => o.OrderDate).ToList();

                    var ordersWithDaysDiff = orderedOrders
                        .Select((order, index) => new
                        {
                            Order = order,
                            DaysDiff = index == 0 ? (int?)null : (order.OrderDate - orderedOrders[index - 1].OrderDate).Days
                        }).ToList();

                    var validDaysDiffs = ordersWithDaysDiff
                        .Where(o => o.DaysDiff.HasValue)
                        .Select(o => o.DaysDiff.Value)
                        .ToList();
                    double averageDaysDiff = validDaysDiffs.Count != 0 ? validDaysDiffs.Average() : 0;

                    var lastOrderDate = orderedOrders.Count != 0 ? orderedOrders.Max(o => o.OrderDate) : (DateTime?)null;

                    // Calcular la fecha de la próxima orden predicha
                    DateTime? nextPredictedDate = lastOrderDate.HasValue && averageDaysDiff > 0
                        ? lastOrderDate.Value.AddDays(averageDaysDiff)
                        : (DateTime?)null;

                    return new NextPredictedOrderDate
                    {
                        CustomerId = c.CustomerId,
                        CustomerName = c.CompanyName,
                        LastOrderDate = lastOrderDate ?? DateTime.MinValue,
                        NextPredictedOrder = nextPredictedDate ?? DateTime.MinValue
                    };
                }).ToList();

            PageableList<NextPredictedOrderDate> nextPredictedOrderDatesResponse = new()
            {
                totalElements = customersPaged.TotalItemCount,
                page = customersPaged.PageNumber,
                size = customersPaged.PageSize,
                totalPages = customersPaged.PageCount,
                totalContent = customersPaged.Count,
                content = nextPredictedOrderDatesList
            };
            return nextPredictedOrderDatesResponse;
        }
    }
}
