using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Core.Ports;


namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/shippers")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperFacade _facade;

        public ShipperController(IShipperFacade facade)
        {
            _facade = facade;
        }

        [HttpGet("get-shippers")]
        public async Task<IActionResult> GetAllShippers()
        {
            var result = await _facade.GetAllShippers();
            return Ok(result);
        }
    }
}
