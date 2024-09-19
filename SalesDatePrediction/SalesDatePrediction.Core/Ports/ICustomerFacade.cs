using SalesDatePrediction.Core.Models;
using SalesDatePrediction.Domain.Models;

namespace SalesDatePrediction.Core.Ports
{
    public interface ICustomerFacade
    {
        public PageableList<NextPredictedOrderDate> GetNextPredictedOrderDates(string companyName, int page, int size, string sort);
    }
}
