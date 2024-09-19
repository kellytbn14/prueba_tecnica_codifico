using SalesDatePrediction.Core.Exceptions;
using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Repositories;

namespace SalesDatePrediction.Core.UseCases.Employees
{
    public class GetEmployeeByIdUseCase
    {
        private readonly IEmployeeRepository employeeRepository;

        public GetEmployeeByIdUseCase(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<Employee> ExecuteAsync(int id)
        {
            var employee = await employeeRepository.FindAsync(id).ConfigureAwait(false);
            if (employee is null)
            {
                throw new DataNotFoundException("Employee does not exist");
            }
            return employee;
        }
    }
}
