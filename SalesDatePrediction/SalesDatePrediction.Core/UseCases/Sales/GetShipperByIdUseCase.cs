using SalesDatePrediction.Core.Exceptions;
using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Repositories;

namespace SalesDatePrediction.Core.UseCases.Sales
{
    public class GetShipperByIdUseCase
    {
        private readonly IShipperRepository shipperRepository;

        public GetShipperByIdUseCase(IShipperRepository shipperRepository)
        {
            this.shipperRepository = shipperRepository;
        }

        public async Task<Shipper> ExecuteAsync(int id)
        {
            var shipper = await shipperRepository.FindAsync(id).ConfigureAwait(false);
            if (shipper is null)
            {
                throw new DataNotFoundException("Shipper does not exist");
            }
            return shipper;
        }
    }
}
