using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Repositories;

namespace SalesDatePrediction.Core.UseCases.Employees
{
    public class GetEmployeesUseCase
    {
        private readonly IEmployeeRepository employeeRepository;

        public GetEmployeesUseCase(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> ExecuteAsync()
        {
            var employees = await employeeRepository.GetAllAsync();
            return employees.ToList();
        }
    }
}
