using AutoMapper;
using SalesDatePrediction.Core.Models;
using SalesDatePrediction.Core.Ports;
using SalesDatePrediction.Core.UseCases.Sales;
using SalesDatePrediction.Domain.Models;

namespace SalesDatePrediction.Core.Adapters
{
    public class ShipperFacade : IShipperFacade
    {
        private readonly GetShippersUseCase getShippersUseCase;
        private readonly IMapper _mapper;

        public ShipperFacade(GetShippersUseCase getShippersUseCase, IMapper mapper)
        {
            this.getShippersUseCase = getShippersUseCase;
            _mapper = mapper;
        }

        public async Task<List<ShipperResponse>> GetAllShippers()
        {
            List<Shipper> shippers = await getShippersUseCase.ExecuteAsync();
            return _mapper.Map<List<ShipperResponse>>(shippers);
        }
    }
}
