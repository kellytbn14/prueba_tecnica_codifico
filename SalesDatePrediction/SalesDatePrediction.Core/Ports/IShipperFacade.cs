using SalesDatePrediction.Core.Models;

namespace SalesDatePrediction.Core.Ports
{
    public interface IShipperFacade
    {
        public Task<List<ShipperResponse>> GetAllShippers();
    }
}
