using NSubstitute;
using SalesDatePrediction.Core.UseCases.Employees;
using SalesDatePrediction.Core.UseCases.Production;
using SalesDatePrediction.Domain.Repositories;
using SalesDatePrediction.Test.Core.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Test.Core.UseCases.Production
{
    public class GetProductByIdUseCaseTest
    {
        private readonly IProductRepository productRepository;

        public GetProductByIdUseCaseTest()
        {
            productRepository = Substitute.For<IProductRepository>();
        }

        public GetProductByIdUseCase CreateNew() => new(productRepository);

        [Fact]
        public async Task ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            int id = 1;
            var product = new ProductBuilder().BuildDefault();
            productRepository.FindAsync(id).Returns(product);

            // Act
            var getProductByIdUseCase = CreateNew();
            var result = await getProductByIdUseCase.ExecuteAsync(id);

            // Assert
            Assert.NotNull(result);
        }
    }
}
