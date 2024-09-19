using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Core.Ports;


namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductFacade _facade;

        public ProductController(IProductFacade facade)
        {
            _facade = facade;
        }

        [HttpGet("get-products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _facade.GetAllProducts();
            return Ok(result);
        }
    }
}
