using SalesDatePrediction.Core.Models;
using SalesDatePrediction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Core.Ports
{
    public interface IEmployeeFacade
    {
        public Task<List<EmployeeResponse>> GetAllEmployees();
    }
}
