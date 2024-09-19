using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Repositories;

namespace SalesDatePrediction.Core.UseCases.Production
{
    public class GetProductsUseCase
    {
        private readonly IProductRepository productRepository;

        public GetProductsUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<List<Product>> ExecuteAsync()
        {
            var products = await productRepository.GetAllAsync();
            return products.ToList();
        }
    }
}
