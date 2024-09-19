using NSubstitute;
using SalesDatePrediction.Core.UseCases.Employees;
using SalesDatePrediction.Domain.Repositories;
using SalesDatePrediction.Test.Core.ModelsBuilder;

namespace SalesDatePrediction.Test.Core.UseCases.Employees
{
    public class GetEmployeeByIdUseCaseTest
    {
        private readonly IEmployeeRepository employeeRepository;

        public GetEmployeeByIdUseCaseTest()
        {
            employeeRepository = Substitute.For<IEmployeeRepository>();
        }

        public GetEmployeeByIdUseCase CreateNew() => new(employeeRepository);

        [Fact]
        public async Task ShouldReturnEmployee_WhenEmployeeExists()
        {
            // Arrange
            int id = 1;
            var employee = new EmployeeBuilder().BuildDefault();
            employeeRepository.FindAsync(id).Returns(employee);

            // Act
            var getEmployeeByIdUseCase = CreateNew();
            var result = await getEmployeeByIdUseCase.ExecuteAsync(id);

            // Assert
            Assert.NotNull(result);
        }
    }
}
