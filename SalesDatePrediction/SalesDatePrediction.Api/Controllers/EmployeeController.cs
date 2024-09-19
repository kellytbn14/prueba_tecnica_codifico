using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Core.Ports;


namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeFacade _facade;

        public EmployeeController(IEmployeeFacade facade)
        {
            _facade = facade;
        }

        [HttpGet("get-employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _facade.GetAllEmployees();
            return Ok(result);
        }
    }
}
