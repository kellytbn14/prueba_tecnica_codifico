using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Repositories;

namespace SalesDatePrediction.Infrastructure.Database.Repositories
{
    public class ShipperRepository : Repository<Shipper>, IShipperRepository
    {
        public ShipperRepository(SalesDatesPredictionContext context) : base(context)
        {

        }
    }
}
