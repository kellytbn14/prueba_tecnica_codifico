using AutoMapper;
using SalesDatePrediction.Core.Models;
using SalesDatePrediction.Core.Ports;
using SalesDatePrediction.Core.UseCases.Production;
using SalesDatePrediction.Domain.Models;

namespace SalesDatePrediction.Core.Adapters
{
    public class ProductFacade : IProductFacade
    {
        private readonly GetProductsUseCase getProductsUseCase;
        private readonly IMapper _mapper;

        public ProductFacade(GetProductsUseCase getProductsUseCase, IMapper mapper)
        {
            this.getProductsUseCase = getProductsUseCase;
            _mapper = mapper;
        }

        public async Task<List<ProductResponse>> GetAllProducts()
        {
            List<Product> products = await getProductsUseCase.ExecuteAsync();
            return _mapper.Map<List<ProductResponse>>(products);
        }
    }
}
