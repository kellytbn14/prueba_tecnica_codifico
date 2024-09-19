using NSubstitute;
using SalesDatePrediction.Core.UseCases.Employees;
using SalesDatePrediction.Domain.Repositories;
using SalesDatePrediction.Test.Core.ModelsBuilder;

namespace SalesDatePrediction.Test.Core.UseCases.Employees
{
    public class GetEmployeesUseCaseTest
    {
        private readonly IEmployeeRepository employeeRepository;

        public GetEmployeesUseCaseTest()
        {
            employeeRepository = Substitute.For<IEmployeeRepository>();
        }

        public GetEmployeesUseCase CreateNew() => new(employeeRepository);

        [Fact]
        public async Task ShouldReturnListOfEmployees_WhenEmployeesExist()
        {
            // Arrange
            var employees = new EmployeeBuilder().BuildDefaultList();
            employeeRepository.GetAllAsync().Returns(employees);

            // Act
            var getEmployeesUseCase = CreateNew();
            var result = await getEmployeesUseCase.ExecuteAsync();

            // Assert
            Assert.NotNull(result);
        }
    }
}
