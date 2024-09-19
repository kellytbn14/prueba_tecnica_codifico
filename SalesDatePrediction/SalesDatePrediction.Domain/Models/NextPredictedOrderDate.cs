namespace SalesDatePrediction.Domain.Models
{
    public class NextPredictedOrderDate : ModelBase
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
    }
}
