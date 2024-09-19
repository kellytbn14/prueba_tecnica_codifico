using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Core.Ports;


namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerFacade _facade;

        public CustomerController(ICustomerFacade facade)
        {
            _facade = facade;
        }

        [HttpGet("get-next-predicted-order-dates")]
        public IActionResult GetNextPredictedOrderDates(
            [FromQuery] string? companyName = null,
            [FromQuery] int? page = null,
            [FromQuery] int? size = null,
            [FromQuery] string? sort = null)
        {
            if (page == null || page < 1) page = 1;
            size ??= 10;
            sort ??= "CustomerId asc";

            var result = _facade.GetNextPredictedOrderDates(companyName, page.Value, size.Value, sort);
            return Ok(result);
        }
    }
}
