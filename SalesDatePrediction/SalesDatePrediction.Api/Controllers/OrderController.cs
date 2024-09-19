using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Core.Models;
using SalesDatePrediction.Core.Ports;


namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderFacade _facade;

        public OrderController(IOrderFacade facade)
        {
            _facade = facade;
        }

        [HttpGet("get-customer-orders/{customerId}")]
        public async Task<IActionResult> GetOrdersByCustomerPaged(
            [FromRoute] int customerId,
            [FromQuery] int? page = null,
            [FromQuery] int? size = null,
            [FromQuery] string? sort = null)
        {
            if (page == null || page < 1) page = 1;
            size ??= 10;
            sort ??= "OrderId asc";

            var result = await _facade.GetOrdersByCustomerPaged(customerId, page.Value, size.Value, sort);
            return Ok(result);
        }

        [HttpPost("create-order-with-details")]
        public async Task<IActionResult> CreateOrderWithDetails([FromBody] CreateOrderRequest request)
        {
            var result = await _facade.CreateOrderWithDetails(request);
            return Created("", result);
        }
    }
}
