using SalesDatePrediction.Core.Models;

namespace SalesDatePrediction.Core.Ports
{
    public interface IProductFacade
    {
        public Task<List<ProductResponse>> GetAllProducts();
    }
}
