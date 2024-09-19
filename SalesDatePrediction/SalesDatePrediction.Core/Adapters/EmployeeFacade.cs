using AutoMapper;
using SalesDatePrediction.Core.Models;
using SalesDatePrediction.Core.Ports;
using SalesDatePrediction.Core.UseCases.Employees;
using SalesDatePrediction.Domain.Models;

namespace SalesDatePrediction.Core.Adapters
{
    public class EmployeeFacade : IEmployeeFacade
    {
        private readonly GetEmployeesUseCase getEmployeesUseCase;
        private readonly IMapper _mapper;

        public EmployeeFacade(GetEmployeesUseCase getEmployeesUseCase, IMapper mapper)
        {
            this.getEmployeesUseCase = getEmployeesUseCase;
            _mapper = mapper;
        }

        public async Task<List<EmployeeResponse>> GetAllEmployees()
        {
            List<Employee> employees = await getEmployeesUseCase.ExecuteAsync();
            return _mapper.Map<List<EmployeeResponse>>(employees);
        }
    }
}
