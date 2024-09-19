using NSubstitute;
using SalesDatePrediction.Core.UseCases.Production;
using SalesDatePrediction.Domain.Repositories;
using SalesDatePrediction.Test.Core.ModelsBuilder;

namespace SalesDatePrediction.Test.Core.UseCases.Production
{
    public class GetProductsUseCaseTest
    {
        private readonly IProductRepository productRepository;

        public GetProductsUseCaseTest()
        {
            productRepository = Substitute.For<IProductRepository>();
        }

        public GetProductsUseCase CreateNew() => new(productRepository);

        [Fact]
        public async Task ShouldReturnListOfProducts_WhenProductsExist()
        {
            // Arrange
            var products = new ProductBuilder().BuildDefaultList();
            productRepository.GetAllAsync().Returns(products);

            // Act
            var getProductsUseCase = CreateNew();
            var result = await getProductsUseCase.ExecuteAsync();

            // Assert
            Assert.NotNull(result);
        }
    }
}
