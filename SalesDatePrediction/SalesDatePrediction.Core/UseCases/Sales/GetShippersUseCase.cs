using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Repositories;

namespace SalesDatePrediction.Core.UseCases.Sales
{
    public class GetShippersUseCase
    {
        private readonly IShipperRepository shipperRepository;

        public GetShippersUseCase(IShipperRepository shipperRepository)
        {
            this.shipperRepository = shipperRepository;
        }

        public async Task<List<Shipper>> ExecuteAsync()
        {
            var shippers = await shipperRepository.GetAllAsync();
            return shippers.ToList();
        }
    }
}
