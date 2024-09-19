using SalesDatePrediction.Core.Exceptions;
using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Repositories;

namespace SalesDatePrediction.Core.UseCases.Production
{
    public class GetProductByIdUseCase
    {
        private readonly IProductRepository productRepository;

        public GetProductByIdUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> ExecuteAsync(int id)
        {
            var product = await productRepository.FindAsync(id).ConfigureAwait(false);
            if (product is null)
            {
                throw new DataNotFoundException("Product does not exist");
            }
            return product;
        }
    }
}
